using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public partial class Account
    {
        public int Id { get; set; }
        public string LoginData { get; set; }
        public string PasswordData { get; set; }
        public string Email { get; set; }
        public int GroupId { get; set; }

        public virtual RoleGroup Group { get; set; }
        public virtual Client Client { get; set; }
        public virtual Coach Coach { get; set; }
    }
}
