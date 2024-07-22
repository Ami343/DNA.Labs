namespace DNA.Labs.Labs7;

public class Protocol
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public IList<ProtocolStep> Steps { get; private set; }

    private Protocol(Guid id, string name)
    {
        Id = id;
        Name = name;
        Steps = new List<ProtocolStep>();
    }

    public static Protocol CreateProtocol(string name)
        => new Protocol(Guid.NewGuid(), name);

    public void AddStep(ProtocolStep step)
    {
        Steps.Add(step);
    }
}