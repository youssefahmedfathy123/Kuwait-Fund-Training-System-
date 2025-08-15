using Application.Common;
using Domain.Entities;
using Domain.Entities.role;
using Domain.Primitives;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure
{
    public class ApplicationDbContext  : IdentityDbContext<User>
    {

        private readonly IDomainEventDispatcher _dispatcher;
        private readonly ICurrentUserService _currentUserService;


        public ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    ICurrentUserService currentUserService, IDomainEventDispatcher dispatcher)
    : base(options)
        {
            _currentUserService = currentUserService;
            _dispatcher = dispatcher;
        }



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var entries = ChangeTracker.Entries<Aditable<Guid>>();


            var currentUser = _currentUserService.UserName ?? "System";

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = currentUser;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.EditedAt = DateTime.UtcNow;
                    entry.Entity.EditedBy = currentUser;
                }
            }



            var aggregatesWithEvents = ChangeTracker
                .Entries<AggragateRoot<Guid>>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity)
                .ToList();


            await _dispatcher.DispatchDomainEventsAsync(aggregatesWithEvents, cancellationToken);


            return await base.SaveChangesAsync(cancellationToken); 
        }

        #region
        //public DbSet<Certificate> Certificates { get; set; }
        //public DbSet<CourceEvaluation> CourceEvaluations { get; set; }
        //public DbSet<FieldReport> FieldReports { get; set; }
        //public DbSet<LeaveRequest> LeaveRequests { get; set; }
        //public DbSet<Message> Messages { get; set; }
        //public DbSet<TrainerEvaluation> TrainerEvaluations { get; set; }
        //public DbSet<WithDrawal> withDrawals { get; set; }
        #endregion
        public DbSet<RoleUpgradeRequest> RoleUpgradeRequests { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Cource> Cources { get; set; }
        public DbSet<Hr> Hrs { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Schedual> Scheduals { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamStatus> ExamStatuses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Withdrawal> withdrawals { get; set; }
        public DbSet<Honor> Honors { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Excuses> Excuses { get; set; }
        public DbSet<PreferedCompanies> PreferedCompanies { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<End_of_3phasesReport> End_of_3phasesReports { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Waiting> Waitings { get; set; }
        public DbSet<Bi_weeklyReport> Bi_WeeklyReports { get; set; }
        public DbSet<Leave> Leaves { get; set; }












        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }



    }
}




