using Application.Common;
using Application.EntitiesOperations.HrSystem.Command.Create;
using Application.EntitiesOperations.HrSystem.Command.Delete;
using Application.EntitiesOperations.HrSystem.Command.Update;
using Application.EntitiesOperations.HrSystem.Query.Read;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.HrSystem
{
    public sealed class HrsystemServices : IHrsystemServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public HrsystemServices(ApplicationDbContext context, IMapper mappimg)
        {
            _context = context;
            _mapping = mappimg; 
        }

        public async Task<Result<Guid>> Create(CreateHrDto input,CancellationToken cancellationToken)
        {
            var newRecord = _mapping.Map<CreateHrDto,Hr>(input);
             _context.Add(newRecord);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success(newRecord.Id);

        }



        public async Task<Result<string>> Delete(DeleteFromHrSystem input, CancellationToken cancellationToken)
        {
            Console.WriteLine("Id is :::: " + input.Id);
            var findornot = await _context.Hrs.FindAsync(input.Id);

            if (findornot is null)
                return Result.Failure<string>(new Error("idNotFound", "Id u inserted is not found"));

                
            _context.Hrs.Remove(findornot);

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success(findornot.NationalId);
        }

        public async Task<List<HrDto>> Read()
        {
            var All =  await _context.Hrs.ToListAsync();
            return _mapping.Map<List<Hr>,List<HrDto>>(All);

        }

        public async Task<Result<string>> Update(EditHrDto input, CancellationToken cancellationToken)
        {

            var findornot = await _context.Hrs.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == input.Id);

            if (findornot is null)
                return Result.Failure<string>(new Error("idNotFound", "Id u inserted is not found"));

            var Record = _mapping.Map<EditHrDto, Hr>(input);

            _context.Update(Record);

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success(Record.NationalId);

        }
    }
}



