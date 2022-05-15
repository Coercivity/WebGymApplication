using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.DTOs
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? StatisticsDataId { get; set; }
        public string Sex { get; set; }
        public string ImageName { get; set; }
        public DateTime? BirthData { get; set; }






    }
}
