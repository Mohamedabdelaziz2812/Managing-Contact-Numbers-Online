namespace Contellect_Task.Abstractions;

public interface IValidationResult
{
    IReadOnlyList<Error> Errors { get; }

}
