using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Abstractions.Auth
{
    public interface IJwt
    {
        Task<string> GenerateToken(List<string> roles, string? username, string Id);
    }
}



