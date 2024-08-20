namespace Technician.API.Models;

public class PhlebotomistVehicle
{
    public Guid VehicleId { get; set; }
    public Guid PhlebotomistId { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Tag { get; set; } = string.Empty;
    public bool Active { get; set; }
    public DateTime EnteredOn { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Phlebotomist Phlebotomist { get; set; } = new();
}
