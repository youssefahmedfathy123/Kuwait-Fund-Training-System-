using Application.Interfaces;
using Application.Message;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Company.Query
{
    internal class CompanyDtoHandler : ICommandHandler<GetAllCompanies, List<CompanyDto>>
    {
        private readonly ICompanyServices _companyServices;
        public CompanyDtoHandler(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }
        public async Task<List<CompanyDto>> Handle(GetAllCompanies request, CancellationToken cancellationToken)
        {
            return await _companyServices.Read(cancellationToken);
        }
    }
}



