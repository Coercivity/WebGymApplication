﻿using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGym.Handlers.Interfaces
{
    public interface IPieChartHandler
    {
        public string GetPieChart(ClientAccountModel accountModel);
    }
}
