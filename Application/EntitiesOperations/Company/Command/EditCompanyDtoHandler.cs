using Application.Interfaces;
using Application.Message;
using Gatherly.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Company.Command
{
    public sealed class EditCompanyDtoHandler : ICommandHandler<EditCompanyDto, Result<string>>
    {
        private readonly ICompanyServices _companyServices;
        public EditCompanyDtoHandler(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }
        public async Task<Result<string>> Handle(EditCompanyDto request, CancellationToken cancellationToken)
        {
            return await _companyServices.Update(request, cancellationToken);
        }
    }
}




