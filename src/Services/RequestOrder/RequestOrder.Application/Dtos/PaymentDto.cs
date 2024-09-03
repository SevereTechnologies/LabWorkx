namespace RequestOrder.Application.Dtos;

public record PaymentDto(
    decimal MedicarePaidAmount,
    DateTime MedicarePaidDate,
    decimal MedicaidPaidAmount,
    DateTime MedicaidPaidDate,
    decimal LabPaidAmount,
    DateTime LabPaidDate,
    decimal OtherPaidAmount,
    DateTime OtherPaidDate);