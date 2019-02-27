using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 毕业设计
{
    //列车运行图的底图结构
    class TrainBasicPicture
    {
        public double Height { set; get; }//底图结构的高度
        public double Width { set; get; }//底图结构的宽度
        public Point TrainBasicPicturePos { set; get; }//底图结构的初始位置
        public Bitmap TrainBasicPictureBitMap { set; get; }//存储图片
        public enum Scale : int//底图结构的类型(2min,5min,10min)
        {
            TwoMinutes = 2,
            FiveMinutes = 5,
            TenMinutes = 10
        }
        Dictionary<int, string> Stations = new Dictionary<int, string>();//定义车站字典，key是车站的编号，string是车站的名字

       public Bitmap DrawTrainBasicPicture()
        {
            //初始化底图结构的边框和格线
          this.TrainBasicPictureBitMap =  DrawTrainBasicPictureBorderLine();
            //初始化边框中的格线
            return this.TrainBasicPictureBitMap;
        }

        /// <summary>
        /// 绘制列车运行图的底图边框
        /// </summary>
        /// <param name="g"></param>
        Bitmap DrawTrainBasicPictureBorderLine()
        {

            //绘制边框
            this.TrainBasicPictureBitMap= new Bitmap(2000,1000);//这里的参数应该和输入的车站数量有关
            Graphics g = Graphics.FromImage(this.TrainBasicPictureBitMap);
            Pen borderLinePen = new Pen(Color.Green,3f);//定义画笔线宽和颜色
            Rectangle borderLineData = new Rectangle(this.TrainBasicPicturePos,new Size((int)this.Width, (int)this.Height));//边框的高度和宽度
            g.DrawRectangle(borderLinePen,borderLineData);//绘制边框


            //绘制格线
            Pen pen = new Pen(Color.Green,2.5f);//定义画笔对象
            var TableLineStartPoints = GetTableLinePoints(out var TableLineEndPoints);
            var index = 0;
            foreach (var item in TableLineStartPoints)
            {
                g.DrawLine(pen,item,TableLineEndPoints[index]);
                index++;
            }

            return this.TrainBasicPictureBitMap;
        }


        /// <summary>
        /// 返回底图结构网格线的起点坐标
        /// </summary>
        /// <returns></returns>
        List<Point> GetTableLinePoints(out List<Point> TableLineEndPoints)
        {
            List<Point> TableLineStartPoints = new List<Point>();
            Point newPoint = new Point();
            var _horizontalStep = (int)this.Width / 24;//横向步长
            var _verticalStep= (int)this.Height / 24;//纵向步长，分母为车站数
            for (int i = 10; i <= 24; i++)//计算横向起点坐标集合
            {
                newPoint.X = this.TrainBasicPicturePos.X + _horizontalStep*i;
                newPoint.Y = this.TrainBasicPicturePos.Y;
                TableLineStartPoints.Add(newPoint);
                TableLineStartPoints.Add(newPoint);
            }

            TableLineEndPoints = new List<Point>();
            for (int i = 10; i <= 24; i++)//计算横向终点坐标集合
            {
                newPoint.X = this.TrainBasicPicturePos.X + _horizontalStep * i;
                newPoint.Y = this.TrainBasicPicturePos.Y+(int)this.Height;
                TableLineEndPoints.Add(newPoint);
                TableLineEndPoints.Add(newPoint);
            }


            return TableLineStartPoints;
        }




        


       
    }
}
