using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gatherly.Domain.Shared;

namespace Gatherly.Domain.Errors;

public static class DomainErrors
{
    public static class Register
    {
        public static readonly Error RegisterError = new Error(
            "Register",
            "User is already found, please login!");
    }

    public static class Login
    {
        public static readonly Error LoginError = new Error(
            "Login",
            "User is not found ,you must register first!");
    }


}


