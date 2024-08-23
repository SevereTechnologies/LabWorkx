using WorkOrder.API.Repository;

namespace WorkOrder.API.Features;

public record DeleteWorkOrderCommand(Guid RequestId) : ICommand<DeleteWorkOrderResponse>;

public record DeleteWorkOrderResponse(bool IsSuccess);

public class DeleteWorkOrderValidator : AbstractValidator<DeleteWorkOrderCommand>
{
    public DeleteWorkOrderValidator()
    {
        RuleFor(x => x.RequestId).NotEmpty().WithMessage("WorkOrderId is required");
    }
}

public class DeleteWorkOrderHandler(IWorkOrderRepository repository) : ICommandHandler<DeleteWorkOrderCommand, DeleteWorkOrderResponse>
{
    public async Task<DeleteWorkOrderResponse> Handle(DeleteWorkOrderCommand command, CancellationToken cancellationToken)
    {
        // TODO: delete workorder from database and cache       
        await repository.DeleteWorkOrderAsync(command.RequestId, cancellationToken);

        return new DeleteWorkOrderResponse(true);
    }
}

public class DeleteWorkOrderEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/workorder/{requestId}", async (Guid requestId, ISender sender) =>
        {
            var response = await sender.Send(new DeleteWorkOrderCommand(requestId));

            return Results.Ok(response);
        })
        .WithName("DeleteWorkOrder")
        .Produces<DeleteWorkOrderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Work Order")
        .WithDescription("Delete Work Order");
    }
}