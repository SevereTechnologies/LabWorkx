using RequestOrder.Domain.Abstractions;
using RequestOrder.Domain.ValueObjects;

namespace RequestOrder.Domain.Models;

public class Patient : Entity<PatientId>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;
    public string Gender { get; set; } = default!;
    public string SSN { get; set; } = default!;
    public Insurance Insurance { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public int TravelDistance { get; set; } = default!;
}
