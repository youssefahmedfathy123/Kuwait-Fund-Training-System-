using MediatR;

namespace Application.Message
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>

   where TCommand : ICommand<TResponse>
    { }
}


