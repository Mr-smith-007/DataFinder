using DataFinder.BLL;
using System;

namespace DataFinder.PLL
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileService = new DataFinder.BLL.FileService();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Data Finder v.1.0");
                Console.WriteLine("Отобразить все файлы - нажмите \"1\"");
                Console.WriteLine("Выполнить поиск файла по имени - нажмите \"2\"");

                string inputValue = Console.ReadLine();

                if (inputValue == "1")
                {
                    fileService.GetAllFiles().ToList().ForEach(file =>
                    {
                        Console.WriteLine($"Идентификатор: {file.Id}, Имя файла: {file.Name}, Путь: {file.Path}");
                    });
                }
                if (inputValue == "2")
                {
                    Console.Write("Введите имя файла, который хотите найти:");
                    string fileName = Console.ReadLine();
                    try
                    {
                        var file = fileService.GetFileByFileName(fileName);
                        Console.WriteLine($"Идентификатор: {file.Id}, Имя файла: {file.Name}, Путь: {file.Path}");
                    }
                    catch (BusinessRuleException ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}