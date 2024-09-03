namespace RequestOrder.Application.Dtos;

public record OrderDto(
    Guid Id,
    OrderNumber OrderNumber,
    PatientId PatientId,
    TechnicianId TechnicianId,
    ProviderId ProviderId,
    LabId LabId,
    ShipperId ShipperId,
    Address Address,
    Payment Payment,
    Insurance Insurance,
    OrderStatus Status,
    int DrivingDistance,
    decimal TotalCost,
    List<OrderItemDto> OrderItems);