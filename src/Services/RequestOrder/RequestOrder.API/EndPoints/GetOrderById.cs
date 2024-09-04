using RequestOrder.Application.Features.Queries;

namespace RequestOrder.API.EndPoints;

public class GetOrderById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/order/{orderId}", async (Guid orderId, ISender sender) =>
        {
            var response = await sender.Send(new GetOrderByIdQuery(orderId));

            return Results.Ok(response);
        })
        .WithName("GetOrderById")
        .Produces<GetOrderByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Order By Id")
        .WithDescription("Get Order By Id");
    }
}
