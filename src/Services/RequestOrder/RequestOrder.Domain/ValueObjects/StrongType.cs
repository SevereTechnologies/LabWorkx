namespace RequestOrder.Domain.ValueObjects;

public record RequestId
{
    public Guid Value { get; }
}
public record ProcedureId
{
    public Guid Value { get; }
}
public record TechnicianId
{
    public Guid Value { get; }
}
public record ProviderId
{
    public Guid Value { get; }
}
public record PatientId
{
    public Guid Value { get; }
}
public record LabId
{
    public Guid Value { get; }
}
public record ShipperId
{
    public Guid Value { get; }
}
public record RequestNo
{
    public string Value { get; }
}
