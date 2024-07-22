namespace DNA.Labs.Labs7;

public class ProtocolStep
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public IList<ProtocolStepInput> Inputs { get; private set; }

    public ProtocolStep(Guid id, string description)
    {
        Id = id;
        Description = description;
        Inputs = new List<ProtocolStepInput>();
    }

    private ProtocolStep CreateProtocolStep(string description)
        => new ProtocolStep(Guid.NewGuid(), description);

    public void AddInput(ProtocolStepInput input)
    {
        ArgumentNullException.ThrowIfNull(input);
        Inputs.Add(input);
    }
}