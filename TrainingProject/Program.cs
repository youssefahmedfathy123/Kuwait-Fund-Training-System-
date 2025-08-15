using Application.Abstractions.Auth;
using Application.Abstractions.Auth.RoleManagerS;
using Application.Abstractions.Auth.UserManagerS;
using Application.Abstractions.Email.Application.Abstractions.Email;
using Application.Abstractions.RoleUpgradeRequest;
using Application.Auth.Commands.Registeration;
using Application.Common;
using Application.EntitiesOperations;
using Application.EntitiesOperations.Attendance;
using Application.EntitiesOperations.Bi_weeklyReport;
using Application.EntitiesOperations.Cource;
using Application.EntitiesOperations.End_of_3phasesReport;
using Application.EntitiesOperations.Evaluation;
using Application.EntitiesOperations.Exam;
using Application.EntitiesOperations.ExamStatus;
using Application.EntitiesOperations.Excuses;
using Application.EntitiesOperations.Feedback;
using Application.EntitiesOperations.Fine;
using Application.EntitiesOperations.Honor;
using Application.EntitiesOperations.Leave;
using Application.EntitiesOperations.Message;
using Application.EntitiesOperations.PreferedCompanies;
using Application.EntitiesOperations.Schedual;
using Application.EntitiesOperations.Trainee;
using Application.EntitiesOperations.Trainer;
using Application.EntitiesOperations.Waiting;
using Application.EntitiesOperations.Withdrawal;
using Application.Interfaces;
using Application.Mapping;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Helper;
using Infrastructure.Persistence.Seed;
using Infrastructure.Persistence.Seed.Const;
using Infrastructure.Services;
using Infrastructure.Services.Email;
using Infrastructure.Services.HrSystem;
using Infrastructure.Services.Identity;
using Infrastructure.Services.Identity.RoleManagerS;
using Infrastructure.Services.Identity.UserManagerS;
using Infrastructure.Services.RoleUpgradeRequests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHttpContextAccessor();

// SMTP
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddScoped<IEmailServices, EmailServices>();

// JWT Settings
var jwtSettings = builder.Configuration.GetSection("JWT");
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["key"]))
    };
});

builder.Services.AddScoped<IJwt, Jwt>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(RegisterCommand).Assembly);
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Training"));
});

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(options =>
{
    var allPermissions = Permissions.GenerateAllPermissions();
    foreach (var permission in allPermissions)
    {
        options.AddPolicy(permission, policy =>
            policy.RequireClaim("Permission", permission));
    }
});

builder.Services.AddScoped<IAuthServices, AuthServices>();
builder.Services.AddScoped<IRoleManagerServices, RoleManagerServices>();
builder.Services.AddScoped<IUserManagerServices, UserManagerServices>();
builder.Services.AddScoped<IRoleUpgradeRequestServices, RoleUpgradeRequestServices>();
builder.Services.AddScoped<IEmailServices, EmailServices>();
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
builder.Services.AddScoped<IExternalAuthService, ExternalAuthService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IHrsystemServices, HrsystemServices>();
builder.Services.AddScoped<IGroupServices, GroupServicesn>();
builder.Services.AddScoped<IBatchServices, BatchServices>();
builder.Services.AddScoped<ICompanyServices, CompanyServices>();
builder.Services.AddScoped<ITrainerServices, TrainerServices>();
builder.Services.AddScoped<ITraineeServices, TraineeServices>();
builder.Services.AddScoped<ICertificateServices, CertificateServices>();
builder.Services.AddScoped<IAttendanceServices, AttendanceServices>();
builder.Services.AddScoped<IBi_weeklyReportServices, Bi_weeklyReportServices>();
builder.Services.AddScoped<ICourceServices, CourceServices>();
builder.Services.AddScoped<IEnd_of_3phasesReportServices, End_of_3phasesReportServices>();
builder.Services.AddScoped<IEvaluationServices, EvaluationServices>();
builder.Services.AddScoped<IExamServices, ExamServices>();
builder.Services.AddScoped<IExamStatusServices, ExamStatusServices>();
builder.Services.AddScoped<IExcusesServices, ExcusesServices>();
builder.Services.AddScoped<IFeedbackServices, FeedbackServices>();
builder.Services.AddScoped<IFineServices, FineServices>();
builder.Services.AddScoped<IHonorServices, HonorServices>();
builder.Services.AddScoped<ILeaveServices, LeaveServices>();
builder.Services.AddScoped<IMessageServices, MessageServices>();
builder.Services.AddScoped<IPreferedCompaniesServices, PreferedCompaniesServices>();
builder.Services.AddScoped<ISchedualServices, SchedualServices>();
builder.Services.AddScoped<IWaitingServices, WaitingServices>();
builder.Services.AddScoped<IWithdrawalServices, WithdrawalServices>();

builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

var app = builder.Build();

// Seeding
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<User>>();

    await DefaultRoles.SeedAsync(roleManager);
    await DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
