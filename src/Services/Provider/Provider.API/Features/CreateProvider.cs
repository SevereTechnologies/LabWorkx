namespace HealthCareProvider.API.Features;

public record CreateProviderCommand(
    string Name,
    List<string> Practice,
    string Manager,
    string TaxId,
    string NPI,
    bool MedicalDoctor,
    bool BoardCertified,
    string Description) : ICommand<CreateProviderResponse>;

public record CreateProviderResponse(Guid Id);

public class CreateProviderValidator : AbstractValidator<CreateProviderCommand>
{
    public CreateProviderValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Practice).NotEmpty().WithMessage("Practice required");
        RuleFor(x => x.Manager).NotEmpty().WithMessage("Manager is required");
        RuleFor(x => x.TaxId).NotEmpty().WithMessage("TaxId is required");
        RuleFor(x => x.NPI).NotEmpty().WithMessage("NPI is required");
    }
}

internal class CreateProviderHandler(IDocumentSession session) : ICommandHandler<CreateProviderCommand, CreateProviderResponse>
{
    public async Task<CreateProviderResponse> Handle(CreateProviderCommand command, CancellationToken cancellationToken)
    {
        var provider = new Provider
        {
            Name = command.Name,
            Description = command.Description,
            Manager = command.Manager,
            Practice = command.Practice,
            BoardCertified = command.BoardCertified,
            MedicalDoctor = command.MedicalDoctor,
            NPI = command.NPI,
            TaxId = command.TaxId
        };

        //track data
        session.Store(provider);

        //post to database
        await session.SaveChangesAsync(cancellationToken);

        //return response
        return new CreateProviderResponse(provider.Id);
    }
}

public class CreateProviderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/providers",
            async (CreateProviderCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);

                return Results.Created($"/providers/{response.Id}", response);
            })
        .WithName(" CreateProvider")
        .Produces<CreateProviderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Provider")
        .WithDescription("Create Provider");
    }
}