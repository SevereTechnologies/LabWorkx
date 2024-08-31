namespace RequestOrder.Domain.ValueObjects;

public record Payment
{
    public decimal MedicarePaidAmount { get; } = default!;
    public DateTime MedicarePaidDate { get; } = default!;
    public decimal MedicaidPaidAmount { get; } = default!;
    public DateTime MedicaidPaidDate { get; } = default!;
    public decimal LabPaidAmount { get; } = default!;
    public DateTime LabPaidDate { get; } = default!;
    public decimal OtherPaidAmount { get; } = default!;
    public DateTime OtherPaidDate { get; } = default!;

    protected Payment()
    {
    }

    private Payment(
        decimal medicarePaidAmount, DateTime medicarePaidDate,
        decimal medicaidPaidAmount, DateTime medicaidPaidDate,
        decimal labPaidAmount, DateTime labPaidDate,
        decimal otherPaidAmount, DateTime otherPaidDate)
    {
        MedicarePaidAmount = medicarePaidAmount;
        MedicarePaidDate = medicarePaidDate;
        MedicaidPaidAmount = medicaidPaidAmount;
        MedicaidPaidDate = medicaidPaidDate;
        LabPaidAmount = labPaidAmount;
        LabPaidDate = labPaidDate;
        OtherPaidAmount = otherPaidAmount;
        OtherPaidDate = otherPaidDate;
    }

    public static Payment Of(
        decimal medicarePaidAmount, DateTime medicarePaidDate,
        decimal medicaidPaidAmount, DateTime medicaidPaidDate,
        decimal labPaidAmount, DateTime labPaidDate,
        decimal otherPaidAmount, DateTime otherPaidDate)
    {
        return new Payment(
            medicarePaidAmount,
            medicarePaidDate,
            medicaidPaidAmount,
            medicaidPaidDate,
            labPaidAmount,
            labPaidDate,
            otherPaidAmount,
            otherPaidDate);
    }
}
