namespace Contellect_Task._Shared;

public class Result<Tvalue>
{
    internal protected Result(Tvalue? value, bool isSuccess, Error? error = null)
    {
        if ((isSuccess && error is not null) ||
                (!isSuccess && error is null))
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
        Value = value;
    }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; }
    public Tvalue Value { get; }

    public static Result<Tvalue> Success(Tvalue? value) => new(value, true);
    public static Result<Tvalue> Failure(Error error) =>
        new Result<Tvalue>(default, false, error);

    public static implicit operator Result<Tvalue>(Tvalue? value) =>
        Success(value);
    public static implicit operator Result<Tvalue>(Error error) =>
        Failure(error);
}