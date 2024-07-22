namespace DNA.Labs.Labs7;

public class ProtocolStepInput : IEquatable<ProtocolStepInput>
{
    public Guid Id { get; }
    public string InputType { get; }
    public string Value { get; }

    private ProtocolStepInput(Guid id, string inputType, string value)
    {
        Id = id;
        InputType = inputType;
        Value = value;
    }

    public static ProtocolStepInput CreateProtocolStepInput(string inputType, string value)
        => new ProtocolStepInput(Guid.NewGuid(), inputType, value);

    public override bool Equals(object? obj)
    {
        return Equals(obj as ProtocolStepInput);
    }

    public bool Equals(ProtocolStepInput? other)
    {
        return other != null &&
               Id.Equals(other.Id) &&
               InputType == other.InputType &&
               Value == other.Value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, InputType, Value);
    }

    public static bool operator ==(ProtocolStepInput left, ProtocolStepInput right)
    {
        return EqualityComparer<ProtocolStepInput>.Default.Equals(left, right);
    }

    public static bool operator !=(ProtocolStepInput left, ProtocolStepInput right)
    {
        return !(left == right);
    }
}