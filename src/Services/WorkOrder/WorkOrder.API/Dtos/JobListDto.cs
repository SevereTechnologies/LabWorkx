using WorkOrder.API.Models;

namespace WorkOrder.API.Dtos;

public class JobListDto
{
    public Guid RequestId { get; set; }
    public string TechnicianFirstName { get; set; } = default!;
    public string TechnicianLastName { get; set; } = default!;
    public string PatientFirstName { get; set; } = default!;
    public string PatientLastName { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Zip { get; set; } = default!;
    public JobStatusEnum Status { get; set; }
}
