using Application;
using Application.EntitiesOperations.Excuses;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class ExcusesServices : IExcusesServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExcusesServices(ApplicationDbContext context, IMapper mapping, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapping = mapping;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<string> Create(CreateExcusesFileDto input, CancellationToken cancletionToken)
        {
            if (input.file.ContentType != "application/pdf")
                return "I need pdf only!";


            using var memoryStream = new MemoryStream();
            await input.file.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

             var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var record = new CreateExcusesDto(input.AttendanceId,userId,fileBytes,input.Aggrement);

            var newRec = _mapping.Map<CreateExcusesDto, Excuses>(record);

            await _context.Excuses.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Excuses.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<ExcusesDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Excuses.ToListAsync();

            return _mapping.Map<List<Excuses>, List<ExcusesDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateExcusesFileDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Excuses.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            if (input.file.ContentType != "application/pdf")
                return "I need pdf only!";


            using var memoryStream = new MemoryStream();
            await input.file.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;


        var record = new UpdateExcusesDto(input.Id,input.AttendanceId, userId, fileBytes, input.Aggrement);

            var res = _mapping.Map<UpdateExcusesDto, Excuses>(record);
            await _context.Excuses.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }


        public async Task<Result<string>> ApproveOrReject(Guid ExcusesId, Aggrement status, CancellationToken cancletionToken)
        {
            var record = await _context.Excuses.FindAsync(ExcusesId);
            if (record == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {ExcusesId} is not found"));


            switch (status)
            {
                case Aggrement.Pending:
                    return Result.Failure<string>(new Error("Pending??", "Catn't be pending"));

                case Aggrement.Accepted:
                    record.Accepted();
                    break;

                case Aggrement.NotAccepted:
                    record.NotAccepted();
                    break;
            }

            return Result.Success(record.CreatedBy);
        }


    }
}
