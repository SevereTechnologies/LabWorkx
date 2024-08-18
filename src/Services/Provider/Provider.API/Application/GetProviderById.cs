namespace HealthCareProvider.API.Application;

public record GetProviderByIdQuery(Guid Id) : IQuery<GetProviderByIdResponse>;

public record GetProviderByIdResponse(ProviderDetailsDto? provider);

internal class GetProviderByIdHandler(IDocumentSession session) : IQueryHandler<GetProviderByIdQuery, GetProviderByIdResponse>
{
    public async Task<GetProviderByIdResponse> Handle(GetProviderByIdQuery query, CancellationToken cancellationToken)
    {
        var provider = await session.LoadAsync<Provider>(query.Id, cancellationToken);

        var providerDto = provider.Adapt<ProviderDetailsDto>();

        return new GetProviderByIdResponse(providerDto);
    }
}

public class GetProviderByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/providers/{id}", async (Guid id, ISender sender) =>
        {
            var respnse = await sender.Send(new GetProviderByIdQuery(id));

            return Results.Ok(respnse);
        })
        .WithName("GetProviderById")
        .Produces<GetProviderByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Provider By Id")
        .WithDescription("Get Provider By Id");
    }
}