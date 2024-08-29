namespace RequestOrder.Domain.Models;

public class Patient : Entity<PatientId>
{
    private const int minAge = 18;
    public string FirstName { get; private set; } = default!;
    public string LastName { get; private set; } = default!;
    public string MiddleName { get; private set; } = default!;
    public DateTime DateOfBirth { get; private set; } = default!;
    public string Gender { get; private set; } = default!;
    public string SSN { get; private set; } = default!;
    public Insurance Insurance { get; private set; } = default!;
    public Address Address { get; private set; } = default!;
    public int TravelDistance { get; private set; } = default!;

    public static Patient Create(PatientId patientId, string firstName, string lastName, DateTime dob, string gender, string ssn, int travelDistance, Insurance insurance, Address address)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ArgumentException.ThrowIfNullOrWhiteSpace(gender);
        ArgumentException.ThrowIfNullOrWhiteSpace(ssn);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(travelDistance);
        
        int minYear = DateTime.Now.AddYears(-18).Year;
        //ArgumentOutOfRangeException.ThrowIfLessThan(dob.Year, minYear);
        if (dob.Year < minYear)
        {
            throw new ArgumentOutOfRangeException(nameof(dob), $"Patient must be {minAge} years old or older.");
        }

        var patient = new Patient
        {
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dob,
            Gender = gender,
            SSN = ssn,
            Insurance = insurance,
            Address = address,
            TravelDistance = travelDistance
        };

        return patient;
    }
}
