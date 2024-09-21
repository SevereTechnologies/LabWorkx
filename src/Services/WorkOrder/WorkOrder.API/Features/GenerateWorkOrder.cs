using ApplicationBlocks.Messaging.Events;
using MassTransit;
using WorkOrder.API.Repository;

namespace WorkOrder.API.Features;

public record GenerateWorkOrderCommand(WorkOrderDto WorkOrderDto) : ICommand<GenerateWorkOrderResponse>;

public record GenerateWorkOrderResponse(bool IsSuccess);

public class GenerateWorkOrderValidator : AbstractValidator<GenerateWorkOrderCommand>
{
    public GenerateWorkOrderValidator()
    {
        RuleFor(x => x.WorkOrderDto).NotNull().WithMessage("WorkOrderDto can't be null");
        RuleFor(x => x.WorkOrderDto.PatientId).NotEmpty().NotNull().WithMessage("PatientId is required");
        RuleFor(x => x.WorkOrderDto.PatientFirstName).NotEmpty().NotNull().WithMessage("PatientFirstName is required");
        RuleFor(x => x.WorkOrderDto.LabId).NotEmpty().NotNull().WithMessage("LabId is required");
        RuleFor(x => x.WorkOrderDto.ProviderId).NotEmpty().NotNull().WithMessage("ProviderId is required");
        RuleFor(x => x.WorkOrderDto.TechnicianId).NotEmpty().NotNull().WithMessage("TechnicianId is required");
        RuleFor(x => x.WorkOrderDto.RequestId).NotEmpty().NotNull().WithMessage("RequestId is required");
        RuleFor(x => x.WorkOrderDto.ShipperId).NotEmpty().NotNull().WithMessage("RequestId is required");
        RuleFor(x => x.WorkOrderDto.PatientLastName).NotEmpty().NotNull().WithMessage("PatientLastName is required");
    }
}


public class GenerateWorkOrderEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapPost("/workorder/generate", async (GenerateWorkOrderCommand command, ISender sender) =>
        {
            var response = await sender.Send(command);

            return Results.Ok(response);
        })
        .WithName("GenerateWorkOrder")
        .Produces<GenerateWorkOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Generate Work Order")
        .WithDescription("Generate Work Order");
    }
}

public class GenerateWorkOrderHandler(IWorkOrderRepository repository, IPublishEndpoint publishEndpoint) : ICommandHandler<GenerateWorkOrderCommand, GenerateWorkOrderResponse>
{
    public async Task<GenerateWorkOrderResponse> Handle(GenerateWorkOrderCommand command, CancellationToken cancellationToken)
    {
        // get existing workorder
        var order = await repository.GetWorkOrderAsync(command.WorkOrderDto.RequestId, cancellationToken);
        if (order == null)
        {
            return new GenerateWorkOrderResponse(false);
        }

        // transform from workorder to event workorder
        var eventMessage = command.WorkOrderDto.Adapt<WorkOrderGenerateEvent>();

        // send workorder eventMessage event to rabbitmq using masstransit
        await publishEndpoint.Publish(eventMessage, cancellationToken);

        // delete the workorder from the database
        await repository.DeleteWorkOrderAsync(command.WorkOrderDto.RequestId, cancellationToken);

        // return status
        return new GenerateWorkOrderResponse(true);
    }
}

