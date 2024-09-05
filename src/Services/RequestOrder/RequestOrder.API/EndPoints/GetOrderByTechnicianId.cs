using RequestOrder.Application.Features.Queries;

namespace RequestOrder.API.EndPoints;

public class GetOrderByTechnicianId : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/technician/{technicianId}", async (Guid technicianId, ISender sender) =>
        {
            var response = await sender.Send(new GetOrderByTechnicianQuery(technicianId));

            return Results.Ok(response);
        })
        .WithName("GetOrdersByTechnicianId")
        .Produces<GetOrderByTechnicianResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders By Technician Id")
        .WithDescription("Get Orders By Technician Id");
    }
}
