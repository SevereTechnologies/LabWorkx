using WorkOrder.API.Repository;

namespace WorkOrder.API.Features;

public record GetWorkOrderQuery(Guid RequestId) : IQuery<GetWorkOrderResponse>;

public record GetWorkOrderResponse(WorkItem? WorkItem);

public class GetWorkOrderHandler(IWorkOrderRepository repository) : IQueryHandler<GetWorkOrderQuery, GetWorkOrderResponse>
{
    public async Task<GetWorkOrderResponse> Handle(GetWorkOrderQuery query, CancellationToken cancellationToken)
    {
        var item = await repository.GetWorkOrderAsync(query.RequestId);

        return new GetWorkOrderResponse(item);
    }
}

public class GetWorkOrderEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/workorder/{requestId}", async (Guid requestId, ISender sender) =>
        {
            var response = await sender.Send(new GetWorkOrderQuery(requestId));

            return Results.Ok(response);
        })
        .WithName("GetWorkOrderById")
        .Produces<GetWorkOrderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Work Order By Id")
        .WithDescription("Get Work Order By Id");
    }
}