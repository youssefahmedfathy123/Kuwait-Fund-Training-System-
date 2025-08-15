using Application.EntitiesOperations.Trainer;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class TrainerServices : ITrainerServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public TrainerServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateTrainerDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateTrainerDto, Trainer>(input);

            await _context.Trainers.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.Name;
        }

        public async Task<Result<Guid>> Delete(DeleteTrainer input, CancellationToken cancletionToken)
        {
            var table = await _context.Trainers.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);

        }

        public async Task<List<TrainerDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Trainers.ToListAsync();

            return _mapping.Map<List<Trainer>, List<TrainerDto>>(table);
        }

        public async Task<Result<string>> Update(UpdateTrainerDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Trainers.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateTrainerDto, Trainer>(input);
            await _context.Trainers.AddAsync(res);

            return Result.Success(res.Name);
        }
    }
}


