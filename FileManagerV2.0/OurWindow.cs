using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace FileManagerV2._0
{
    class OurWindow
    {
        // Данный класс служит для оформеления консольного окна.
        public static void PrintMarkup()
        {
            Console.SetWindowSize(120, 40);
            HorizontalLine h_line_up = new HorizontalLine(0, Console.WindowWidth - 1, 0, '='); 
            HorizontalLine h_line_down = new HorizontalLine(0, Console.WindowWidth - 1, Console.WindowHeight - 1, '=');
            HorizontalLine h_line_path_down = new HorizontalLine(0, Console.WindowWidth - 1, 2, '=');
            HorizontalLine h_line_before_inform = new HorizontalLine(0, Console.WindowWidth - 1, Console.WindowHeight - 8, '=');
            HorizontalLine h_line_after_intorm = new HorizontalLine(0, Console.WindowWidth - 1, Console.WindowHeight - 3, '='); 
            VerticalLine v_line_center = new VerticalLine((Console.WindowWidth - 1) / 2, 3, Console.WindowHeight - 9, '|');
            VerticalLine v_line_left = new VerticalLine(0, 1, Console.WindowHeight - 2, '|');
            VerticalLine v_line_right = new VerticalLine(Console.WindowWidth - 1, 1, Console.WindowHeight - 2, '|');
            h_line_up.Draw();
            h_line_down.Draw();
            h_line_path_down.Draw();
            h_line_before_inform.Draw();
            h_line_after_intorm.Draw(); 
            v_line_center.Draw();
            v_line_left.Draw();
            v_line_right.Draw();
        }
    }
}
