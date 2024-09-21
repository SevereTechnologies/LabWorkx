namespace WorkOrder.API.Dtos;

public class WorkOrderDto
{
    public Guid RequestId { get; set; }

    // Patient Contact
    public string PatientPhone { get; set; } = default!;

    // Patient Name
    public string PatientFirstName { get; set; } = default!;
    public string PatientLastName { get; set; } = default!;

    // Patient Address
    public string Address1 { get; set; } = default!;
    public string Address2 { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Zip { get; set; } = default!;

    public Guid PatientId { get; set; }
    public Guid TechnicianId { get; set; }
    public Guid ProviderId { get; set; }
    public Guid ShipperId { get; set; }
    public Guid LabId { get; set; }
    public string ProviderName { get; set; } = default!;
    public string ShipperName { get; set; } = default!;
    public string LabName { get; set; } = default!;
    public string TrackingNumber { get; set; } = default!;
    public string Diagnosis { get; set; } = default!;
    public string Specimen { get; set; } = default!;
    public int MileageTravel { get; set; } = default!;
    public DateTime CollectedOn { get; set; }
    public DateTime ShippedOn { get; set; }
    public string Notes { get; set; } = default!;
    public int JobStatus { get; set; } = 100;
}
