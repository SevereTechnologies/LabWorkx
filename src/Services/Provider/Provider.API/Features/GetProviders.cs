﻿namespace HealthCareProvider.API.Features;

public record GetProvidersQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProvidersResponse>;

public record GetProvidersResponse(IEnumerable<ProviderListDto> Providers);

internal class GetProvidersHandler(IDocumentSession session) : IQueryHandler<GetProvidersQuery, GetProvidersResponse>
{
    public async Task<GetProvidersResponse> Handle(GetProvidersQuery query, CancellationToken cancellationToken)
    {
        var providers = await session.Query<Provider>()
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        var providerListDto = providers.Adapt<IEnumerable<ProviderListDto>>();

        return new GetProvidersResponse(providerListDto);
    }
}

public class GetProvidersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/providers", async ([AsParameters] GetProvidersQuery request, ISender sender) =>
        {
            var query = request.Adapt<GetProvidersQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetProvidersResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProviders")
        .Produces<GetProvidersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Providers")
        .WithDescription("Get Providers");
    }
}