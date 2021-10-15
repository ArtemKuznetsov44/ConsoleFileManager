using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerV2._0
{
    class Dirs
    {
        static int pages;
        static int currentPage = 1;
        static int offset; 
        static bool nextAvailable = false;
        static bool prevAvailable = false; 
        public static void PrintDirs(string path, int number)
        {
            string[] allDirs = Directory.GetDirectories(path);
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Directories:");
            if (allDirs.Length > 0)
            {
                int counter = 4;
                for (int i = 0; i < number && i < allDirs.Length; i++)
                {
                    Console.SetCursorPosition(1, counter++);
                    Console.WriteLine($"{(char)166}{(char)95}{GetCurrectDirName(allDirs[i], path)}");
                }
            }
            if (allDirs.Length > number)
            {
                nextAvailable = true;
                prevAvailable = false; 
                pages = PagesCount(allDirs, number);
                currentPage = 1;
                Console.SetCursorPosition(1, Console.WindowHeight - 10);
                Console.Write($"Page {currentPage} of {PagesCount(allDirs, number)}");
                Console.SetCursorPosition(1, Console.WindowHeight - 9);
                Console.Write($"The total number of directories along this path: {allDirs.Length}");
            }
        }
        public static void PrintNextPage(string path, int number)
        {
            if (nextAvailable)
            {
                prevAvailable = true;
                offset = number; 
                string[] allDirs = Directory.GetDirectories(path);
                Console.SetCursorPosition(1, 3);
                Console.WriteLine("Directories:");
                int counter = 4;
                for (int i = offset; i < number + offset  && i < allDirs.Length; i++)
                {
                    Console.SetCursorPosition(1, counter++);
                    Console.WriteLine($"{(char)166}{(char)95}{GetCurrectDirName(allDirs[i], path)}");
                }
                if (currentPage < pages)
                {
                    currentPage += 1;
                    offset += number;
                }
                Console.SetCursorPosition(1, Console.WindowHeight - 10);
                Console.Write($"Page {currentPage} of {PagesCount(allDirs, number)}");
                Console.SetCursorPosition(1, Console.WindowHeight - 9);
                Console.Write($"The total number of directories along this path: {allDirs.Length}");
            }
            else
                PrintDirs(path, number); 
        }
        public static void PrintPrevPage(string path, int number)
        {
            if (prevAvailable)
            {
                if (currentPage > 1)
                {
                    currentPage--;
                    offset -= number;
                }
                string[] allDirs = Directory.GetDirectories(path);
                Console.SetCursorPosition(1, 3);
                Console.WriteLine("Directories:");
                int counter = 4;
                for (int i = offset, j = 0; j < number && i < allDirs.Length; i++, j++)
                {
                    Console.SetCursorPosition(1, counter++);
                    Console.WriteLine($"{(char)166}{(char)95}{GetCurrectDirName(allDirs[i + offset], path)}");
                }
                Console.SetCursorPosition(1, Console.WindowHeight - 10);
                Console.Write($"Page {currentPage} of {PagesCount(allDirs, number)}");
                Console.SetCursorPosition(1, Console.WindowHeight - 9);
                Console.Write($"The total number of directories along this path: {allDirs.Length}");
            }
            else
                PrintDirs(path, number); 
        }
        public static bool Check(string path, string pathToView)
        {
            if (path.StartsWith("\\"))
            {
                if (Directory.Exists(pathToView + path))
                    return true;
                else
                    return false;
            }
            else if (path.StartsWith(""))
            {
                if (Directory.Exists(pathToView + "\\" + path))
                    return true;
                else
                    return false;
            }
            else
                return false; 
        }
        public static string GetCurrectDirName(string name, string path)
        {
            string currectName = name.Replace(path, "");
            if (currectName.Contains("\\"))
                currectName = currectName.Replace("\\", "");
            return currectName;
        }
        public static void PrintDirInfo(string path, string pathToView)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                Console.SetCursorPosition(1, Console.WindowHeight - 7);
                Console.Write($"Dir name: {directoryInfo.Name}");
                Console.SetCursorPosition(1, Console.WindowHeight - 6);
                Console.Write($"Dir full name: {directoryInfo.FullName}");
                Console.SetCursorPosition(1, Console.WindowHeight - 5);
                Console.Write($"Creation time: {directoryInfo.CreationTime}");
                Console.SetCursorPosition(1, Console.WindowHeight - 4);
                Console.Write($"Root directory: {directoryInfo.Root}");
            }
            else
            {
                if (Directory.Exists(pathToView + "\\" + path))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(pathToView + "\\" + path);
                    Console.SetCursorPosition(1, Console.WindowHeight - 7);
                    Console.Write($"Dir name: {directoryInfo.Name}");
                    Console.SetCursorPosition(1, Console.WindowHeight - 6);
                    Console.Write($"Dir full name: {directoryInfo.FullName}");
                    Console.SetCursorPosition(1, Console.WindowHeight - 5);
                    Console.Write($"Creation time: {directoryInfo.CreationTime}");
                    Console.SetCursorPosition(1, Console.WindowHeight - 4);
                    Console.Write($"Root directory: {directoryInfo.Root}");
                }
                else
                    Path.Error(); 
            }
        }
        public static void DeleteDir(string path, string pathToView)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
            else if (Directory.Exists(pathToView + "\\" + path))
                Directory.Delete(pathToView + "\\" + path, true);
            else
                Path.Error(); 
        }
        public static int PagesCount(string[] array, int number)
        {
            int pageCounter = array.Length / number;
            if (array.Length % number != 0)
                pageCounter++;
            return pageCounter;
        }
        public static void CopyDir(string path, string pathToView)
        {
            path = path.Trim();
            string[] pathes = path.Split();
            if (Directory.Exists(pathes[0]))
            {
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(pathes[0]);
                    directoryInfo.CreateSubdirectory(pathes[0]);
                    directoryInfo.MoveTo(pathes[1]); 
                }
                catch(Exception)
                {
                    throw new Exception("Copy dir operation was incorrect"); 
                }
            }
            else if(Directory.Exists(pathToView + "\\" + pathes[0]))
            {
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(pathes[0]);
                    directoryInfo.CreateSubdirectory(pathes[0]);
                    directoryInfo.MoveTo(pathes[1]);
                }
                catch (Exception)
                {
                    throw new Exception("Copy dir operation was incorrect");
                }
            }
            else
                Path.Error(); 
        }
    }
}
