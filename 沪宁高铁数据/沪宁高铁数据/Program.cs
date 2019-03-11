using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace 沪宁高铁数据
{
    class Program
    {
        static void Main(string[] args)
        {
            TrainsTickets trainsTickets = new TrainsTickets();
            trainsTickets.SelectDateTime = DateTime.Now.AddDays(3);
            trainsTickets.FromStation = "SHH";
            trainsTickets.ToStation = "NJH";
            trainsTickets.GetTrainInfo();
            List<string> trainNoLists= trainsTickets.ReadExcelTrainNo(trainsTickets.TrainsTicketsExcelPath,out List<string>trainStartStationLists, out  List<string> trainEndStationLists);
            Console.WriteLine("车票信息存储完毕\n-----------------------------------------------------------------------------------------------------");


            TrainTimeTable trainTimeTable = new TrainTimeTable(trainNoLists[0], trainStartStationLists[0], trainEndStationLists[0], trainsTickets.SelectDateTime);
            trainTimeTable.CreateTrainTimeDataTable();
            Console.WriteLine(string.Format("车次{0}时刻表信息存储完毕\n-------------------------------------------------------------------------------------------------------",trainTimeTable.trainNo));

            Console.ReadKey();
        }
    }

}
