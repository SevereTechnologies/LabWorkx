namespace HealthCareProvider.API.Features;

public record GetProvidersByNameQuery(string Name) : IQuery<GetProvidersByNameResponse>;

public record GetProvidersByNameResponse(IEnumerable<ProviderListDto> providers);

internal class GetProvidersByNameHandler(IDocumentSession session) : IQueryHandler<GetProvidersByNameQuery, GetProvidersByNameResponse>
{
    public async Task<GetProvidersByNameResponse> Handle(GetProvidersByNameQuery query, CancellationToken cancellationToken)
    {
        var providers = await session.Query<Provider>()
            .Where(p => p.Name.Contains(query.Name))
            .ToListAsync(cancellationToken);

        var providerListDto = providers.Adapt<IEnumerable<ProviderListDto>>();

        return new GetProvidersByNameResponse(providerListDto);
    }
}

public class GetProvidersByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/providers/name/{name}",
            async (string name, ISender sender) =>
            {
                var response = await sender.Send(new GetProvidersByNameQuery(name));

                return Results.Ok(response);
            })
        .WithName("GetProvidersByName")
        .Produces<GetProvidersByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Prooviders By Name")
        .WithDescription("Get Prooviders By Name");
    }
}