using System;

namespace Domain.ViewModels
{
    public class AbonementModel
    {
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int? VisitsAmount { get; set; }
        public Guid? ClientId { get; set; }
        public bool IsValid { get; set; }
    }
}
