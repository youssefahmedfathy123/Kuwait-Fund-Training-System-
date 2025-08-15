using Application.EntitiesOperations.Group.Command;
using Application.EntitiesOperations.Group.Query;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class GroupServicesn : IGroupServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public GroupServicesn(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateGroupDto input, CancellationToken cancellationToken)
        {
            var newRec = _mapping.Map<CreateGroupDto, Group>(input);

            await _context.Groups.AddAsync(newRec);

            await _context.SaveChangesAsync(cancellationToken);
            return newRec.Name;

        }

        public async Task<Result<Guid>> Delete(DeleteGroup input, CancellationToken cancellationToken)
        {
            var table = await _context.Groups.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            _context.Groups.Remove(table);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success(table.Id);

        }

        public async Task<List<GroupDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Groups.ToListAsync();

            return _mapping.Map<List<Group>, List<GroupDto>>(table);
        }


        public async Task<Result<string>> Update(EditGroupDto input, CancellationToken cancellationToken)
        {
            var table = await _context.Groups.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<EditGroupDto, Group>(input);
            await _context.Groups.AddAsync(res);

            return Result.Success(res.Name);

        }
    }
}


