using Domain.Enums;
using System;

namespace Application.EntitiesOperations.Withdrawal;

public record WithdrawalDto(
 string UserId ,
 Reason Reason ,
 byte[]? MedicalReport ,
 LeaveStatus Status ,
 DateTime At ,
 DateTime Start ,
 DateTime? End 
    );


