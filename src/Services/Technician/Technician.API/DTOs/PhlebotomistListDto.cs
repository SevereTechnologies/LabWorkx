namespace Technician.API.Dtos;

public class PhlebotomistListDto
{
    public Guid PhlebotomistId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string Gender { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string? CertificationCode { get; set; }
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Zip { get; set; } = default!;
    public bool Active { get; set; }
}
