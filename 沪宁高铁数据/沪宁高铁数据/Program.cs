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
            Console.WriteLine("车票信息存储完毕");



            var url = string.Format("https://kyfw.12306.cn/otn/czxx/queryByTrainNo?train_no={0}&from_station_telecode={1}&to_station_telecode={2}&depart_date={3}", trainNoLists[0], trainStartStationLists[0], trainEndStationLists[0], trainsTickets.SelectDateTime.ToString("yyyy-MM-dd"));//此处的到站只有NJH和NKH
            JArray jArray = GetUrlJson(url);//发送请求返回json的jarray数据
            DataTable dataTable = CreateTrainTimeDataTable(jArray);
            var trainTimeTableExcel = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + string.Format("\\trainTime_{0}.xlsx", DateTime.Now.ToString("yyyyMMddhhmmss"));//桌面上生成数据文件
            Excel.TableToExcel(dataTable, trainTimeTableExcel);
            Console.WriteLine(string.Format("{0}车次信息存储完毕", trainNoLists[0]));
            Console.ReadKey();
        }


    


        /// <summary>
        /// get获取url的json的数组数据
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public static JArray GetUrlJson(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;
            //request.Referer = "https://kyfw.12306.cn/otn/leftTicket/init?linktypeid=dc&fs=%E4%B8%8A%E6%B5%B7,SHH&ts=%E5%8C%97%E4%BA%AC,BJP&date=2019-03-10&flag=N,N,Y";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36";
            request.IfModifiedSince = DateTime.Now;
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            request.Headers.Add("Cache-Control", "no-cache");
            //request.Headers.Add("Cookie", "JSESSIONID=B3E21D8294C2857736E095CEF113768E; RAIL_EXPIRATION=1552454853784; RAIL_DEVICEID=GgvErOZ2x9C_UW86grSWfz56ZIs2Z7tcU9WMgHJNjckrQXWBjJe_vgSo7_P5mQUvQF65tCAKajeWvDDLGyJb_bPWKRV33ZN5MW2F903JtxaWZ4cWK4tnUxeTzqhJWEK40UqVS5ijbPbgAT4Z-2GzjyP4AuWDHGGz; _jc_save_fromStation=%u4E0A%u6D77%2CSHH; _jc_save_wfdc_flag=dc; BIGipServerpool_passport=300745226.50215.0000; route=9036359bb8a8a461c164a04f8f50b252; BIGipServerotn=569377290.64545.0000; _jc_save_toDate=2019-03-10; _jc_save_toStation=%u5317%u4EAC%2CBJP; _jc_save_fromDate=2019-03-10");
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }
            JObject jObject = (JObject)JsonConvert.DeserializeObject(retString);//解析json
            JArray jArray;

            if (Url.Contains("train_no="))
            {
                 jArray = (JArray)jObject["data"]["data"];//检索的是时间信息
            }
            else
            {
                 jArray = (JArray)jObject["data"]["result"];//检索的是车次信息
            }
            return jArray;
        }

        /// <summary>
        /// 输入包含TrainNo字段的excel路径，返回TrainNos的列表
        /// 返回上海的火车站代码，南京的火车站代码
        /// </summary>
        /// <param name="trainInfoExcelPath"></param>
        /// <returns></returns>
        /// <summary>
        /// 创建一个时刻表的datatable，并解析时刻表的json
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTrainTimeDataTable(JArray jArray)
        {
            DataTable dataTable = new DataTable(jArray[0]["station_train_code"].ToString());//表名为
            dataTable.Columns.Add("站序");
            dataTable.Columns.Add("站名");
            dataTable.Columns.Add("到站时间");
            dataTable.Columns.Add("出发时间");
            dataTable.Columns.Add("停留时间");
            dataTable.Columns.Add("始发站");
            dataTable.Columns.Add("终点站");

            foreach (var item in jArray)
            {
                DataRow dataRow = dataTable.NewRow();//新创建一行
                dataRow["站序"] = item["station_no"];
                dataRow["站名"] = item["station_name"];
                dataRow["到站时间"] = item["arrive_time"];
                dataRow["出发时间"] = item["start_time"];
                dataRow["停留时间"] = item["stopover_time"];
                dataRow["始发站"] = jArray[0]["start_station_name"];
                dataRow["终点站"] = jArray[0]["end_station_name"];
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }


    }
    
}
