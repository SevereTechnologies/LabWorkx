namespace RequestOrder.Domain.ValueObjects;

public record Insurance
{
    public string InsuranceCompany { get; } = default!;
    public string InsuranceGroup { get; } = default!;
    public string InsurancePolicy { get; } = default!;

    private Insurance()
    {
    }

    private Insurance(string company, string group, string policy)
    {
        InsuranceCompany = company;
        InsuranceGroup = group;
        InsurancePolicy = policy;
    }

    public static Insurance Of(string company, string group, string policy)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(company);
        ArgumentException.ThrowIfNullOrWhiteSpace(group);
        ArgumentException.ThrowIfNullOrWhiteSpace(policy);

        return new Insurance(company, group, policy);
    }
}
