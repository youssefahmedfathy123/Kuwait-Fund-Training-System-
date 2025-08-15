using Application.EntitiesOperations.Batch.Command;
using Application.EntitiesOperations.Batch.Query;
using Application.EntitiesOperations.Company.Command;
using Application.EntitiesOperations.Company.Query;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class BatchServices : IBatchServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public BatchServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context; 
            _mapping = mapping;
        }

        public async Task<string> Create(CreateBatchDto input,CancellationToken cancellationToken)
        {
            var newRec = _mapping.Map<CreateBatchDto,Batch>(input);

            await _context.Batches.AddAsync(newRec);

            await _context.SaveChangesAsync(cancellationToken);
            return newRec.Name;

        }


        public async Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken)
        {
            var table = await _context.Batches.FindAsync(id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND",$"Record with {id} is not found"));

            _context.Batches.Remove(table);
            _context.SaveChangesAsync(cancellationToken);
            return Result.Success(table.Name);

        }

        public async Task<List<CompanyDto>> Read()
        {
            var table = await _context.Batches.ToListAsync();

            return _mapping.Map<List<Batch>,List<CompanyDto>>(table);
        }

        public async Task<Result<string>> Update(EditCompanyDto input, CancellationToken cancellationToken)
        {
            var table = await _context.Batches.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<EditCompanyDto,Batch>(input);
            await _context.Batches.AddAsync(res);

            return Result.Success(res.Name);

        }

        public Task<Result<string>> Update(EditBatchDto input, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task<List<BatchDto>> IBatchServices.Read()
        {
            throw new NotImplementedException();
        }
    }
}



