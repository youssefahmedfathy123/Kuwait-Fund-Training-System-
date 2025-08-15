using MediatR;

namespace Application.Message
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {

    }
}


