using Application;
using Application.EntitiesOperations.Schedual;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class SchedualServices : ISchedualServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public SchedualServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateSchedualDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateSchedualDto, Schedual>(input);

            await _context.Scheduals.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Scheduals.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<SchedualDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Scheduals.ToListAsync();

            return _mapping.Map<List<Schedual>, List<SchedualDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateSchedualDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Scheduals.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateSchedualDto, Schedual>(input);
            await _context.Scheduals.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

    }
}


