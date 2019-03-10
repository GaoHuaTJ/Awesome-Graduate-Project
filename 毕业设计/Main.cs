using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 毕业设计
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.Font = new Font("微软雅黑", 12);
            }
        }

        private void 运行图绘制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 TrainPictureFrom = new Form1();
            TrainPictureFrom.TopLevel = false;//非常重要的一个步骤
            TrainPictureFrom.Parent = this;//设置绘图界面的窗口父窗口为当前窗口
            TrainPictureFrom.Show();

        }




        private void 新建项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //点击新建项目
            NewProject newProjectFrom = new NewProject();
            newProjectFrom.ShowDialog();
        }

        private void 打开已有项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//获取桌面路径
            //folderBrowserDialog.ShowDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Directory.SetCurrentDirectory(folderBrowserDialog.SelectedPath);//设置当前的工作目录
                MessageBox.Show(string.Format("当前的工作目录为   {0}", folderBrowserDialog.SelectedPath));
            }
        }
    }
}
