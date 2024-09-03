namespace RequestOrder.Application.Commands;

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
            dto.Address.Zip,
            dto.Address.Country);

        var insurance = Insurance.Of(dto.Insurance.InsuranceCompany, dto.Insurance.InsuranceGroup, dto.Insurance.InsurancePolicy);

        var newOrder = Order.Create(
                id: OrderId.Of(Guid.NewGuid()),
                orderNumber: OrderNumber.Of(dto.OrderNumber.Value),
                technicianId: TechnicianId.Of(dto.TechnicianId.Value),
                providerId: ProviderId.Of(dto.ProviderId.Value),
                patientId: PatientId.Of(dto.PatientId.Value),
                labId: LabId.Of(dto.LabId.Value),
                shipperId: dto.ShipperId,
                patientAddress: address,
                insurance: insurance,
                payment: null);

        //add the line items
        foreach (var itemDto in dto.OrderItems)
        {
            newOrder.Add(ProcedureId.Of(itemDto.procedureId.Value), itemDto.Quantity, itemDto.Cost);
        }

        return newOrder;
    }
}