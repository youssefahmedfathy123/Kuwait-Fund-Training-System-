using Application;
using Application.EntitiesOperations.PreferedCompanies;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class PreferedCompaniesServices : IPreferedCompaniesServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public PreferedCompaniesServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }
        
        public async Task<string> Create(CreatePreferedCompaniesDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreatePreferedCompaniesDto, PreferedCompanies>(input);

            await _context.PreferedCompanies.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.PreferedCompanies.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<PreferedCompaniesDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.PreferedCompanies.ToListAsync();

            return _mapping.Map<List<PreferedCompanies>, List<PreferedCompaniesDto>>(table);
        }


        public async Task<Result<string>> Update(UpdatePreferedCompaniesDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Cources.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdatePreferedCompaniesDto, PreferedCompanies>(input);
            await _context.PreferedCompanies.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

    }
}

