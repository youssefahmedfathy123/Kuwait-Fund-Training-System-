using Application;
using Application.EntitiesOperations.Cource;
using Application.EntitiesOperations.Fine;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class FineServices : IFineServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public FineServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateFineDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateFineDto, Fine>(input);

            await _context.Fines.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Fines.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<FineDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Fines.ToListAsync();

            return _mapping.Map<List<Fine>, List<FineDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateFineDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Cources.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateFineDto, Fine>(input);
            await _context.Fines.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

    }
}

