using WorkOrder.API.Repository;

namespace WorkOrder.API.Features;

public record StoreWorkOrderCommand(WorkItem Item) : ICommand<StoreWorkOrderResponse>;

public record StoreWorkOrderResponse(Guid RequestId);

public class StoreWorkOrderValidator : AbstractValidator<StoreWorkOrderCommand>
{
    public StoreWorkOrderValidator()
    {
        RuleFor(x => x.Item).NotNull().WithMessage("WorkItem can not be null");
        RuleFor(x => x.Item.ProviderId).NotEmpty().WithMessage("ProviderId is required");
        RuleFor(x => x.Item.LabId).NotEmpty().WithMessage("LabId is required");
        RuleFor(x => x.Item.PatientId).NotEmpty().WithMessage("PatientId is required");
        RuleFor(x => x.Item.ShipperId).NotEmpty().WithMessage("ShipperId is required");
        RuleFor(x => x.Item.TechnicianId).NotEmpty().WithMessage("TechnicianId is required");
    }
}

public class StoreWorkOrderHandler(IWorkOrderRepository repository) : ICommandHandler<StoreWorkOrderCommand, StoreWorkOrderResponse>
{
    public async Task<StoreWorkOrderResponse> Handle(StoreWorkOrderCommand command, CancellationToken cancellationToken)
    {
        await repository.StoreWorkOrderAsync(command.Item, cancellationToken);

        return new StoreWorkOrderResponse(command.Item.RequestId);
    }
}

public class StoreWorkOrderEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/workorder", async (StoreWorkOrderCommand command, ISender sender) =>
        {
            var response = await sender.Send(command);

            return Results.Created($"/workorder/{response.RequestId}", response);
        })
        .WithName("StoreWorkOrder")
        .Produces<StoreWorkOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Store Work Order")
        .WithDescription("Store Work Order");
    }
}