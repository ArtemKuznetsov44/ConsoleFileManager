using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace FileManagerV2._0
{
    class Files
    {
        // Данный класс предназначен для работы с файлами.
        static int pages; 
        static int currentPage = 1;
        static int offset;
        static bool nextAvailable = false;
        static bool prevAvailable = false;
        public static void PrintFiles(string path, int number) // Простой вывод файлов по указанному пути.
        {
            string[] allFiles = Directory.GetFiles(path);  // Получение всех файлов.
            Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 3);
            Console.WriteLine("Files:");
            if (allFiles.Length > 0)
            {
                int counter = 4; // Счетчик для установки позиции курсора (строки).
                for (int i = 0; i < number && i < allFiles.Length; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth/2 + 1, counter++);
                    Console.WriteLine($"{(char)166}{(char)95}{GetCurrectFileName(allFiles[i], path)}");
                }
            }
            if (allFiles.Length > number) // В случаее, если длинна полученного массива превышает кол-во элементо для отображения.
            {
                nextAvailable = true;
                prevAvailable = false;
                pages = PagesCount(allFiles, number);
                currentPage = 1;
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 10);
                Console.Write($"Page {currentPage} of {pages}");
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 9);
                Console.Write($"The total number of files along this path: {allFiles.Length}"); 
            }
        }
        public static void PrintNextPage(string path, int number) // При использовании команды "next".
        {
            if (nextAvailable)
            {
                prevAvailable = true;
                offset = number;
                string[] allFiles = Directory.GetDirectories(path);
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 3);
                Console.WriteLine("Files:");
                int counter = 4;
                for (int i = offset; i < number && i < allFiles.Length; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 1, counter++);
                    Console.WriteLine($"{(char)166}{(char)95}{GetCurrectFileName(allFiles[i], path)}");
                }
                if (currentPage < pages)
                {
                    currentPage += 1;
                    offset += number;
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 10);
                Console.Write($"Page {currentPage} of {pages}");
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 9);
                Console.Write($"The total number of files along this path: {allFiles.Length}");
            }
            else
                PrintFiles(path, number); 
        }
        public static void PrintPrevPage(string path, int number) // При использовании команды "prev".
        {
            if (prevAvailable)
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    offset -= number;
                }
                string[] allFiles = Directory.GetDirectories(path);
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, 3);
                Console.WriteLine("Files:");
                int counter = 4;
                for (int i = offset, j = 0; j < number && i < allFiles.Length; i++, j++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 1, counter++);
                    Console.WriteLine($"{(char)166}{(char)95}{GetCurrectFileName(allFiles[i], path)}");
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 10);
                Console.Write($"Page {currentPage} of {pages}");
                Console.SetCursorPosition(Console.WindowWidth / 2 + 1, Console.WindowHeight - 9);
                Console.Write($"The total number of files along this path: {allFiles.Length}");
            }
            else
                PrintFiles(path, number); 
        }

        public static string GetCurrectFileName(string name, string path) // Получаении "корректного" имении файла.
        {
            string currectName = name.Replace(path, "");
            if (currectName.Contains("\\"))
                currectName = currectName.Replace("\\", "");
            return currectName; 
        }
        public static void PrintFileInfo(string path, string pathToView) // При использовании команды "info -f". 
        {
            
            if (File.Exists(path))
            {
                FileInfo fileInfo = new FileInfo(path);
                Console.SetCursorPosition(1, Console.WindowHeight - 7);
                Console.Write($"File name: {fileInfo.FullName}");
                Console.SetCursorPosition(1, Console.WindowHeight - 6);
                Console.Write($"Creation time: {fileInfo.CreationTime}");
                Console.SetCursorPosition(1, Console.WindowHeight - 5);
                Console.Write($"Size: {fileInfo.Length}");
            }
            else
            {
                if (File.Exists(pathToView + "\\" + path))
                {
                    FileInfo fileInfo = new FileInfo(pathToView + "\\" + path);
                    Console.SetCursorPosition(1, Console.WindowHeight - 7);
                    Console.Write($"File name: {fileInfo.FullName}");
                    Console.SetCursorPosition(1, Console.WindowHeight - 6);
                    Console.Write($"Creation time: {fileInfo.CreationTime}");
                    Console.SetCursorPosition(1, Console.WindowHeight - 5);
                    Console.Write($"Size: {fileInfo.Length}");
                }
                else
                    Path.Error(); 
            }
        }

        public static void DeleteFile(string path, string pathToView) // При использовании команды "delete -f". 
        {
            if (File.Exists(path))
                File.Delete(path);
            else if (File.Exists(pathToView + "\\" + path))
                File.Delete(pathToView + "\\" + path);
            else
                Path.Error(); 
        }
        public static int PagesCount(string[] array, int number) // Для посчета общего кол-ва страниц доступных для отображения.
        {
            int pageCounter = array.Length / number;
            if (array.Length % number != 0)
                pageCounter++;
            return pageCounter;
        }
        public static void CopyFile(string path, string pathToView) // При использовании команды "сopy -f".
        {
            path = path.Trim();
            string[] pathes = path.Split();
            if (File.Exists(pathes[0]))
                File.Copy(pathes[0], pathes[1]);
            else if (File.Exists(pathToView + "\\" + pathes[0]))
                File.Copy(pathToView + "\\" + pathes[0], pathes[1]); 
            else
                Path.Error(); 
        }

    }
}
