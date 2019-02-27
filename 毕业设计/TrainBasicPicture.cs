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
        public enum Scale : int//底图结构的类型(2min,5min,10min)
        {
            TwoMinutes = 2,
            FiveMinutes = 5,
            TenMinutes = 10
        }
        Dictionary<int, string> Stations = new Dictionary<int, string>();//定义车站字典，key是车站的编号，string是车站的名字

       public void DrawTrainBasicPicture(Graphics g)
        {
            //初始化底图结构的边款
            DrawTrainBasicPictureBorderLine(g);
        }

        /// <summary>
        /// 绘制列车运行图的底图边框
        /// </summary>
        /// <param name="g"></param>
        void DrawTrainBasicPictureBorderLine(Graphics g)
        {
            Pen borderLinePen = new Pen(Color.Green,3f);//定义画笔线宽和颜色
            Rectangle borderLineData = new Rectangle(this.TrainBasicPicturePos,new Size((int)this.Width, (int)this.Height));//边框的高度和宽度
            Console.WriteLine(this.Width);
            g.DrawRectangle(borderLinePen,borderLineData);//绘制边框
        }

    }
}
