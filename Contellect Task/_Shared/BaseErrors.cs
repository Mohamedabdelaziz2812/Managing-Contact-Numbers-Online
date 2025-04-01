namespace Contellect_Task._Shared;

public static class BaseErrors
{
    public static readonly Error NotFound = new Error(
        "NotFound",
        "The specified result value is null.");

    public static readonly Error ExceptionHappened = new Error(
        "Exception",
        "Exception occured while processing");

    public static readonly Error ValidationError = new Error(
        "ValidationError",
        "A validation problem occured.");
}
