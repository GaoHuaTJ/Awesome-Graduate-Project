using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 毕业设计
{
    //对图纸进行相关的编辑操作
    class Edit
    {

        /// <summary>
        /// 画线编辑
        /// </summary>
        /// <param name="line"></param>
        /// <param name="graphics"></param>
       public static void DrawLine(Line line, Graphics graphics)
        {
            Pen pen = new Pen(line.Color,line.Width);//定义画笔颜色
            graphics.DrawLine(pen, line.StartPoint, line.EndPoint);//画布上面画线
        }
    }

}
