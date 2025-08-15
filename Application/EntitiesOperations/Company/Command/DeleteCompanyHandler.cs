using Application.Interfaces;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Company.Command
{
    public sealed class DeleteCompanyHandler : ICommandHandler<DeleteCompany,Result<string>>
    {
        private readonly ICompanyServices _companyServices;
        public DeleteCompanyHandler(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }
        public async Task<Result<string>> Handle(DeleteCompany request, CancellationToken cancellationToken)
        {
            return await _companyServices.Delete(request, cancellationToken);
        }
    }
}



