using System;
using System.Collections.Generic;

#nullable disable

namespace WebGym.Infrastructure.efModels
{
    public partial class Client
    {
        public Client()
        {
            Abonements = new HashSet<Abonement>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public DateTime? BirthData { get; set; }
        public Guid? AccountId { get; set; }
        public Guid? StatisticsDataId { get; set; }

        public virtual Account Account { get; set; }
        public virtual StatisticsData StatisticsData { get; set; }
        public virtual ICollection<Abonement> Abonements { get; set; }
    }
}
