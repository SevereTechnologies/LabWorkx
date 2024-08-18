namespace HealthCareProvider.API.DTOs;

public class ProviderListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Manager { get; set; } = default!;
    public bool MedicalDoctor { get; set; } = default!;
    public bool BoardCertified { get; set; } = default!;
}