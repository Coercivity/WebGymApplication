﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public partial class CoachDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public int? Experience { get; set; }
        public string Degree { get; set; }
        public Guid? AccountId { get; set; }

    }
}
