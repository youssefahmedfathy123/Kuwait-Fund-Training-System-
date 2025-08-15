using Application;
using Application.EntitiesOperations.End_of_3phasesReport;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class End_of_3phasesReportServices : IEnd_of_3phasesReportServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public End_of_3phasesReportServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateEnd_of_3phasesReportWithFileDto input, CancellationToken cancletionToken)
        {
            if (input.Pdf.ContentType != "application/pdf")
                return "I need pdf only!";


            using var memoryStream = new MemoryStream();
            await input.Pdf.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

            var record = new CreateEnd_of_3phasesReportDto(input.TraineeId,fileBytes);

            var newRec = _mapping.Map<CreateEnd_of_3phasesReportDto, End_of_3phasesReport>(record);

            await _context.End_of_3phasesReports.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.End_of_3phasesReports.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

             public async Task<End_of_3phasesReport> FindById(Guid id, CancellationToken cancletionToken)
             {
                End_of_3phasesReport cer = await _context.End_of_3phasesReports.FirstOrDefaultAsync(x => x.Id == id, cancletionToken);

                return cer;
             }


        public async Task<List<End_of_3phasesReportDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.End_of_3phasesReports.ToListAsync();

            return _mapping.Map<List<End_of_3phasesReport>, List<End_of_3phasesReportDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateEnd_of_3phasesReporFiletDto input, CancellationToken cancletionToken)
        {

            var table = await _context.End_of_3phasesReports.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            if (input.file.ContentType != "application/pdf")
                return "I need pdf only!";


            using var memoryStream = new MemoryStream();
            await input.file.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

            var record = new UpdateEnd_of_3phasesReportDto(input.Id,input.TraineeId, fileBytes);


            var res = _mapping.Map<UpdateEnd_of_3phasesReportDto, End_of_3phasesReport>(record);
            await _context.End_of_3phasesReports.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

    }
}
