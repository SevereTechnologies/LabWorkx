using RequestOrder.Application.Features.Queries;

namespace RequestOrder.API.EndPoints;

public class GetOrdersByPatientId : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/patient/{patientId}", async (Guid patientId, ISender sender) =>
        {
            var response = await sender.Send(new GetOrderByPatientQuery(patientId));

            return Results.Ok(response);
        })
        .WithName("GetOrdersByPatientId")
        .Produces<GetOrderByPatientResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders By Patient Id")
        .WithDescription("Get Orders By Patient Id");
    }
}
