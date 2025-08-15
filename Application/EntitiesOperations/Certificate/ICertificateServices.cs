using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.EntitiesOperations
{
    public interface ICertificateServices
    {
        Task<string> Create(Guid TraineeId, IFormFile File, CancellationToken cancletionToken);
        Task<Result<string>> Update(UpdateCertificateFileDto input, CancellationToken cancletionToken);
        Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken);
        Task<List<CertificateDto>> Read(CancellationToken cancletionToken);
        Task<Domain.Entities.Certificate> FindById(Guid Id, CancellationToken cancletionToken);

    }
}


