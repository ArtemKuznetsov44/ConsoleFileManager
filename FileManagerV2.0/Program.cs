using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq; 
using System.IO;

namespace FileManagerV2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists(@"..\..\..\errors")) // Создание необходимой дирректории в случаее её отсутствия.
                Directory.CreateDirectory(@"..\..\..\errors");
            string exceptionFile = @"..\..\..\errors\exceptions.txt";  // Сохраняем путь к файлу, в котором будут записываться непредвиденные ошибки.
            CommandSelector CommandSelector = new(); // Создание экземпляра класса "ОпределительКоманд".
            Path Path = new(); // Создание экземляра класса "Путь".
            Commands selectedCommand; // Обявление переменной типа перечисление.
            int numberOfElements = int.Parse(ConfigurationManager.AppSettings.Get("Number")); // Получение кол-во элементов для отображения из файла конфигурации.
            string pathToView = ""; 
            do
            {
                try
                {
                    OurWindow.PrintMarkup(); // Оформление консольного окна
                    Console.SetCursorPosition(1, 1);
                    Console.Write($"Current path: {pathToView}"); // Отображение "действующего" пути.
                    Console.SetCursorPosition(1, Console.WindowHeight - 2);
                    string command = Console.ReadLine();
                    selectedCommand = CommandSelector.Select(command);
                    if (selectedCommand == Commands.SWITCH) // Переключение между каталогами.
                    {
                        Console.Clear();
                        Path.GetPath(command, selectedCommand);
                        if (Directory.Exists(Path.path))
                        {
                            pathToView = Path.path;
                            Dirs.PrintDirs(pathToView, numberOfElements);
                            Files.PrintFiles(pathToView, numberOfElements);
                        }
                        else
                        {
                            if (Dirs.Check(Path.path, pathToView))
                            {
                                pathToView = pathToView + (Path.path.StartsWith("\\") ? Path.path : "\\" + Path.path);
                                if (pathToView.Contains("\\\\"))
                                    pathToView = pathToView.Replace("\\\\", "\\");
                                Dirs.PrintDirs(pathToView, numberOfElements);
                                Files.PrintFiles(pathToView, numberOfElements);
                            }
                            else
                                Path.Error();
                        }
                    }
                    else if (selectedCommand == Commands.DELETE_FILE) // Удаление файла.
                    {
                        Console.Clear();
                        Path.GetPath(command, selectedCommand);
                        Files.DeleteFile(Path.path, pathToView);
                        Dirs.PrintDirs(pathToView, numberOfElements);
                        Files.PrintFiles(pathToView, numberOfElements);
                    }
                    else if (selectedCommand == Commands.GET_FILE_INFO) // Получение информации о файле.
                    {
                        Console.Clear();
                        Path.GetPath(command, selectedCommand);
                        Files.PrintFileInfo(Path.path, pathToView);
                        Dirs.PrintDirs(pathToView, numberOfElements);
                        Files.PrintFiles(pathToView, numberOfElements);
                    }
                    else if (selectedCommand == Commands.GET_DIR_INFO) // Получение информации о калоге.
                    {
                        Console.Clear();
                        Path.GetPath(command, selectedCommand);
                        Dirs.PrintDirInfo(Path.path, pathToView);
                        Dirs.PrintDirs(pathToView, numberOfElements);
                        Files.PrintFiles(pathToView, numberOfElements);
                    }
                    else if (selectedCommand == Commands.DELETE_DIR) // Удаление каталога.
                    {
                        Console.Clear();
                        Path.GetPath(command, selectedCommand);
                        Dirs.DeleteDir(Path.path, pathToView);
                        Dirs.PrintDirs(pathToView, numberOfElements);
                        Files.PrintFiles(pathToView, numberOfElements);
                    }
                    else if (selectedCommand == Commands.NEXT) // Вывод следующей страницы католов/файлов.
                    {
                        Console.Clear();
                        Dirs.PrintNextPage(pathToView, numberOfElements);
                        Files.PrintNextPage(pathToView, numberOfElements);
                    }
                    else if (selectedCommand == Commands.PREV) // Вывод предыдущей страницы каталогов/файлов.
                    {
                        Console.Clear();
                        Dirs.PrintPrevPage(pathToView, numberOfElements);
                        Files.PrintPrevPage(pathToView, numberOfElements);
                    }
                    else if (selectedCommand == Commands.COPY_FILE) // Копирование файла.
                    {
                        Console.Clear();
                        Path.GetPath(command, selectedCommand);
                        Files.CopyFile(Path.path, pathToView);
                    }
                    else if (selectedCommand == Commands.COPY_DIR) // Копирование дирректории.
                    {
                        Console.Clear();
                        Path.GetPath(command, selectedCommand);
                        Dirs.CopyDir(Path.path, pathToView);
                    }
                    else if (selectedCommand == Commands.COMMANDS_LIST) // Вывод спика всех доступных команд. 
                    {
                        Console.Clear();
                        CmdList.PrintAllCommands(); 
                    }
                }
                catch (Exception ex) // В случаее возникнования ошибки. 
                {
                    File.WriteAllText(exceptionFile, ex.Message); 
                }
            } while (true);
        }
    }
}
