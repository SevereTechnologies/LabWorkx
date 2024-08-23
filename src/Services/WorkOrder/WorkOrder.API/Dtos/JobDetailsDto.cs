using WorkOrder.API.Models;

namespace WorkOrder.API.Dtos;

public class JobDetailsDto
{
    public Guid RequestId { get; set; }
    public string TechnicianFirstName { get; set; } = default!;
    public string TechnicianLastName { get; set; } = default!;
    public string PatientPhone { get; set; }
    public string PatientFirstName { get; set; } = default!;
    public string PatientLastName { get; set; } = default!;
    public string Address1 { get; set; } = default!;
    public string Address2 { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Zip { get; set; } = default!;
    public string ProviderName { get; set; }
    public string ShipperName { get; set; }
    public string LabName { get; set; }
    public string TrackingNumber { get; set; }
    public string Diagnosis { get; set; }
    public string Specimen { get; set; }
    public int MileageTravel { get; set; }
    public DateTime CollectedOn { get; set; }
    public DateTime ShippedOn { get; set; }
    public string Notes { get; set; }
    public JobStatusEnum Status { get; set; }
}
