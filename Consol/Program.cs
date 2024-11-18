/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consol
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class FileInfo
    {
        public string Name { get; set; }
        public long Size { get; set; } // размер  в байтах 
        public DateTime DateChanged { get; set; } // Дата последнего измения 
        public TimeSpan TimeChanged { get; set; } // Время последнего изменения

        public FileInfo(string name, long size, DateTime dateChanged, TimeSpan timeChanged)
        {
            Name = name;
            Size = size;
            DateChanged = dateChanged;
            TimeChanged = timeChanged;
        }

        // Метод для определения, является ли текущий экземпляр каталогом
        public bool IsDirectory()
        {
            return Size < 0; // Использование < 0 для определения каталогов
        }

        // Display Name являеться ли элемнентом каталога
        public string DisplayName => IsDirectory() ? $"{Name}/" : Name;
        public override string ToString()
        {
            return $"{DisplayName,-30}{(IsDirectory() ? "" : Size.ToString()),10}{DateChanged.ToShortDateString(),15}{TimeChanged}";
        }
    }



    class Program
    {
        private static object displayName;
        private static object displayName1;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //encoding 
            Console.Title = "Norton Commander Clone";
            Console.WindowWidth = 118;
            Console.WindowHeight = 25;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Моделирование списка файлов и каталогов
            List<FileInfo> files = new List<FileInfo>
        {
            new FileInfo("MyDocument.txt", 2048, DateTime.Now.AddDays(-5), new TimeSpan(14, 30, 0)),
            new FileInfo("Report.pdf", 10240, DateTime.Now.AddDays(-2), new TimeSpan(9, 15, 0)),
            new FileInfo("Image.png", 512, DateTime.Now.AddDays(-10), new TimeSpan(10, 45, 0)),
            new FileInfo("MyFileWithLongName.txt", 3072, DateTime.Now, new TimeSpan(11, 30, 0)),
            new FileInfo("Data", -1, DateTime.Now.AddDays(-1), new TimeSpan(20, 0, 0)), // Каталог
            new FileInfo("AnotherLongFileNameThatNeedsAbbreviating.txt", 4096, DateTime.Now.AddDays(-3), new TimeSpan(15, 0, 0)),
            new FileInfo("Sample.txt", 512, DateTime.Now.AddDays(-4), new TimeSpan(16, 30, 0)),
            new FileInfo("Directory1", -1, DateTime.Now.AddDays(-7), new TimeSpan(10, 0, 0)), // Каталог
            new FileInfo("disn.txt", 2014, DateTime.Now.AddDays(-8), new TimeSpan(10, 0, -0)),
            new FileInfo("home.png", 2048, DateTime.Now.AddDays(-24), new TimeSpan(12, 0, -0)),


        };

            //  Сортировка файлов по имени
            var sortedFiles = files.OrderBy(f => f.Name).ToList();
            int fileCount = Math.Min(10, sortedFiles.Count); // Отображение первых 10 файлов

            // Отображение интерфейса
            DisplayInterface(sortedFiles, fileCount);
        }

        private static void DisplayInterface(List<FileInfo> files)
        {
            throw new NotImplementedException();
        }

        static void DisplayInterface(IEnumerable<FileInfo> files, int fileCount)
        {
            Console.Clear();

            // Отображение заголовка
            Console.WriteLine($"\u2593▓{"Левая▓▓▓▓▓"}{"Файл▓▓▓▓▓▓▓▓▓▓"}{"Диск▓▓▓▓▓▓▓▓▓▓"}{"Команды▓▓▓▓▓▓▓▓▓▓▓▓"}{"Правая"}▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");

            // верхняя граница
            Console.WriteLine($"▓╔══════════════════════════════════════════════════════╗ ╔══════════════════════════════════════════════════════╗▓");
            //Console.WriteLine(new string('═', 30));
            //Console.WriteLine(new string('╗', 1));
            //Console.WriteLine(new string('╔', 1));
            //Console.WriteLine(new string('═', 30));
            Console.WriteLine($"▓║                                                      ║ ║                                                      ║▓");

            // Отображение меток столбцов
            Console.WriteLine($"▓╠══ {"Имя C:/",-10}═══\u2557 ╔══ {"Имя C:/",-10}═══╗ ╔══ {"Имя C:/",-10}═══╣ ╠══ {"Имя C:/",-8}═══╗ \u2554═ {"Размер",-7}═╗ \u2554═══{"Дата",6} ════╗╔═{"Время",5} ═╣▓");

            // Отображение файлов и каталогов
            foreach (var file in files)
            {
                // Сокращение длинны имени файла
                string displayName = file.DisplayName.Length > 12
                    ? $"{file.DisplayName.Substring(0, 12)}~"
                    : file.DisplayName;

                // подстроение формата
                string output = $"▓\u2551{displayName,-15} \u2551 " +
                                $"\u2551{displayName,-15} \u2551 " +
                                $"\u2551{displayName,-15} \u2551 " +
                                $"\u2551{displayName,-13} \u2551 " +
                                $"║{(file.IsDirectory() ? string.Empty : file.Size.ToString()),9} ║ " +
                                $"║{file.DateChanged.ToShortDateString(),12}  ║" +
                                $"║{file.TimeChanged}║▓";
                Console.WriteLine(output);

            }
            //нижняя Часть таблицы
            Console.WriteLine($"▓\u255A════════════════\u2569═╩════════════════╩═╩════════════════\u255D ╚══════════════╩═╩══════════╩═╩══════════════╩╩════════╝▓");

            Console.WriteLine($"▓             Каталог: {DateTime.Now}                            Каталог: {DateTime.Now}                ▓");

            //  нижняя граница
            Console.WriteLine($"▓\u255A═══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝▓");

            //  Отображение нижнего меню
            Console.WriteLine($"▓{"1 Помощь",-10}{"2 Вызовы",-10}{"3 Чтение",-10}{"4 Правка",-10}{"5 Копия",-10}{"6 НовИмя",-10}{"7 НовКат",-10}{"8 Удал-е",-10}{"9 Меню",-10}{"10 выход",-10}             ▓");

        }
    }
}

