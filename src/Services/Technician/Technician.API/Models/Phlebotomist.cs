namespace Technician.API.Models;

public class Phlebotomist
{
    public Guid PhlebotomistId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Zip { get; set; } = default!;
    public string? Degree { get; set; }
    public string? CertificationCode { get; set; }
    public string? CertificationName { get; set; }
    public int YearsExperience { get; set; }
    public DateTime HiredDate { get; set; }
    public DateTime? ExitDate { get; set; }
    public string Biography { get; set; } = string.Empty;
    public bool Active { get; set; }
    public DateTime EnteredOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public ICollection<PhlebotomistVehicle>? Vehicles { get; set; }
}
