namespace HealthProvider.API.Domain;

public class HealthCareProvider
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Practice { get; set; } = default!;
    public List<string> Specialties { get; set; } = new();
    public string Manager { get; set; } = default!;
    public string TaxId { get; set; } = default!;
    public string NPI { get; set; } = default!;
    public bool MedicalDoctor { get; set; } = default!;
    public bool BoardCertified { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
}
