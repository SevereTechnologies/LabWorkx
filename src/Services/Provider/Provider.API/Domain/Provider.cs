namespace HealthCareProvider.API.Domain;

public class Provider
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public List<string> Practice { get; set; } = new();
    public string Manager { get; set; } = default!;
    public string TaxId { get; set; } = default!;
    public string NPI { get; set; } = default!;
    public bool MedicalDoctor { get; set; } = default!;
    public bool BoardCertified { get; set; } = default!;
    public string Description { get; set; } = default!;
}
