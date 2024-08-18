using HealthCareProvider.API.Domain;

namespace HealthCareProvider.API.Application;

public record GetProvidersByPracticeQuery(string Practice) : IQuery<GetProvidersByPracticeResponse>;

public record GetProvidersByPracticeResponse(IEnumerable<Provider> providers);

internal class GetProvidersByPracticeHandler(IDocumentSession session) : IQueryHandler<GetProvidersByPracticeQuery, GetProvidersByPracticeResponse>
{
    public async Task<GetProvidersByPracticeResponse> Handle(GetProvidersByPracticeQuery query, CancellationToken cancellationToken)
    {
        var providers = await session.Query<Provider>()
            .Where(p => p.Practice.Contains(query.Practice))
            .ToListAsync(cancellationToken);

        return new GetProvidersByPracticeResponse(providers);
    }
}

public class GetProvidersByPracticeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/providers/practice/{practice}",
            async (string practice, ISender sender) =>
            {
                var response = await sender.Send(new GetProvidersByPracticeQuery(practice));

                return Results.Ok(response);
            })
        .WithName("GetProvidersByPractice")
        .Produces<GetProvidersByPracticeResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Prooviders By Practice")
        .WithDescription("Get Prooviders By Practice");
    }
}