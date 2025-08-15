using Application;
using Application.EntitiesOperations.Message;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class MessageServices : IMessageServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public MessageServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }
        
        public async Task<string> Create(CreateMessageDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateMessageDto, Message>(input);

            await _context.Messages.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Messages.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<MessageDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Messages.ToListAsync();

            return _mapping.Map<List<Message>, List<MessageDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateMessageDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Messages.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateMessageDto, Message>(input);
            await _context.Messages.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

        }
    }

