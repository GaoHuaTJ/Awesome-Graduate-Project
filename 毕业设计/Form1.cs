﻿using System;
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


  

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Location = new Point(panelofPic.Location.X+panelofPic.Size.Width, panelofPic.Location.Y + panelofPic.Size.Height);//panel的占位符，为了出现滚动条
            this.label1.Text = "占位符";
            //注意还要修改
        }


        private void 生成底图结构ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //生成底图结构
            TrainBasicPicture trainBasicPicture = new TrainBasicPicture();//声明底图结构实例
            trainBasicPicture.Width = this.panelofPic.Size.Width;//底图结构的宽度
            trainBasicPicture.Height = this.panelofPic.Size.Height;//底图结构的高度
            trainBasicPicture.TrainBasicPicturePos =new PointF(this.pictureBox1.Location.X+10, this.pictureBox1.Location.Y+10) ;
            pictureBox1.BackgroundImage = trainBasicPicture.DrawTrainBasicPicture();//将返回的bitmap设置为picbox的背景图片

        }

        private void panelofPic_Paint(object sender, PaintEventArgs e)
        {

        }

    }
    class pictureBox1 : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics dc = pe.Graphics;
            Pen bluePen = new Pen(Color.Blue, 3);
            dc.DrawRectangle(bluePen, 0, 0, 50, 50);
            Pen redPen = new Pen(Color.Red, 2);
            dc.DrawEllipse(redPen, 0, 50, 80, 60);
        }
    }



}
