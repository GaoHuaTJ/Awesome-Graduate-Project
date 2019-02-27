﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 毕业设计
{
    class Line
    {
        public float Width { set; get; }//线宽
        public Color Color { set; get; }//线的颜色
        public PointF StartPoint { set; get; }//线的起始点坐标
        public PointF EndPoint { set; get; }//线的终止点坐标
    }
}
