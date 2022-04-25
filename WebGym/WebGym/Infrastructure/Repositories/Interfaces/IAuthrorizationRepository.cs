﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Infrastructure.Repositories.Interfaces
{
    public interface IAuthrorizationRepository
    {
        public Task<Account> TryAuthorizeAsync(string Login, string Password);
    }
}
