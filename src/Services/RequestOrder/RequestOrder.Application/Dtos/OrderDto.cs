namespace RequestOrder.Application.Dtos;

public record OrderDto(
    Guid Id,
    string OrderNumber,
    Guid PatientId,
    Guid TechnicianId,
    Guid ProviderId,
    Guid LabId,
    Guid ShipperId,
    AddressDto Address,
    PaymentDto Payment,
    InsuranceDto Insurance,
    OrderStatus Status,
    int DrivingDistance,
    decimal TotalCost,
    List<OrderItemDto> OrderItems);