using WorkOrder.API.Repository;

namespace WorkOrder.API.Features;

public record StoreWorkOrderCommand(WorkItem WorkItem) : ICommand<StoreWorkOrderResponse>;

public record StoreWorkOrderResponse(Guid RequestId);

public class StoreWorkOrderValidator : AbstractValidator<StoreWorkOrderCommand>
{
    public StoreWorkOrderValidator()
    {
        RuleFor(x => x.WorkItem).NotNull().WithMessage("WorkItem can not be null");
        RuleFor(x => x.WorkItem.ProviderId).NotEmpty().WithMessage("ProviderId is required");
        RuleFor(x => x.WorkItem.LabId).NotEmpty().WithMessage("LabId is required");
        RuleFor(x => x.WorkItem.PatientId).NotEmpty().WithMessage("PatientId is required");
        RuleFor(x => x.WorkItem.ShipperId).NotEmpty().WithMessage("ShipperId is required");
        RuleFor(x => x.WorkItem.TechnicianId).NotEmpty().WithMessage("TechnicianId is required");
    }
}

public class StoreWorkOrderHandler(IWorkOrderRepository repository) : ICommandHandler<StoreWorkOrderCommand, StoreWorkOrderResponse>
{
    public async Task<StoreWorkOrderResponse> Handle(StoreWorkOrderCommand command, CancellationToken cancellationToken)
    {
        await repository.StoreWorkOrderAsync(command.WorkItem, cancellationToken);

        return new StoreWorkOrderResponse(command.WorkItem.RequestId);
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