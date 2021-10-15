using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerV2._0
{
    class CmdList
    {
        // Данный класс служит для вывода всех доступных для использования в приложении консольных команд.
        public static void PrintAllCommands()
        {
            Console.SetCursorPosition(20, 3);
            Console.Write("Command list:");
            Console.SetCursorPosition(1, 5);
            Console.Write("cd [path] - move between directories.");
            Console.SetCursorPosition(1, 7);
            Console.Write("copy -f [sourceFileName] [destFileName]- copy files.");
            Console.SetCursorPosition(1, 9);
            Console.Write("copy -d [sourceDirName] [destDirName]- copy directories.");
            Console.SetCursorPosition(1, 11);
            Console.Write("delete -f [path] - delete file.");
            Console.SetCursorPosition(1, 13);
            Console.Write("delete -d [path] - delete directory.");
            Console.SetCursorPosition(1, 15);
            Console.Write("info -f [path] - get info about file.");
            Console.SetCursorPosition(1, 17);
            Console.Write("info -d [path] - get info about directory.");
            Console.SetCursorPosition(1, 19);
            Console.Write("next - move to the next page when it`s possible.");
            Console.SetCursorPosition(1, 21);
            Console.Write("prev - move to the previous page when it`s possible.");
        }
    }
}
