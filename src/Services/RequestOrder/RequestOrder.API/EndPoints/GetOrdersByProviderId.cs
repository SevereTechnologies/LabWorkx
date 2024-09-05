using RequestOrder.Application.Features.Queries;

namespace RequestOrder.API.EndPoints;

public class GetOrdersByProviderId : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/provider/{providerId}", async (Guid providerId, ISender sender) =>
        {
            var response = await sender.Send(new GetOrderByProviderQuery(providerId));

            return Results.Ok(response);
        })
        .WithName("GetOrdersByProviderId")
        .Produces<GetOrderByProviderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders By Provider Id")
        .WithDescription("Get Orders By Provider Id");
    }
}
