using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerV2._0
{
    class Path
    {
        // Данный класс служит для "распознования" пути из введной пользователем команды в зависимости от неё самой. 

        public string path; // Пременная, хранящая путь.
        public void GetPath(string s, Commands selected)
        {
            if (selected == Commands.SWITCH)
            {
                s = s.Trim();
                s = s.Replace("cd ", ""); 
                this.path = s;
            }
            else if (selected == Commands.DELETE_FILE)
            {
                s = s.Trim();
                s = s.Replace("delete -f ", ""); 
                this.path = s;
            } 
            else if (selected == Commands.GET_FILE_INFO)
            {
                s = s.Trim();
                s = s.Replace("info -f ", "");
                this.path = s; 
            }
            else if(selected == Commands.GET_DIR_INFO)
            {
                s = s.Trim();
                s = s.Replace("info -d ", "");
                this.path = s; 
            }
            else if(selected == Commands.DELETE_DIR)
            {
                s = s.Trim();
                s = s.Replace("delete -d ", "");
                this.path = s; 
            }
            else if(selected == Commands.COPY_FILE)
            {
                s = s.Trim();
                s = s.Replace("copy -f ", "");
                this.path = s; 
            }
            else if(selected == Commands.COPY_DIR)
            {
                s = s.Trim();
                s = s.Replace("copy -d ", "");
                this.path = s; 
            }
        }
        public static void Error() // Метод для вывода сообщения об ошибки на консоль.
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 10);
            Console.Write("Path was set incorrectly!");
        }
    }
}
