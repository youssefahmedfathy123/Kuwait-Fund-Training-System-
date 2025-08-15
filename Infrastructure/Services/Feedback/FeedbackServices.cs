using Application;
using Application.EntitiesOperations.Feedback;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;
        
        public FeedbackServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }

        public async Task<string> Create(CreateFeedbackDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateFeedbackDto,Feedback>(input);

            await _context.Feedbacks.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Feedbacks.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<FeedbackDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Feedbacks.ToListAsync();

            return _mapping.Map<List<Feedback>, List<FeedbackDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateFeedbackDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Feedbacks.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateFeedbackDto, Feedback>(input);
            await _context.Feedbacks.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }

    }
}


