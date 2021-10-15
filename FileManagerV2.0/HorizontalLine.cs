using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerV2._0
{
    class HorizontalLine : Figure
    {
        public HorizontalLine(int xStart, int xEnd, int y, char symbol)
        {
            for (int x = xStart; x <= xEnd; x++)
            {
                Point point = new Point(x, y, symbol);
                pList.Add(point);
            }
        }
    }
}
