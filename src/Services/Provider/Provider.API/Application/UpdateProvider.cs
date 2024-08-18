namespace HealthCareProvider.API.Application;

public record UpdateProviderCommand(
    Guid Id,
    string Name,
    List<string> Practice,
    string Manager,
    string TaxId,
    string NPI,
    bool MedicalDoctor,
    bool BoardCertified,
    string Description) : ICommand<UpdateProviderResponse>;

public record UpdateProviderResponse(bool IsSuccess, string Message);

public class UpdateProviderValidator : AbstractValidator<UpdateProviderCommand>
{
    public UpdateProviderValidator()
    {
        RuleFor(command => command.Id).NotEmpty().WithMessage("Provider Id is required");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Practice).NotEmpty().WithMessage("Practice required");
        RuleFor(x => x.Manager).NotEmpty().WithMessage("Manager is required");
        RuleFor(x => x.TaxId).NotEmpty().WithMessage("TaxId is required");
        RuleFor(x => x.NPI).NotEmpty().WithMessage("NPI is required");
    }
}

internal class UpdateProviderHandler(IDocumentSession session) : ICommandHandler<UpdateProviderCommand, UpdateProviderResponse>
{
    public async Task<UpdateProviderResponse> Handle(UpdateProviderCommand command, CancellationToken cancellationToken)
    {
        var provider = await session.LoadAsync<Provider>(command.Id, cancellationToken);

        if (provider is null)
        {
            return new UpdateProviderResponse(true, "Not Found");
        }

        // update provider info
        provider.Name = command.Name;
        provider.Practice = command.Practice;
        provider.Description = command.Description;
        provider.TaxId = command.TaxId;
        provider.NPI = command.NPI;
        provider.MedicalDoctor = command.MedicalDoctor;
        provider.BoardCertified = command.BoardCertified;

        // track data
        session.Update(provider);

        // post to db
        await session.SaveChangesAsync(cancellationToken);

        // return result
        return new UpdateProviderResponse(true, "Updated!");
    }
}

public class UpdateProviderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/providers",
            async (UpdateProviderCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);

                return Results.Ok(response);
            })
            .WithName("UpdateProvider WithName")
            .Produces<UpdateProviderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Provider WithSummary")
            .WithDescription("Update Provider WithDescription");
    }
}