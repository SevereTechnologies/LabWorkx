namespace HealthCareProvider.API.Models;

public class Provider
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required List<string> Practice { get; set; }
    public string Manager { get; set; } = default!;
    public required string TaxId { get; set; }
    public required string NPI { get; set; }
    public bool MedicalDoctor { get; set; } = default!;
    public bool BoardCertified { get; set; } = default!;
    public string Description { get; set; } = default!;
}
