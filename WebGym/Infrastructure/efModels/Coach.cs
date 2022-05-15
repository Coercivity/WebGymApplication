﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.efModels
{
    public partial class Coach
    {
        public Coach()
        {
            Attendances = new HashSet<Attendance>();
            Positions = new HashSet<Position>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public int? Experience { get; set; }
        public string Degree { get; set; }
        public Guid? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
    }
}
