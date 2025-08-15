using MediatR;

namespace Application.Message
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
  where TQuery : IQuery<TResponse>
    {

    }
}



