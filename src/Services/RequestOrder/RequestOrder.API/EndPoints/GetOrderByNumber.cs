using RequestOrder.Application.Features.Queries;

namespace RequestOrder.API.EndPoints;

public class GetOrderByNumber : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/order/{orderNumber}", async (string orderNumber, ISender sender) =>
        {
            var response = await sender.Send(new GetOrderByNumberQuery(orderNumber));

            return Results.Ok(response);
        })
        .WithName("GetOrderByNumber")
        .Produces<GetOrderByNumberResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Order By Number")
        .WithDescription("Get Order By Number");
    }
}
