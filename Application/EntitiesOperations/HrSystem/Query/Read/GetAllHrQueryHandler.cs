using Application.Common;
using Application.Message;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.HrSystem.Query.Read
{
    public record GetAllHrQueryHandler : IQueryHandler<GetAllHrQuery, List<HrDto>>
    {
        private readonly IHrsystemServices _hrServices;
        public GetAllHrQueryHandler(IHrsystemServices hrServices)
        {
            _hrServices = hrServices;
        }

        public async Task<List<HrDto>> Handle(GetAllHrQuery request, CancellationToken cancellationToken)
        {
            return await _hrServices.Read();
        }
    }
}

