namespace Contellect_Task.Abstractions;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{ }
