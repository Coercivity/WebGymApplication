using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public enum RegistrationStatus
    {
        Successful = 1,
        AccountExists,
        Error
    }
}
