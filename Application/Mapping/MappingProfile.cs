using Application.EntitiesOperations;
using Application.EntitiesOperations.Attendance;
using Application.EntitiesOperations.Batch.Command;
using Application.EntitiesOperations.Batch.Query;
using Application.EntitiesOperations.Bi_weeklyReport;
using Application.EntitiesOperations.Certificate;
using Application.EntitiesOperations.Company.Command;
using Application.EntitiesOperations.Company.Query;
using Application.EntitiesOperations.End_of_3phasesReport;
using Application.EntitiesOperations.Evaluation;
using Application.EntitiesOperations.Exam;
using Application.EntitiesOperations.ExamStatus;
using Application.EntitiesOperations.Excuses;
using Application.EntitiesOperations.Feedback;
using Application.EntitiesOperations.Fine;
using Application.EntitiesOperations.Group.Command;
using Application.EntitiesOperations.Group.Query;
using Application.EntitiesOperations.Honor;
using Application.EntitiesOperations.HrSystem.Command.Create;
using Application.EntitiesOperations.HrSystem.Command.Update;
using Application.EntitiesOperations.HrSystem.Query.Read;
using Application.EntitiesOperations.Leave;
using Application.EntitiesOperations.Message;
using Application.EntitiesOperations.PreferedCompanies;
using Application.EntitiesOperations.Schedual;
using Application.EntitiesOperations.Trainee;
using Application.EntitiesOperations.Trainer;
using Application.EntitiesOperations.Waiting;
using Application.EntitiesOperations.Withdrawal;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Hr
            CreateMap<Hr, HrDto>().ReverseMap();
            CreateMap<Hr, CreateHrDto>().ReverseMap();
            CreateMap<Hr, EditHrDto>().ReverseMap();


            // Batch
            CreateMap<Domain.Entities.Batch, CreateBatchDto>().ReverseMap();
            CreateMap<Domain.Entities.Batch, EditBatchDto>().ReverseMap();
            CreateMap<Domain.Entities.Batch, BatchDto>().ReverseMap();



            // Company
            CreateMap<Domain.Entities.Company, CompanyDto>().ReverseMap();
            CreateMap<Domain.Entities.Company,CreateCompanyDto>().ReverseMap();
            CreateMap<Domain.Entities.Company, EditCompanyDto>().ReverseMap();



            // Group
            CreateMap<Domain.Entities.Group, GroupDto>().ReverseMap();
            CreateMap<Domain.Entities.Group, CreateGroupDto>().ReverseMap();
            CreateMap<Domain.Entities.Group, EditGroupDto>().ReverseMap();



            //  Attendance
            CreateMap<Domain.Entities.Attendance, AttendanceDto>().ReverseMap();
            CreateMap<Domain.Entities.Attendance, CreateAttendanceDto>().ReverseMap();
            CreateMap<Domain.Entities.Attendance, UpdateAttendanceDto>().ReverseMap();


            //Bi_weeklyReport
            CreateMap<Domain.Entities.Bi_weeklyReport, Bi_weeklyReportDto>().ReverseMap();
            CreateMap<Domain.Entities.Bi_weeklyReport, CreateBi_weeklyReportDto>().ReverseMap();
            CreateMap<Domain.Entities.Bi_weeklyReport, UpdateBi_weeklyReportDto>().ReverseMap();

            

            //Certificate
            CreateMap<Domain.Entities.Certificate, CertificateDto>().ReverseMap();
            CreateMap<Domain.Entities.Certificate, CreateCertificateDto>().ReverseMap();
            CreateMap<Domain.Entities.Certificate, UpdateCertificateDto>().ReverseMap();




            //End_of_3phasesReport
            CreateMap<Domain.Entities.End_of_3phasesReport, End_of_3phasesReportDto>().ReverseMap();
            CreateMap<Domain.Entities.End_of_3phasesReport, CreateEnd_of_3phasesReportDto>().ReverseMap();
            CreateMap<Domain.Entities.End_of_3phasesReport, UpdateEnd_of_3phasesReportDto>().ReverseMap();




            //Evaluation
            CreateMap<Domain.Entities.Evaluation, EvaluationDto>().ReverseMap();
            CreateMap<Domain.Entities.Evaluation, CreateEvaluationDto>().ReverseMap();
            CreateMap<Domain.Entities.Evaluation, UpdateEvaluationDto>().ReverseMap();




            //Exam
            CreateMap<Domain.Entities.Exam, ExamDto>().ReverseMap();
            CreateMap<Domain.Entities.Exam, CreateExamDto>().ReverseMap();
            CreateMap<Domain.Entities.Exam, UpdateExamDto>().ReverseMap();




            //ExamStatus
            CreateMap<Domain.Entities.ExamStatus, ExamStatusDto>().ReverseMap();
            CreateMap<Domain.Entities.ExamStatus, CreateExamStatusDto>().ReverseMap();
            CreateMap<Domain.Entities.ExamStatus, UpdateExamDto>().ReverseMap();




            //Excuse
            CreateMap<Domain.Entities.Excuses, ExcusesDto>().ReverseMap();
            CreateMap<Domain.Entities.Excuses, CreateExcusesDto>().ReverseMap();
            CreateMap<Domain.Entities.Excuses, UpdateExcusesDto>().ReverseMap();





            //Feedback
            CreateMap<Domain.Entities.Feedback, FeedbackDto>().ReverseMap();
            CreateMap<Domain.Entities.Feedback, CreateFeedbackDto>().ReverseMap();
            CreateMap<Domain.Entities.Feedback, UpdateFeedbackDto>().ReverseMap();

            //Fine
            CreateMap<Domain.Entities.Fine, FineDto>().ReverseMap();
            CreateMap<Domain.Entities.Fine, CreateFineDto>().ReverseMap();
            CreateMap<Domain.Entities.Fine, UpdateFineDto>().ReverseMap();

            //Honor
            CreateMap<Domain.Entities.Honor, HonorDto>().ReverseMap();
            CreateMap<Domain.Entities.Honor, CreateHonorDto>().ReverseMap();
            CreateMap<Domain.Entities.Honor, UpdateHonorDto>().ReverseMap();

            //Message
            CreateMap<Domain.Entities.Message, MessageDto>().ReverseMap();
            CreateMap<Domain.Entities.Message, CreateMessageDto>().ReverseMap();
            CreateMap<Domain.Entities.Message, UpdateMessageDto>().ReverseMap();

            //PreferedCompanies
            CreateMap<Domain.Entities.PreferedCompanies, PreferedCompaniesDto>().ReverseMap();
            CreateMap<Domain.Entities.PreferedCompanies, CreatePreferedCompaniesDto>().ReverseMap();
            CreateMap<Domain.Entities.PreferedCompanies, UpdatePreferedCompaniesDto>().ReverseMap();



            //Schedule
            CreateMap<Domain.Entities.Schedual, SchedualDto>().ReverseMap();
            CreateMap<Domain.Entities.Schedual, CreateSchedualDto>().ReverseMap();
            CreateMap<Domain.Entities.Schedual, UpdateSchedualDto>().ReverseMap();




            //Trainee
            CreateMap<Domain.Entities.Trainee, TraineeDto>().ReverseMap();
            CreateMap<Domain.Entities.Trainee, CreateTraineeDto>().ReverseMap();
            CreateMap<Domain.Entities.Trainee, EditTraineeDto>().ReverseMap();


            //Trainer
            CreateMap<Domain.Entities.Trainer, TrainerDto>().ReverseMap();
            CreateMap<Domain.Entities.Trainer, CreateTrainerDto>().ReverseMap();
            CreateMap<Domain.Entities.Trainer, UpdateTrainerDto>().ReverseMap();

            //Waiting
            CreateMap<Domain.Entities.Waiting, WaitingDto>().ReverseMap();
            CreateMap<Domain.Entities.Waiting, CreateWaitingDto>().ReverseMap();
            CreateMap<Domain.Entities.Waiting, UpdateWaitingDto>().ReverseMap();

            //Withdrawal
            CreateMap<Domain.Entities.Withdrawal, WithdrawalDto>().ReverseMap();
            CreateMap<Domain.Entities.Withdrawal, CreateWithdrawalDto>().ReverseMap();
            CreateMap<Domain.Entities.Withdrawal, UpdateWithdrawalDto>().ReverseMap();

            // Leave
            CreateMap<Domain.Entities.Leave, CreateLeaveDto>().ReverseMap();
            CreateMap<Domain.Entities.Leave, LeaveDto>().ReverseMap();
            CreateMap<Domain.Entities.Leave, UpdateLeaveDto>().ReverseMap();


        }
    }
}


