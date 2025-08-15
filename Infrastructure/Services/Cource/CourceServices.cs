using Application.EntitiesOperations.Cource;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CourceServices : ICourceServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public CourceServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateCourceDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateCourceDto, Cource>(input);

            await _context.Cources.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.Name;
        }



        public async Task<Result<Guid>> Delete(DeleteCource input, CancellationToken cancletionToken)
        {
            var table = await _context.Cources.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<CourceDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Cources.ToListAsync();

            return _mapping.Map<List<Cource>, List<CourceDto>>(table);
        }


        public async Task<Result<string>> Update(EditCourceDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Cources.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<EditCourceDto, Cource>(input);
            await _context.Cources.AddAsync(res);

            return Result.Success(res.Name);
        }
    }
}



