using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
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

    }
}
