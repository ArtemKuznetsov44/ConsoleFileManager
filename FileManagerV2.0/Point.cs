using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerV2._0
{
    class Point
    {
        public int x;
        public int y;
        public char symbol; 
        public Point(int x, int y, char symbol)
        {
            this.x = x;
            this.y = y;
            this.symbol = symbol; 
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol); 
        }
    }
}
