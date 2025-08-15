using Application;
using Application.EntitiesOperations.Bi_weeklyReport;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class Bi_weeklyReportServices : IBi_weeklyReportServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;
        private readonly IHttpContextAccessor _http;
        private readonly UserManager<User> _user;

        public Bi_weeklyReportServices(ApplicationDbContext context, IMapper mapping, IHttpContextAccessor http, UserManager<User> user)
        {
            _context = context;
            _mapping = mapping;
            _http = http;
            _user = user;
        }
        
        public async Task<string> Create([FromForm] CreateBi_weeklyReportDtoWithoutPdfAndUserIdDto input, CancellationToken cancletionToken)
        {
            var userId = _http.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (input.file.ContentType != "application/pdf")
                return "I need pdf only!";

            using var memoryStream = new MemoryStream();
            await input.file.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

            var record = new CreateBi_weeklyReportDto(userId,input.WeekNumberOfPhase,input.StartDateOf2Weekes,fileBytes);

            var newRec = _mapping.Map<CreateBi_weeklyReportDto, Bi_weeklyReport>(record);

            await _context.Bi_WeeklyReports.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Attendances.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<Bi_weeklyReportDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Bi_WeeklyReports.ToListAsync();

            return _mapping.Map<List<Bi_weeklyReport>, List<Bi_weeklyReportDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateBi_weeklyReportFileDto input, CancellationToken cancletionToken)
        {

            var table = await _context.Bi_WeeklyReports.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            var userId = _http.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (input.file.ContentType != "application/pdf")
                return "I need pdf only!";

            using var memoryStream = new MemoryStream();
            await input.file.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

            var record = new UpdateBi_weeklyReportDto(input.Id,userId, input.WeekNumberOfPhase, input.StartDateOf2Weekes, fileBytes);


            var res = _mapping.Map<UpdateBi_weeklyReportDto, Bi_weeklyReport>(record);
            await _context.Bi_WeeklyReports.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

        public async Task<Bi_weeklyReport> FindById(Guid id, CancellationToken cancletionToken)
        {
            Bi_weeklyReport cer = await _context.Bi_WeeklyReports.FirstOrDefaultAsync(x => x.Id == id, cancletionToken);

            return cer;
        }

    }
}



