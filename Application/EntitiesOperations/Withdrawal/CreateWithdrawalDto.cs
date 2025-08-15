using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace Application.EntitiesOperations.Withdrawal;

public record CreateWithdrawalDto(
    string UserId,
    Reason Reason,
    byte[]? MedicalReport,
    LeaveStatus Status,
    DateTime At,
    DateTime Start,
    DateTime? End
    );

public record CreateWithdrawalFileDto(
    string UserId,
    Reason Reason,
    IFormFile? MedicalReport,
    LeaveStatus Status,
    DateTime At,
    DateTime Start,
    DateTime? End
    );


