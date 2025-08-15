using Application;
using Application.EntitiesOperations.Exam;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ExamServices : IExamServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public ExamServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateExamDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateExamDto, Exam>(input);

            await _context.Exams.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Exams.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }


        public async Task<List<ExamDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Exams.ToListAsync();

            return _mapping.Map<List<Exam>, List<ExamDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateExamDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Exams.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateExamDto, Exam>(input);
            await _context.Exams.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

    }
}
