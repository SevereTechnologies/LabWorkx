namespace HealthCareProvider.API.Features;

public record DeleteProviderCommand(Guid Id) : ICommand<DeleteProviderResponse>;

public record DeleteProviderResponse(bool IsSuccess);

public class DeleteProviderCommandValidator : AbstractValidator<DeleteProviderCommand>
{
    public DeleteProviderCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Provider ID is required");
    }
}

internal class DeleteProviderHandler(IDocumentSession session) : ICommandHandler<DeleteProviderCommand, DeleteProviderResponse>
{
    public async Task<DeleteProviderResponse> Handle(DeleteProviderCommand command, CancellationToken cancellationToken)
    {
        session.Delete<Provider>(command.Id);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteProviderResponse(true);
    }
}

public class DeleteProviderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/providers/{id}", async (Guid id, ISender sender) =>
        {
            var response = await sender.Send(new DeleteProviderCommand(id));

            return Results.Ok(response);
        })
        .WithName("DeleteProvider")
        .Produces<DeleteProviderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Provider")
        .WithDescription("Delete Provider");
    }
}