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
        public PointF TrainBasicPicturePos { set; get; }//底图结构的初始位置
        public Bitmap TrainBasicPictureBitMap { set; get; }//存储图片
        public enum Scale : int//底图结构的类型(2min,5min,10min)
        {
            TwoMinutes = 2,
            FiveMinutes = 5,
            TenMinutes = 10
        }
        Dictionary<int, string> Stations = new Dictionary<int, string>();//定义车站字典，key是车站的编号，string是车站的名字


        //
       public Bitmap DrawTrainBasicPicture(Scale scale)
        {
            //初始化底图结构的边框和格线
            switch (scale)
            {
                case Scale.TenMinutes:
                    this.TrainBasicPictureBitMap = DrawTrainBasicPictureBorderLine(10);
                    break;
                case Scale.FiveMinutes:
                    this.TrainBasicPictureBitMap = DrawTrainBasicPictureBorderLine(5);
                    break;
                case Scale.TwoMinutes:
                    this.TrainBasicPictureBitMap = DrawTrainBasicPictureBorderLine(2);
                    break;
            }
            //初始化边框中的格线
            return this.TrainBasicPictureBitMap;
        }

        /// <summary>
        /// 绘制列车运行图的底图边框，输入mins是时分格的大小10，5，2
        /// </summary>
        /// <param name="g"></param>
        Bitmap DrawTrainBasicPictureBorderLine(int mins)
        {

            //绘制边框
            this.TrainBasicPictureBitMap= new Bitmap(2000,1000);//这里的参数应该和输入的车站数量有关
            Graphics g = Graphics.FromImage(this.TrainBasicPictureBitMap);
            Pen borderLinePen = new Pen(Color.Green,3f);//定义画笔线宽和颜色
            g.DrawRectangle(borderLinePen,this.TrainBasicPicturePos.X, this.TrainBasicPicturePos.Y, (float)this.Width, (float)this.Height);//绘制边框


            //绘制纵向小时时间格线
            Pen pen = new Pen(Color.Green,2.5f);//定义画笔对象
            var TableLineStartPoints = GetHourLinePoints((int)this.Width,(int)this.Height,24,out var TableLineEndPoints);
            var index = 0;
            foreach (var item in TableLineStartPoints)
            {
                g.DrawLine(pen,item,TableLineEndPoints[index]);
                g.DrawString(string.Format("{0}:00", (index + 1).ToString()),new Font("华文仿宋", 10, FontStyle.Regular),new SolidBrush(Color.Black),new PointF(item.X-5,item.Y-10));
                index++;
            }


            //绘制纵向的分钟时间线
            Pen lineMinutesPen = new Pen(Color.Green, 0.5f);//定义画笔线宽和颜色
            for (int i = 1; i <24; i++)//s每一个小时间隙
            {
                var LineMinutesStartPoints = GetLineMinutesPoints(i, mins, out var LineMinutesEndPoints);
                index = 0;
                foreach (var item in LineMinutesStartPoints)//每一条分钟线
                {
                    g.DrawLine(lineMinutesPen, item, LineMinutesEndPoints[index]); 
                    index++;
                }
            }
            return this.TrainBasicPictureBitMap;
        }


        /// <summary>
        /// 输入矩形的宽度高度，和线段步长，进行表格绘制，用来画小时线
        /// </summary>
        /// <returns></returns>
        List<PointF> GetHourLinePoints(float width,float height,int step,out List<PointF> TableLineEndPoints)
        {
            List<PointF> TableLineStartPoints = new List<PointF>();
            TableLineEndPoints = new List<PointF>();
            PointF newPoint = new PointF();
            var _horizontalStep = width / step;//横向步长
            var _verticalStep= height / step;//纵向步长，分母为车站数
            for (int i = 1; i <= step; i++)
            {
                //计算横向起点坐标集合
                newPoint.X = this.TrainBasicPicturePos.X + _horizontalStep*i;
                newPoint.Y = this.TrainBasicPicturePos.Y;
                TableLineStartPoints.Add(newPoint);

                //计算纵向起点坐标集合
                newPoint.X = this.TrainBasicPicturePos.X + _horizontalStep * i;
                newPoint.Y = this.TrainBasicPicturePos.Y + height;
                TableLineEndPoints.Add(newPoint);
            }
            return TableLineStartPoints;
        }

        /// <summary>
        /// 输入起始小时，步长(step)，铺画分钟表格线
        /// </summary>
        /// <returns></returns>
        List<PointF> GetLineMinutesPoints(int hourTime, int step,out List<PointF> LineMinutesEndPoints)
        {
            PointF pointFOfHourTime = new PointF(this.TrainBasicPicturePos.X+hourTime, this.TrainBasicPicturePos.Y);//默认的起始点坐标为底图结构左上角
            List<PointF> LineMinutesStartPoints = new List<PointF>();//分钟线起始点的坐标列表
            LineMinutesEndPoints = new List<PointF>();//分钟线终点的坐标列表
            float _stepWidth = (float)this.Width / 24 / (60/step);//分钟线的步长宽度
            for (int i = 0; i <60 / step; i++)
            {
                LineMinutesStartPoints.Add(new PointF(this.TrainBasicPicturePos.X + hourTime *((float)this.Width / 24) + _stepWidth * i, this.TrainBasicPicturePos.Y));
                LineMinutesEndPoints.Add(new PointF(this.TrainBasicPicturePos.X + hourTime * ((float)this.Width / 24) + _stepWidth * i, this.TrainBasicPicturePos.Y+(float)this.Height));
            }
            return LineMinutesStartPoints;
        }





    }
}
