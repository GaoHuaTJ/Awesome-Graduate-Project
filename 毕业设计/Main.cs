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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void 运行图绘制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 TrainPictureFrom = new Form1();
            TrainPictureFrom.TopLevel = false;//非常重要的一个步骤
            TrainPictureFrom.Parent = this;//设置绘图界面的窗口父窗口为当前窗口
            TrainPictureFrom.Show();

        }


        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
