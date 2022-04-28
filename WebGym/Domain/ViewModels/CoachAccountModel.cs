using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Domain.ViewModels
{
    public class CoachAccountModel : AbstractAccountModel
    {
        public int Experience { get; set; }
        public string Rank { get; set; }

    }
}
