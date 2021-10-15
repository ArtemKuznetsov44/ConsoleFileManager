using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerV2._0
{
    class VerticalLine : Figure
    {
        public VerticalLine(int x, int yStart, int yEnd, char symbol)
        {
            for (int y = yStart; y <= yEnd; y++)
            {
                Point point = new Point(x, y, symbol);
                pList.Add(point);
            }
        }
    }
}
