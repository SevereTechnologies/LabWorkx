namespace Technician.API.Dtos;

public class PhlebotomistListDetailsDto
{
    public Guid PhlebotomistId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly DateOfBirth { get; set; }
    public string Gender { get; set; } = default!;
    public DateTime HiredDate { get; set; }
    public DateTime? ExitDate { get; set; }
    public string Biography { get; set; } = string.Empty;
    public bool Active { get; set; }
    public DateTime EnteredOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public PhlebotomistListAddressDto AddressDto { get; set; } = new();
    public PhlebotomistListContactDto ContactDto { get; set; } = new();
    public PhlebotomistListEducationDto EducationDto { get; set; } = new();
    public ICollection<PhlebotomistVehicle>? VehiclesDto { get; set; }
}

public class PhlebotomistListAddressDto
{
    public string Address { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Zip { get; set; } = default!;
}

public class PhlebotomistListContactDto
{
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
}

public class PhlebotomistListEducationDto
{
    public string? Degree { get; set; }
    public string? CertificationCode { get; set; }
    public string? CertificationName { get; set; }
    public int YearsExperience { get; set; }
}
