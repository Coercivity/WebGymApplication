﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym.Domain.DTOs
{
    public class ServiceDataTypeDto
    {
        public Guid Id { get; set; }
        public string NameData { get; set; }
        public decimal? Price { get; set; }

    }
}
