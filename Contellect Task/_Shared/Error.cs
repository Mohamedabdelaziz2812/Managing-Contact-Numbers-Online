
namespace Contellect_Task._Shared;

public class Error : IEquatable<Error>
{
    public static readonly Error None = new Error(string.Empty, string.Empty);
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    public string Code { get; }
    public string Message { get; }

    public static bool operator ==(Error? a, Error? b)
    {
        if (ReferenceEquals(a, b))
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Error? a, Error? b)
    {
        return !(a == b);
    }

    public bool Equals(Error? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return other.Code == Code && other.Message == Message;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Error);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + Code.GetHashCode();
            hash = hash * 23 + Message.GetHashCode();
            return hash;
        }
    }
}
