using RequestOrder.Domain.Exceptions;

namespace RequestOrder.Domain.ValueObjects;

public record OrderId
{
    public Guid Value { get; }

    private OrderId(Guid value) => Value = value;

    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("OrderId cannot be empty.");
        }

        return new OrderId(value);
    }
}

public record OrderNumber
{
    private const int DefaultLength = 6;
    public string Value { get; }

    private OrderNumber(string value) => Value = value;

    public static OrderNumber Of(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

        return new OrderNumber(value);
    }
}

public record OrderItemId
{
    public Guid Value { get; }

    private OrderItemId(Guid value) => Value = value;

    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("OrderItemId cannot be empty.");
        }

        return new OrderItemId(value);
    }
}

public record ProcedureId
{
    public Guid Value { get; }

    private ProcedureId(Guid value) => Value = value;

    public static ProcedureId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("ProcedureId cannot be empty.");
        }

        return new ProcedureId(value);
    }
}

public record TechnicianId
{
    public Guid Value { get; }

    private TechnicianId(Guid value) => Value = value;

    public static TechnicianId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("TechnicianId cannot be empty.");
        }

        return new TechnicianId(value);
    }
}

public record ProviderId
{
    public Guid Value { get; }

    private ProviderId(Guid value) => Value = value;

    public static ProviderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("ProviderId cannot be empty.");
        }

        return new ProviderId(value);
    }
}

public record PatientId
{
    public Guid Value { get; }

    private PatientId(Guid value) => Value = value;

    public static PatientId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if(value == Guid.Empty)
        {
            throw new DomainException("PatientId cannot be empty.");
        }

        // all is good, so call line 32 constructor PatientId(Guid value) to set the value and return the result.
        return new PatientId(value);
    }
}

public record LabId
{
    public Guid Value { get; }

    private LabId(Guid value) => Value = value;

    public static LabId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("LabId cannot be empty.");
        }

        return new LabId(value);
    }
}

public record ShipperId
{
    public Guid Value { get; }

    private ShipperId(Guid value) => Value = value;

    public static ShipperId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("ShipperId cannot be empty.");
        }

        return new ShipperId(value);
    }
}