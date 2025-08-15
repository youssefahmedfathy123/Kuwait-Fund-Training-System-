using Application;
using Application.EntitiesOperations.Withdrawal;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class WithdrawalServices : IWithdrawalServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;
        private readonly IHttpContextAccessor _http;

        public WithdrawalServices(ApplicationDbContext context, IMapper mapping, IHttpContextAccessor http)
        {
            _context = context;
            _mapping = mapping;
            _http = http;
        }

        public async Task<string> Create(CreateWithdrawalFileDto input, CancellationToken cancletionToken)
        {

            if (input.MedicalReport.ContentType != "application/pdf")
                return "I need pdf only!";

            using var memoryStream = new MemoryStream();
            await input.MedicalReport.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();
            var userId = _http.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var record = new CreateWithdrawalDto(
                             userId,
                            input.Reason,
                            fileBytes,
                            input.Status,
                            input.At,
                            input.Start,
                            input?.End  );


            var newRec = _mapping.Map<CreateWithdrawalDto, Withdrawal>(record);

            await _context.withdrawals.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.withdrawals.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<WithdrawalDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.withdrawals.ToListAsync();

            return _mapping.Map<List<Withdrawal>, List<WithdrawalDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateWithdrawalFileDto input, CancellationToken cancletionToken)
        {
            var table = await _context.withdrawals.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            if (input.MedicalReport.ContentType != "application/pdf")
                return "I need pdf only!";

            using var memoryStream = new MemoryStream();
            await input.MedicalReport.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

            var userId = _http.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var record = new UpdateWithdrawalDto(
                             input.Id ,
                             userId,
                            input.Reason,
                            fileBytes,
                            input.Status,
                            input.At,
                            input.Start,
                            input?.End);


            var res = _mapping.Map<UpdateWithdrawalDto, Withdrawal>(record);
            await _context.withdrawals.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

        public async Task<Result<string>> ApproveOrReject(Guid WithdrawalId,LeaveStatus status, CancellationToken cancletionToken)
        {
            var record = await _context.withdrawals.FindAsync(WithdrawalId);
            if(record == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {WithdrawalId} is not found"));


            switch (status)
            {
                case LeaveStatus.Pending:
                        return Result.Failure<string>(new Error("Pending??", "Catn't be pending"));

                    case LeaveStatus.Approved:
                        record.Approve();
                    break;

                case LeaveStatus.Rejected:
                        record.Reject(); 
                    break;
            }

            return Result.Success(record.CreatedBy);
        }




    }
}



