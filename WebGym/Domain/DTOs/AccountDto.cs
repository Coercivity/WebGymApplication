using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DTOs
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string LoginData { get; set; }
        public string PasswordData { get; set; }
        public string Email { get; set; }
        public int GroupId { get; set; }

    }
}
