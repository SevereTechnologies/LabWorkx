namespace RequestOrder.Domain.ValueObjects;

public record Insurance
{
    public string InsuranceCompany { get; } = default!;
    public string InsuranceGroup { get; } = default!;
    public string InsurancePolicy { get; } = default!;
}
