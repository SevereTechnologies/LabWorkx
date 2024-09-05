namespace RequestOrder.Application.Features.Commands;

public record CreateOrderResponse(Guid Id, string Message);

public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResponse>;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.Order.ProviderId).NotEmpty().WithMessage("ProviderId is required");
        RuleFor(x => x.Order.ShipperId).NotEmpty().WithMessage("ShipperId is required");
        RuleFor(x => x.Order.LabId).NotEmpty().WithMessage("LabId is required");
        RuleFor(x => x.Order.PatientId).NotEmpty().WithMessage("PatientId is required");
        RuleFor(x => x.Order.ProviderId).NotEmpty().WithMessage("ProviderId is required");
        RuleFor(x => x.Order.ShipperId).NotEmpty().WithMessage("ShipperId is required");
        RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems cannot be empty");
        RuleFor(x => x.Order.Insurance).NotEmpty().WithMessage("Insurance is required");
    }
}

public class CreateOrderHandler(IRepositoryManager manager) : ICommandHandler<CreateOrderCommand, CreateOrderResponse>
{
    public async Task<CreateOrderResponse> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        //create Order entity from command object
        var order = CreateNewOrder(command.Order);

        //track in db context
        manager.Order.Add(order);

        //save to database
        await manager.SaveChangesAsync(cancellationToken);

        //return response
        return new CreateOrderResponse(order.Id.Value, "Order Created Successfully!");
    }

    private Order CreateNewOrder(OrderDto dto)
    {
        var address = Address.Of(
            dto.Address.Address1,
            dto.Address.Address2,
            dto.Address.City,
            dto.Address.State,
            dto.Address.ZipCode,
            dto.Address.Country);

        var insurance = Insurance.Of(
            dto.Insurance.Company,
            dto.Insurance.Group,
            dto.Insurance.Policy);

        var payment = Payment.Of(
            dto.Payment.MedicarePaidAmount,
            dto.Payment.MedicarePaidDate,
            dto.Payment.MedicaidPaidAmount,
            dto.Payment.MedicaidPaidDate,
            dto.Payment.LabPaidAmount,
            dto.Payment.LabPaidDate,
            dto.Payment.OtherPaidAmount,
            dto.Payment.OtherPaidDate);

        var newOrder = Order.Create(
                id: OrderId.Of(Guid.NewGuid()),
                orderNumber: OrderNumber.Of(dto.OrderNumber),
                technicianId: TechnicianId.Of(dto.TechnicianId),
                providerId: ProviderId.Of(dto.ProviderId),
                patientId: PatientId.Of(dto.PatientId),
                labId: LabId.Of(dto.LabId),
                shipperId: ShipperId.Of(dto.ShipperId),
                patientAddress: address,
                insurance: insurance,
                payment: payment);

        //add the line items
        foreach (var itemDto in dto.OrderItems)
        {
            newOrder.Add(ProcedureId.Of(itemDto.procedureId), itemDto.Quantity, itemDto.Cost);
        }

        return newOrder;
    }
}