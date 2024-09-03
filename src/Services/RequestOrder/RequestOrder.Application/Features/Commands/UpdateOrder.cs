namespace RequestOrder.Application.Features.Commands;

public record UpdateOrderResponse(bool IsSuccess, string Message);

public record UpdateOrderCommand(OrderDto Order) : ICommand<UpdateOrderResponse>;

public class UpdateOrderValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderValidator()
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

public class UpdateOrderHandler(IRepositoryManager manager) : ICommandHandler<UpdateOrderCommand, UpdateOrderResponse>
{
    public async Task<UpdateOrderResponse> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.Order.Id);

        var order = await manager.Order.GetByIdAsync(orderId, cancellationToken: cancellationToken);

        if (order is null)
        {
            return new UpdateOrderResponse(false, "Order Not Found!");
        }

        // update the order record
        UpdateOrderValues(order, command.Order);

        manager.Order.Update(order);

        await manager.SaveChangesAsync(cancellationToken);

        return new UpdateOrderResponse(true, "Order Updated Successfully!");
    }

    private void UpdateOrderValues(Order entity, OrderDto dto)
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

        entity.Update(
            orderNumber: OrderNumber.Of(dto.OrderNumber),
            technicianId: TechnicianId.Of(dto.TechnicianId),
            labId: LabId.Of(dto.LabId),
            shipperId: ShipperId.Of(dto.ShipperId),
            patientAddress: Address.Of(dto.Address.Address1, dto.Address.Address2, dto.Address.City, dto.Address.State, dto.Address.ZipCode, dto.Address.Country),
            insurance: Insurance.Of(dto.Insurance.Company, dto.Insurance.Group, dto.Insurance.Policy),
            payment: Payment.Of(dto.Payment.MedicarePaidAmount, dto.Payment.MedicarePaidDate, dto.Payment.MedicaidPaidAmount, dto.Payment.MedicaidPaidDate, dto.Payment.LabPaidAmount, dto.Payment.LabPaidDate, dto.Payment.OtherPaidAmount, dto.Payment.OtherPaidDate),
            drivingDistance: dto.DrivingDistance,
            status: dto.Status);
    }
}