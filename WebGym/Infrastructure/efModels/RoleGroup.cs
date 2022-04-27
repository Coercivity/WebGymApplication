using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public partial class RoleGroup
    {
        public RoleGroup()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
