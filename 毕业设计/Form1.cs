using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 毕业设计
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Location = new Point(panelofPic.Location.X+panelofPic.Size.Width, panelofPic.Location.Y + panelofPic.Size.Height);//panel的占位符，为了出现滚动条
            this.label1.Text = "占位符";
            //注意还要修改
        }
        private int _flag;//当前确定的分钟格数显示值，2，5，10

        private void 生成底图结构ToolStripMenuItem_Click_1(object sender, EventArgs e)//10分格的底图结构生成
        {
            //生成10分格底图结构
            this.panelofPic.SetAutoScrollMargin(400, 100);//使用scrollbar来控制显示图像的范围
            TrainBasicPicture trainBasicPicture10 = new TrainBasicPicture();//声明10分格底图结构实例
            trainBasicPicture10.Width = this.panelofPic.Size.Width;//底图结构的宽度
            trainBasicPicture10.Height = this.panelofPic.Size.Height;//底图结构的高度
            trainBasicPicture10.TrainBasicPicturePos =new PointF(this.pictureBox1.Location.X+10, this.pictureBox1.Location.Y+10) ;
            pictureBox1.BackgroundImage = trainBasicPicture10.DrawTrainBasicPicture(TrainBasicPicture.Scale.TenMinutes);//将返回的bitmap设置为picbox的背景图片
            _flag = 10;//当前的flag为10分格数
        }

        private void panelofPic_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void 生成5分格底图结构ToolStripMenuItem_Click(object sender, EventArgs e)//5分格底图结构的生成
        {
            //生成5分格的底图结构
            this.panelofPic.SetAutoScrollMargin(3000, 100);//使用scrollbar来控制显示图像的范围
            TrainBasicPicture trainBasicPicture5 = new TrainBasicPicture();//声明5分格底图结构实例
            trainBasicPicture5.Width = this.panelofPic.Width * 2;
            trainBasicPicture5.Height = this.panelofPic.Height;
            trainBasicPicture5.TrainBasicPicturePos=new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10);
            pictureBox1.BackgroundImage = trainBasicPicture5.DrawTrainBasicPicture(TrainBasicPicture.Scale.FiveMinutes);//将返回的bitmap设置为picbox的背景图片
            _flag = 5;//当前的flag为10分格数
        }


        private void 生成2分格底图结构ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //生成2分格的底图结构
            this.panelofPic.SetAutoScrollMargin(100000, 100);//使用scrollbar来控制显示图像的范围
            TrainBasicPicture trainBasicPicture2 = new TrainBasicPicture();//声明5分格底图结构实例
            trainBasicPicture2.Width = this.panelofPic.Width * 5;
            trainBasicPicture2.Height = this.panelofPic.Height;
            trainBasicPicture2.TrainBasicPicturePos = new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10);
            pictureBox1.BackgroundImage = trainBasicPicture2.DrawTrainBasicPicture(TrainBasicPicture.Scale.TwoMinutes);//将返回的bitmap设置为picbox的背景图片
            _flag = 2;//当前的flag为10分格数
        }


        private void panelofPic_Scroll(object sender, ScrollEventArgs e)//拖动滑动条时进行重绘
        {
            //生成5分格的底图结构
            switch (_flag)
            {
                case 10:
                    break;
                case 5:
                    this.panelofPic.SetAutoScrollMargin(this.panelofPic.Width * 2, 100);
                    TrainBasicPicture trainBasicPicture5 = new TrainBasicPicture();//声明5分格底图结构实例
                    trainBasicPicture5.Width = this.panelofPic.Width * 2;
                    trainBasicPicture5.Height = this.panelofPic.Height;
                    trainBasicPicture5.TrainBasicPicturePos = new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10);
                    pictureBox1.BackgroundImage = trainBasicPicture5.DrawTrainBasicPicture(TrainBasicPicture.Scale.FiveMinutes); //将返回的bitmap设置为picbox的背景图片
                    _flag = 5;//当前的flag为10分格数
                    break;
                case 2:
                    //生成2分格的底图结构
                    this.panelofPic.SetAutoScrollMargin(this.panelofPic.Width * 5, 100);//使用scrollbar来控制显示图像的范围
                    TrainBasicPicture trainBasicPicture2 = new TrainBasicPicture();//声明5分格底图结构实例
                    trainBasicPicture2.Width = this.panelofPic.Width * 5;
                    trainBasicPicture2.Height = this.panelofPic.Height;
                    trainBasicPicture2.TrainBasicPicturePos = new PointF(this.pictureBox1.Location.X + 10, this.pictureBox1.Location.Y + 10);
                    pictureBox1.BackgroundImage = trainBasicPicture2.DrawTrainBasicPicture(TrainBasicPicture.Scale.TwoMinutes);//将返回的bitmap设置为picbox的背景图片
                    _flag = 2;//当前的flag为10分格数
                    break;
            }
            
        }

    }






}
