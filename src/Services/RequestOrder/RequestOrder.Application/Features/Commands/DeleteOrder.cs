namespace RequestOrder.Application.Features.Commands;

public record DeleteOrderResponse(bool IsSuccess, string Message);

public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderResponse>;

public class DeleteOrderValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required");
    }
}

public class DeleteOrderHandler(IRepositoryManager manager) : ICommandHandler<DeleteOrderCommand, DeleteOrderResponse>
{
    public async Task<DeleteOrderResponse> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.OrderId);

        var order = await manager.Order.FindAsync(orderId, cancellationToken: cancellationToken);

        if (order is null)
        {
            return new DeleteOrderResponse(false, "Order Not Found!");
        }

        manager.Order.Delete(order);

        await manager.SaveChangesAsync(cancellationToken);

        return new DeleteOrderResponse(true, "Success!");
    }
}