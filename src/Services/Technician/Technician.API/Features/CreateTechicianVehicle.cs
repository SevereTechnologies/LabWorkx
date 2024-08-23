namespace Technician.API.Features;

public record CreateTechnicianVehicleResponse(Guid Id);

public record CreateTechnicianVehicleCommand(
    Guid PhlebotomistId,
    string Make,
    string Model,
    int Year,
    string Tag
    ) : ICommand<CreateTechnicianVehicleResponse>;

public class CreateTechnicianVehicleValidator : AbstractValidator<CreateTechnicianVehicleCommand>
{
    public CreateTechnicianVehicleValidator()
    {
        RuleFor(x => x.PhlebotomistId).NotEmpty().WithMessage("required");
        RuleFor(x => x.Make).NotEmpty().WithMessage("required");
        RuleFor(x => x.Model).NotNull().WithMessage("required");
        RuleFor(x => x.Year).GreaterThan(1990).WithMessage("must be greater than 1990");
        RuleFor(x => x.Tag).NotNull().WithMessage("required");
    }
}

internal class CreateTechnicianVehicleHandler(IDocumentSession session) : ICommandHandler<CreateTechnicianVehicleCommand, CreateTechnicianVehicleResponse>
{
    public async Task<CreateTechnicianVehicleResponse> Handle(CreateTechnicianVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = new PhlebotomistVehicle
        {
            PhlebotomistId = Guid.NewGuid(),
            Active = true,
            Make = command.Make,
            Model = command.Model,
            Year = command.Year,
            Tag = command.Tag,
            EnteredOn = DateTime.Now,
            ModifiedOn = DateTime.Now,
            VehicleId = Guid.NewGuid()
        };

        //track data
        session.Store(vehicle);

        //post to database
        await session.SaveChangesAsync(cancellationToken);

        //return response
        return new CreateTechnicianVehicleResponse(vehicle.VehicleId);
    }
}

public class CreateTechnicianVehicleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/technicians/vehicle",
            async (CreateTechnicianVehicleCommand command, ISender sender) =>
            {
                var response = await sender.Send(command);

                return Results.Created($"/technicians/vehicle/{response.Id}", response);
            })
        .WithName("CreateTechnicianVehicle")
        .Produces<CreateTechnicianVehicleResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Technician vehicle")
        .WithDescription("Create Technician vehicle");
    }
}