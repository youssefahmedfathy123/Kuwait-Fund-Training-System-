using Application.Interfaces;
using Application.Message;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations.Company.Command
{
    public sealed class CreateCompanyDtoHandler : ICommandHandler<CreateCompanyDto, string>
    {
        private readonly ICompanyServices _companyServices;
        public CreateCompanyDtoHandler(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }
        public async Task<string> Handle(CreateCompanyDto request, CancellationToken cancellationToken)
        {
            return await _companyServices.Create(request, cancellationToken);
        }
    }
}



