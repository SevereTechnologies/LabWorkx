namespace RequestOrder.Application.Dtos;

public record OrderItemDto(
    Guid OrderId,
    ProcedureId procedureId,
    int Quantity,
    decimal Cost);