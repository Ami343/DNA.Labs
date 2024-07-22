namespace DNA.Labs.Labs7;

public class Machine
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Model { get; private set; }
    public string LicensePlate { get; private set; }

    private Machine(Guid id, string name, string model, string licensePlate)
    {
        Id = id;
        Name = name;
        Model = model;
        LicensePlate = licensePlate;
    }

    public static Machine CreateMachine(string name, string model, string licensePlate)
        => new Machine(Guid.NewGuid(), name, model, licensePlate);
    
}