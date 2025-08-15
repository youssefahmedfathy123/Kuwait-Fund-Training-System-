using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace Application.EntitiesOperations.Withdrawal;

    public record UpdateWithdrawalDto(
        Guid Id,
        string UserId,
        Reason Reason,
        byte[]? MedicalReport,
        LeaveStatus Status,
        DateTime At,
        DateTime Start,
        DateTime? End
        );

public record UpdateWithdrawalFileDto(
        Guid Id,
        string UserId,
        Reason Reason,
        IFormFile MedicalReport,
        LeaveStatus Status,
        DateTime At,
        DateTime Start,
        DateTime? End
        );



