using WorkOrder.API.Repository;

namespace WorkOrder.API.Features;

public record GetWorkOrdersQuery(Guid technicianId) : IQuery<GetWorkOrdersResponse>;

public record GetWorkOrdersResponse(List<WorkItem> Items);

public class GetWorkOrdersHandler(IWorkOrderRepository repository) : IQueryHandler<GetWorkOrdersQuery, GetWorkOrdersResponse>
{
    public async Task<GetWorkOrdersResponse> Handle(GetWorkOrdersQuery query, CancellationToken cancellationToken)
    {
        var items = await repository.GetWorkOrdersAsync(query.technicianId);

        return new GetWorkOrdersResponse(items);
    }
}

public class GetWorkOrdersEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/workorders/{technicianId}", async (Guid technicianId, ISender sender) =>
        {
            var response = await sender.Send(new GetWorkOrdersQuery(technicianId));

            return Results.Ok(response);
        })
        .WithName("GetWorkOrdersByTechnicianId")
        .Produces<GetWorkOrdersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Work Orders By Technician Id")
        .WithDescription("Get Work Orders By Technician Id");
    }
}