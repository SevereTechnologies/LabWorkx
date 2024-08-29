namespace RequestOrder.Domain.Models;

public class Procedure : Aggregate<ProcedureId>
{
    public string Code { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public string Specimen { get; private set; } = default!;
    public string CPT { get; private set; } = default!;

    public static Procedure Create(string code, string name, string specimen, string cpt)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(code);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(specimen);
        ArgumentException.ThrowIfNullOrWhiteSpace(cpt);

        var procedure = new Procedure
        {
            Code = code,
            Name = name,
            Specimen = specimen,
            CPT = cpt
        };

        return procedure;
    }
}
