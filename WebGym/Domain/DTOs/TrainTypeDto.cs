using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DTOs
{
    public class TrainTypeDto
    {

        public Guid Id { get; set; }
        public string Description { get; set; }

        public string ImagePath { get; set; }

    }
}
