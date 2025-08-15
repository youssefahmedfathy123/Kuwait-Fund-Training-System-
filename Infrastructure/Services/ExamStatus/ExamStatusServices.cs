using Application;
using Application.EntitiesOperations.ExamStatus;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ExamStatusServices : IExamStatusServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public ExamStatusServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateExamStatusDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateExamStatusDto, ExamStatus>(input);

            await _context.ExamStatuses.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.ExamStatuses.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<ExamStatusDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.ExamStatuses.ToListAsync();

            return _mapping.Map<List<ExamStatus>, List<ExamStatusDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateExamStatusDto input, CancellationToken cancletionToken)
        {
            var table = await _context.ExamStatuses.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateExamStatusDto, ExamStatus>(input);
            await _context.ExamStatuses.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }


        public async Task<List<Trainee>> TopTwo(Guid Id, CancellationToken cancletionToken)
        {
            var topTwo = await _context.ExamStatuses
               .Where(es => es.Trainee.GroupId == Id)
               .OrderBy(es => es.Grade)
               .Select(es => es.Trainee)
               .Take(2)
               .ToListAsync();

            return topTwo;

        }

    }
}
