using Application;
using Application.EntitiesOperations.Leave;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class LeaveServices : ILeaveServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public LeaveServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(IFormFile? file, LeavePropertiesWithoutPdf leave
            , CancellationToken cancletionToken)
        {

            if (file.ContentType != "application/pdf")
                return "I need pdf only!";

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

            var record = new CreateLeaveDto(
                leave.TraineeId,fileBytes,leave.Kind,leave.Status,leave.Start,leave.NumberOfDays
                );

            var newRec = _mapping.Map<CreateLeaveDto, Leave>(record);

            await _context.Leaves.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Leaves.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<LeaveDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Leaves.ToListAsync();

            return _mapping.Map<List<Leave>, List<LeaveDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateLeaveFileDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Leaves.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            if (input.file.ContentType != "application/pdf")
                return "I need pdf only!";

            using var memoryStream = new MemoryStream();
            await input.file.CopyToAsync(memoryStream, cancletionToken);
            byte[] fileBytes = memoryStream.ToArray();

            var record = new UpdateLeaveDto(input.Id, input.TraineeId, fileBytes, input.Kind, input.Status,
                input.Start, input.NumberOfDays);

            var res = _mapping.Map<UpdateLeaveDto, Leave>(record);
            await _context.Leaves.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }



        public async Task<Result<string>> Approve(
            [FromForm] Guid LeaveId,
            [FromForm] LeaveStatus status,
            CancellationToken cancellationToken = default)
        {
            var recod = await _context.Leaves
                .Include(l => l.Trainee)
                    .ThenInclude(t => t.Group)
                        .ThenInclude(g => g.Batch)
                .FirstOrDefaultAsync(l => l.Id == LeaveId, cancellationToken);

            if (recod == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {LeaveId} is not found"));



            if (status == LeaveStatus.Pending)
                return Result.Failure<string>(new Error("Pending??", "Can't be pending!"));



            var phase = recod.Trainee?.Group?.Batch?.Phase;


            if (phase == null)
                return Result.Failure<string>(new Error("INVALID_DATA", "Phase information is missing"));



            if (status == LeaveStatus.Approved)
            {
                switch (recod.Kind)
                {
                    case KindOfLeave.Sick:
                        if (phase == Phase.AcademicTrainingInKuwait) // Ph1
                            recod.Trainee?.AggrementSickLeavePhase1(recod.NumberOfDays);

                        if (phase == Phase.FieldTrainingAbroad) // Ph2
                            recod.Trainee?.AggrementSickLeavePhase2(recod.NumberOfDays);
                        break;

                    case KindOfLeave.Normal:
                        if (phase == Phase.AcademicTrainingInKuwait)
                            return Result.Failure<string>(new Error("NOTVALID", "Not valid"));

                        if (phase == Phase.FieldTrainingAbroad)
                            recod.Trainee?.AggrementNormalLeavePhase2(recod.NumberOfDays);
                        break;
                }

                recod.Approved();
            }
            else
            {
                recod.Rejected();
            }

            return Result.Success("Success operation!");
        }




        public async Task<Leave> FindById(Guid id, CancellationToken cancletionToken)
        {
            Leave cer = await _context.Leaves.FirstOrDefaultAsync(x => x.Id == id, cancletionToken);

            return cer;
        }

    }

}

