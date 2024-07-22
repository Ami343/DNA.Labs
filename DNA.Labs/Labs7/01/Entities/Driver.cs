namespace DNA.Labs.Labs7;

public class Driver
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string LicenseNumber { get; private set; }

    private Driver(Guid id, string firstName, string lastName, string licenseNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        LicenseNumber = licenseNumber;
    }

    public static Driver CreateDriver(string firstName, string lastName, string licenseNumber)
        => new Driver(Guid.NewGuid(), firstName, lastName, licenseNumber);

}