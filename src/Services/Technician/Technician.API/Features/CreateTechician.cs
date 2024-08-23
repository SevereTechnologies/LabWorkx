namespace Technician.API.Features;

public record CreateTechnicianResponse(Guid Id);

public record CreateTechnicianCommand(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string Gender,
    DateTime StartDate,
    PhlebotomistListAddressDto Address,
    PhlebotomistListEducationDto Education,
    PhlebotomistListContactDto Contact) : ICommand<CreateTechnicianResponse>;

public class CreateTechnicianValidator : AbstractValidator<CreateTechnicianCommand>
{
    public CreateTechnicianValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Practice required");
        RuleFor(x => x.DateOfBirth).NotNull().WithMessage("DateOfBirth is required");
        RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required");
        RuleFor(x => x.Address).NotNull().WithMessage("Address is required");
        RuleFor(x => x.Education).NotNull().WithMessage("Education is required");
        RuleFor(x => x.Contact).NotNull().WithMessage("Contact is required");
    }
}

internal class CreateTechnicianHandler(IDocumentSession session) : ICommandHandler<CreateTechnicianCommand, CreateTechnicianResponse>
{
    public async Task<CreateTechnicianResponse> Handle(CreateTechnicianCommand command, CancellationToken cancellationToken)
    {
        var phlebotomist = new Phlebotomist
        {
            PhlebotomistId = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            DateOfBirth = command.DateOfBirth,
            Gender = command.Gender,
            HiredDate = command.StartDate,
            EnteredOn = DateTime.UtcNow,
            ModifiedOn = DateTime.UtcNow,
            Active = true,

            Address = command.Address.Address,
            City = command.Address.City,
            State = command.Address.State,
            Zip = command.Address.Zip,

            Phone = command.Contact.Phone,
            Email = command.Contact.Email,

            Degree = command.Education.Degree,
            CertificationCode = command.Education.CertificationCode,
            CertificationName = command.Education.CertificationName,
            YearsExperience = command.Education.YearsExperience
        };

        //track data
        session.Store(phlebotomist);

        //post to database
        await session.SaveChangesAsync(cancellationToken);

        //return response
        return new CreateTechnicianResponse(phlebotomist.PhlebotomistId);
    }
}

public class CreateTechnicianEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/technicians",
            async (CreateTechnicianCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);

                return Results.Created($"/technicians/{response.Id}", response);
            })
        .WithName(" CreateTechnician")
        .Produces<CreateTechnicianResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Technician")
        .WithDescription("Create Technician");
    }
}