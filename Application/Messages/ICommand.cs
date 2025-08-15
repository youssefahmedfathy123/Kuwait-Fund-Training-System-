using MediatR;

namespace Application.Message
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}




