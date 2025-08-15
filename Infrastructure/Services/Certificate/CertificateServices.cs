using Application;
using Application.EntitiesOperations;
using Application.EntitiesOperations.Certificate;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CertificateServices : ICertificateServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public CertificateServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(Guid TraineeId, IFormFile urFile, CancellationToken cancletionToken)
        {
            if (urFile.ContentType != "application/pdf")
                return "I need pdf only!";


            using var memoryStream = new MemoryStream();
            await urFile.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

            var newCertificate = new CreateCertificateDto(TraineeId, fileBytes);

            var newRec = _mapping.Map<CreateCertificateDto, Certificate>(newCertificate);

            await _context.Certificates.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }

        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Certificates.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<Certificate> FindById(Guid id, CancellationToken cancletionToken)
        {
            Certificate cer = await _context.Certificates.FirstOrDefaultAsync(x => x.Id == id , cancletionToken);

            return cer;
        }

        

        public async Task<List<CertificateDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Certificates.ToListAsync();

            return _mapping.Map<List<Certificate>, List<CertificateDto>>(table);
        }

        public async Task<Result<string>> Update(UpdateCertificateFileDto input, CancellationToken cancletionToken)
        {

            var table = await _context.Certificates.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            if (input.file.ContentType != "application/pdf")
                return "I need pdf only!";

            using var memoryStream = new MemoryStream();
            await input.file.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

            var record = new UpdateCertificateDto(input.Id,input.TraineeId,fileBytes,input.Status);


            var res = _mapping.Map<UpdateCertificateDto, Certificate>(record);
            await _context.Certificates.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

    }
}



