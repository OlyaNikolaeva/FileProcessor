namespace FileProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Поиск самого старшего человека
            var people = new List<Person>
            {
                new Person { Name = "Петр", Age = 30 },
                new Person { Name = "Иван", Age = 25 },
                new Person { Name = "Аркадий", Age = 35 }
            };

            var oldest = people.GetMax(p => p.Age);
            if (oldest != null)
                Console.WriteLine($"Самый взрослый человек: {oldest.Name}, лет: {oldest.Age}");
            else
                Console.WriteLine("Нет списка людей.");

            // 2. Поиск сотрудника с самой высокой зарплатой
            var employees = new List<Employee>
            {
                new Employee { Name = "Никита", Salary = 50000 },
                new Employee { Name = "Алина", Salary = 75000 },
                new Employee { Name = "Лена", Salary = 60000 }
            };

            var highestPaidEmployee = employees.GetMax(e => e.Salary);

            if (highestPaidEmployee != null)
                Console.WriteLine($"Сотрудник: {highestPaidEmployee.Name}, с высокой зарплатой: {highestPaidEmployee.Salary}");
            else
                Console.WriteLine("Нет списка сотрудников.");

            Console.Write("Введите путь к каталогу файлов: ");
            string? path = Console.ReadLine();

            var scanner = new Scanner();
            scanner.FileFound += ScannerFileFound;

            try
            {
                if (path != null)
                    scanner.ScanDirectory(path);
                else
                    Console.Write("Путь к каталогу пуст.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при вводе директории: {ex.Message}");
            }
        }

        private static void ScannerFileFound(object? sender, FileArgs e)
        {
            Console.WriteLine($"Файл: {e.FileName}");

            // Пример отмены поиска
            if (e.FileName.EndsWith(".txt"))
            {
                Console.WriteLine("Остановка поиска.");
                e.Cancel = true;
            }
        }
    }
}
