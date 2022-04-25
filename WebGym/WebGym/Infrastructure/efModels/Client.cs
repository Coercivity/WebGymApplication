using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym
{
    public partial class Client
    {
        public Client()
        {
            Abonements = new HashSet<Abonement>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public int? AccountId { get; set; }
        public int? StatisticsDataId { get; set; }

        public virtual Account Account { get; set; }
        public virtual StatisticsData StatisticsData { get; set; }
        public virtual ICollection<Abonement> Abonements { get; set; }
    }
}
