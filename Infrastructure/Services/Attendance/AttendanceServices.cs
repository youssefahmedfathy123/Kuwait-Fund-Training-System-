using Application;
using Application.EntitiesOperations.Attendance;
using Application.EntitiesOperations.Cource;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Primitives;
using Gatherly.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AttendanceServices : IAttendanceServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapping;

        public AttendanceServices(ApplicationDbContext context, IMapper mapping)
        {
            _context = context;
            _mapping = mapping;
        }
        
        public async Task<string> Create(CreateAttendanceDto input, CancellationToken cancletionToken)
        {
            var newRec = _mapping.Map<CreateAttendanceDto, Attendance>(input);

            await _context.Attendances.AddAsync(newRec);

            await _context.SaveChangesAsync(cancletionToken);
            return newRec.CreatedBy;
        }

        public async Task<Result<Guid>> Delete(DeleteTable input, CancellationToken cancletionToken)
        {
            var table = await _context.Attendances.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<Guid>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));

            table.IsDeleted = true;
            await _context.SaveChangesAsync(cancletionToken);
            return Result.Success(table.Id);
        }

        public async Task<List<AttendanceDto>> Read(CancellationToken cancletionToken)
        {
            var table = await _context.Attendances.ToListAsync();

            return _mapping.Map<List<Attendance>, List<AttendanceDto>>(table);
        }
  
        public async Task<Result<string>> Update(UpdateAttendanceDto input, CancellationToken cancletionToken)
        {
            var table = await _context.Attendances.FindAsync(input.Id);
            if (table == null)
                return Result.Failure<string>(new Error("NOTFOUND", $"Record with {input.Id} is not found"));


            var res = _mapping.Map<UpdateAttendanceDto, Attendance>(input);
            await _context.Attendances.AddAsync(res);

            return Result.Success(res.CreatedBy);
        }




        // If Attendance > 10%
        public async Task<string> Check10percentageAttendance(Guid courceId, CancellationToken cancellationToken)
        {
            var course = await _context.Cources
                .FirstOrDefaultAsync(c => c.Id == courceId, cancellationToken);

            if (course == null)
                return "Course not found.";

            var totalCourseHours = course.Credits;
            if (totalCourseHours == 0)
                return "Course credits are zero.";

            var attendances = await _context.Attendances
                .Include(a => a.Schedual)
                .Include(a => a.Trainee) 
                .Where(a => a.Schedual.CourseId == courceId)
                .ToListAsync(cancellationToken);

            var groupedByTrainee = attendances.GroupBy(a => a.Trainee);

            var result = new List<string>();

            foreach (var traineeGroup in groupedByTrainee)
            {
                var absentHours = traineeGroup
                    .Where(a => a.Status == AttendanceStatus.Absent)
                    .Sum(a => a.Schedual.Credits);

                var absencePercentage = (decimal)absentHours / totalCourseHours * 100;

                if (absencePercentage > 10)
                {
                    traineeGroup.Key.ChangePassStatus(PassStatus.Failed);
                    result.Add($"Trainee {traineeGroup.Key.Name} FAILED with {absencePercentage:F2}% absence");
                }
                else
                {
                    result.Add($"Trainee {traineeGroup.Key.Name} PASSED with {absencePercentage:F2}% absence");
                }
            }

            return string.Join(Environment.NewLine, result);
        }

    }
}




