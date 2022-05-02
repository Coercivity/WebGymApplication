using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGym.Domain.ViewModels
{
    public class AbonementModel
    {
        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? VisitsAmount { get; set; }
        public Guid? ClientId { get; set; }
        public bool? IsValid { get; set; }
    }
}
