namespace RequestOrder.Application.Dtos;

public record OrderItemDto(
    Guid OrderId,
    Guid procedureId,
    int Quantity,
    decimal Cost);