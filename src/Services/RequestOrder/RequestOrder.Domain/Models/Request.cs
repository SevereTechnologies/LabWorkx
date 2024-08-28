using RequestOrder.Domain.Abstractions;
using RequestOrder.Domain.Enums;
using RequestOrder.Domain.ValueObjects;

namespace RequestOrder.Domain.Models;

public class Request : Aggregate<RequestId>
{
    private readonly List<Procedure> _procedures = new();
    public IReadOnlyList<Procedure> Procedures => _procedures.AsReadOnly();

    public RequestNo ProcedureNo { get; private set; } = default!;
    public TechnicianId TechnicianId { get; private set; } = default!;
    public ProviderId ProviderId { get; private set; } = default!;
    public PatientId PatientId { get; private set; } = default!;
    public LabId LabId { get; private set; } = default!;
    public ShipperId ShipperId { get; private set; } = default!;
    public string Diagnosis { get; private set; } = default!;
    public Payment Payment { get; private set; } = default!;
    public ProcedureStatus Status { get; private set; } = ProcedureStatus.Received;
    public decimal TotalDue
    {
        get => Procedures.Sum(x => x.Price * x.Quantity);
        private set { }
    }

}