namespace Contellect_Task.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }
