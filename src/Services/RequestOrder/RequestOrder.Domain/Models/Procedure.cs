using RequestOrder.Domain.Abstractions;
using RequestOrder.Domain.ValueObjects;

namespace RequestOrder.Domain.Models;

public class Procedure : Aggregate<ProcedureId>
{
    internal Procedure(RequestId requestId, string procedureCode, int quanity, decimal price, bool completed, string comment)
    {
        Id = ProcedureId.Of(Guid.NewGuid());
        RequestId = requestId;
        ProcedureCode = procedureCode;
        Quantity = quanity;
        Price = price;
        Completed = completed;
        Comment = comment;
    }

    public RequestId RequestId { get; private set; } = default!;
    public string ProcedureCode { get; private set; } = default!;
    public int Quantity { get; private set; } = default!; // exp: quantity of blood valves taken
    public decimal Price { get; private set; } = default!; // exp: price per unit
    public bool Completed { get; private set; } = default!;
    public string Comment { get; private set; } = default!;
}
