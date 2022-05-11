using Domain.ViewModels;
using Google.DataTable.Net.Wrapper;
using Google.DataTable.Net.Wrapper.Extension;
using System;
using System.Collections.Generic;
using WebGym.Handlers.Charts;
using WebGym.Handlers.Interfaces;

namespace WebGym.Handlers
{
    public class ChartHandler : IPieChartHandler
    {


        public ChartHandler() { }


        public string GetPieChart(ClientAccountModel accountModel)
        {
            var chart = new List<PieChartRow>();

            foreach (var trainType in accountModel.TrainTypes)
            {
                chart.Add(new PieChartRow
                {
                    Name = trainType.Description,
                    Count = accountModel.TrainTypesDictionary[trainType.Id]
                });
            }

            var json = chart.ToGoogleDataTable()
           .NewColumn(new Column(ColumnType.String, "Topping"), x => x.Name)
           .NewColumn(new Column(ColumnType.Number, "Slices"), x => x.Count)
           .Build()
           .GetJson();

            return json;
        }

        public List<LineChartRow> GetLineChart(List<AttendanceModel> attendanceModels)
        {
            var chart = new List<LineChartRow>();
            int i = 1;
            foreach (var attendance in attendanceModels)
            {
                
                chart.Add(new LineChartRow
                {
                    Visits = i++,
                    HeartPressure = attendance.HeartPressure,
                    HeadPressure = attendance.HeadPressure,
                    Pulse = attendance.Pulse,
                    Weight = attendance.Weight
                });
            }

            return chart;
        }
    }
}
