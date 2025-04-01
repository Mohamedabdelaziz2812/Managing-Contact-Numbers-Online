
namespace Contellect_Task.Abstractions;

public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    private ValidationResult(IReadOnlyList<Error> errors)
        : base(default, false, BaseErrors.ValidationError) =>
        Errors = errors;

    public IReadOnlyList<Error> Errors { get; }
    public static ValidationResult<TValue> WithErrors(IReadOnlyList<Error> errors) => new(errors);
}
