using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.ViewModels
{
    public class AbonementModel
    {
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FinishDate { get; set; }
        public int? VisitsAmount { get; set; }
        public Guid? ClientId { get; set; }
        public bool IsValid { get; set; }
    }
}
