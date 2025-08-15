using Application.EntitiesOperations.Trainee;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class TraineeServices : ITraineeServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public TraineeServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateTraineeDto input, CancellationToken cancellationToken)
        {
            var newRec = _mapping.Map<CreateTraineeDto, Trainee>(input);

            await _context.Trainees.AddAsync(newRec);

            await _context.SaveChangesAsync(cancellationToken);
            return newRec.Name;

        }

        public async Task<Result<Guid>> Delete(DeleteTrainee input, CancellationToken cancellationToken)
        {
            var table = await _context.Trainees.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            _context.Trainees.Remove(table);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success(table.Id);

        }

        public async Task<List<TraineeDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Trainees.ToListAsync();

            return _mapping.Map<List<Trainee>, List<TraineeDto>>(table);
        }


        public async Task<Result<string>> Update(EditTraineeDto input, CancellationToken cancellationToken)
        {
            var table = await _context.Trainees.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<EditTraineeDto, Trainee>(input);
            await _context.Trainees.AddAsync(res);

            return Result.Success(res.Name);

        }

    }
}
