using Application;
using Application.EntitiesOperations.Cource;
using Application.EntitiesOperations.Honor;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class HonorServices : IHonorServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public HonorServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateHonorDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateHonorDto, Honor>(input);

            await _context.Honors.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Honors.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<HonorDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Honors.ToListAsync();

            return _mapping.Map<List<Honor>, List<HonorDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateHonorDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Honors.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateHonorDto, Honor>(input);
            await _context.Honors.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

    }
}



