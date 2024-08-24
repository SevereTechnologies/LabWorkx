namespace WorkOrder.API.Models;

public class WorkItem
{
    public Guid RequestId { get; set; }
    public string PatientPhone { get; set; } = default!;
    public string PatientFirstName { get; set; } = default!;
    public string PatientLastName { get; set; } = default!;
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
    public JobStatusEnum Status { get; set; } = JobStatusEnum.Received;
}

public enum JobStatusEnum
{
    Received = 100,
    Collected = 200,
    Shipped = 300,
    Delivered = 400,
    Completed = 500
}