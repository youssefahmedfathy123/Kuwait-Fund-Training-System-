using Application;
using Application.EntitiesOperations.Waiting;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class WaitingServices : IWaitingServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public WaitingServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateWaitingDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateWaitingDto, Waiting>(input);

            await _context.Waitings.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.Name;
        }

        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Waitings.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<WaitingDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Waitings.ToListAsync();

            return _mapping.Map<List<Waiting>, List<WaitingDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateWaitingDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Waitings.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateWaitingDto, Waiting>(input);
            await _context.Waitings.AddAsync(res);

            return Result.Success(res.Name);
        }

    }
}


