using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public partial class Coach
    {
        public Coach()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public int Experience { get; set; }
        public string Degree { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
