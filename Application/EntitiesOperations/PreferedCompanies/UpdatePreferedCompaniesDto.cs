using System;

namespace Application.EntitiesOperations.PreferedCompanies;

    public record UpdatePreferedCompaniesDto(
         Guid Id ,
         string UserId,
         string CompanyName
        );



