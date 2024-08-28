namespace RequestOrder.Domain.ValueObjects;

public record Payment
{
    public string CardName { get; } = default!;
    public string CardNumber { get; } = default!;
    public string Experiation { get; } = default!;
    public string CVV { get; } = default!;
    public int PaymentMethod { get; } = default!;
}
