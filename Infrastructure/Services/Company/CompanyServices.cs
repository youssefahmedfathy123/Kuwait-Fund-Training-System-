using Application;
using Application.EntitiesOperations.Company.Command;
using Application.EntitiesOperations.Company.Query;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public CompanyServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateCompanyDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateCompanyDto, Company>(input);

            await _context.Companies.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.Name;
        }



        public async Task<Result<string>> Delete(DeleteCompany input, CancellationToken cancletionToken)
        {
            var table = await _context.Companies.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.CreatedBy);
        }


        public async Task<List<CompanyDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Companies.ToListAsync();

            return _mapping.Map<List<Company>, List<CompanyDto>>(table);
        }


        public async Task<Result<string>> Update(EditCompanyDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Companies.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<EditCompanyDto, Company>(input);
            await _context.Companies.AddAsync(res);

            return Result.Success(res.Name);
        }

    }
}
