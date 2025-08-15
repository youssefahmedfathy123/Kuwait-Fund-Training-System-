using Application;
using Application.EntitiesOperations.Evaluation;
using AutoMapper;
using Domain.Entities;
using Gatherly.Domain.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading;

namespace Infrastructure.Services
{
    public class EvaluationServices : IEvaluationServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;



        public EvaluationServices(ApplicationDbContext context, IMapper mapping,IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _context = context;
            _mapping = mapping;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        
        public async Task<string> Create(CreateEvaluationDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateEvaluationDto, Evaluation>(input);

            await _context.Evaluations.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }



        public async Task<string> AddOrEditExamResult(int Id,int value, CancellationToken cancletionToken)
        {
            try
            {
                var table = await _context.Evaluations.FindAsync(Id);
                table.AddOrEditExamResult(value);
                return "Susccess";
            }
            catch
            {
                return "Failed";
            }
        }




        public async Task<string> AddOrEditEvaluation(int Id,int value, CancellationToken cancletionToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User
            ?.FindFirst(ClaimTypes.NameIdentifier)?.Value;



            var user = await _userManager.FindByIdAsync(userId);

            try
            {
                var table = await _context.Evaluations.FindAsync(Id);

                table.AddOrEditEvaluation(user.Role.Value, value);
                return "Susccess";
            }
            catch
            {
                return "Failed";
            }
        }
        


        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Evaluations.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<EvaluationDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Evaluations.ToListAsync();

            return _mapping.Map<List<Evaluation>, List<EvaluationDto>>(table);
        }


        public async Task<Result<string>> Update(UpdateEvaluationDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Cources.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateEvaluationDto, Evaluation>(input);
            await _context.Evaluations.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }


        // If totalScore < 70 
        public async Task<Result<string>> CheckTotalScore(CancellationToken cancellationToken)
        {
            try
            {
                var failedTrainees = await _context.Evaluations
                    .Where(e => e.FinalScore < 70)
                    .Select(e => e.Trainee)
                    .ToListAsync(cancellationToken);

                foreach (var trainee in failedTrainees)
                {
                    trainee.ChangePassStatus(PassStatus.Failed);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return Result.Success("Ok");
            }
            catch (Exception ex)
            {
                return Result.Failure<string>(new Error("Failed::", ex.Message));
            }
        }

    }
}


