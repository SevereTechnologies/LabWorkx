using FluentValidation;
using HealthCareProvider.API.Domain;

namespace HealthCareProvider.API.Application;

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