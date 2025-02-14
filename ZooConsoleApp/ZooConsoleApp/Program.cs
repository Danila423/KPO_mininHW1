using Microsoft.Extensions.DependencyInjection;
using ZooConsoleApp.Domain.Models;
using ZooConsoleApp.Domain.Services;

namespace ZooConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Конфигурируем DI-контейнер
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // 2. Получаем наш сервис-зоопарк
            var zoo = serviceProvider.GetRequiredService<IZoo>();

            // Небольшое текстовое меню
            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить новое животное");
                Console.WriteLine("2. Добавить новый инвентарь");
                Console.WriteLine("3. Вывести суммарное потребление еды всеми животными");
                Console.WriteLine("4. Вывести список животных для контактного зоопарка");
                Console.WriteLine("5. Вывести список всего инвентаря (включая животных)");
                Console.WriteLine("6. Выход");

                Console.Write("Введите номер пункта: ");
                var input = Console.ReadLine();

                if (input == "1")
                {
                    AddAnimal(zoo);
                }
                else if (input == "2")
                {
                    AddThing(zoo);
                }
                else if (input == "3")
                {
                    PrintTotalFoodConsumption(zoo);
                }
                else if (input == "4")
                {
                    PrintContactZooAnimals(zoo);
                }
                else if (input == "5")
                {
                    PrintInventory(zoo);
                }
                else if (input == "6")
                {
                    Console.WriteLine("Завершение работы...");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный пункт меню!");
                }
            }
        }

        private static void AddAnimal(IZoo zoo)
        {
            Console.Write("Введите имя животного: ");
            var name = Console.ReadLine() ?? "NoName";

            Console.Write("Введите инвентарный номер: ");
            var numberStr = Console.ReadLine();
            int.TryParse(numberStr, out var number);

            Console.Write("Введите количество потребляемой еды (кг в сутки): ");
            var foodStr = Console.ReadLine();
            int.TryParse(foodStr, out var food);

            Console.WriteLine("Выберите тип животного:");
            Console.WriteLine("1 - Обезьяна");
            Console.WriteLine("2 - Кролик");
            Console.WriteLine("3 - Тигр");
            Console.WriteLine("4 - Волк");
            var choice = Console.ReadLine();

            Animal animal;
            switch (choice)
            {
                case "1":
                    Console.Write("Введите уровень доброты (0..10): ");
                    int.TryParse(Console.ReadLine(), out var kind1);
                    animal = new Monkey(name, number, food, kind1);
                    break;
                case "2":
                    Console.Write("Введите уровень доброты (0..10): ");
                    int.TryParse(Console.ReadLine(), out var kind2);
                    animal = new Rabbit(name, number, food, kind2);
                    break;
                case "3":
                    animal = new Tiger(name, number, food);
                    break;
                case "4":
                    animal = new Wolf(name, number, food);
                    break;
                default:
                    Console.WriteLine("Неверный выбор, создадим обезьяну по умолчанию.");
                    animal = new Monkey(name, number, food, 5);
                    break;
            }

            var result = zoo.AddAnimal(animal);
            if (result)
            {
                Console.WriteLine($"Животное {animal.Name} добавлено в зоопарк!");
            }
            else
            {
                Console.WriteLine($"Животное {animal.Name} не прошло проверку и не добавлено.");
            }
        }

        private static void AddThing(IZoo zoo)
        {
            Console.Write("Введите название предмета: ");
            var title = Console.ReadLine() ?? "NoTitle";

            Console.Write("Введите инвентарный номер: ");
            var numberStr = Console.ReadLine();
            int.TryParse(numberStr, out var number);

            Console.WriteLine("Выберите тип предмета:");
            Console.WriteLine("1 - Стол");
            Console.WriteLine("2 - Компьютер");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                var table = new Table(title, number);
                zoo.AddInventory(table);
                Console.WriteLine($"Предмет '{table.Title}' добавлен (Стол).");
            }
            else if (choice == "2")
            {
                var comp = new Computer(title, number);
                zoo.AddInventory(comp);
                Console.WriteLine($"Предмет '{comp.Title}' добавлен (Компьютер).");
            }
            else
            {
                Console.WriteLine("Неверный выбор, ничего не добавлено.");
            }
        }

        private static void PrintTotalFoodConsumption(IZoo zoo)
        {
            var totalFood = zoo.GetTotalFoodConsumption();
            Console.WriteLine($"Суммарное потребление еды всеми животными в сутки: {totalFood} кг");
        }

        private static void PrintContactZooAnimals(IZoo zoo)
        {
            var contactAnimals = zoo.GetContactZooAnimals();
            if (contactAnimals.Count == 0)
            {
                Console.WriteLine("Нет животных, пригодных для контактного зоопарка.");
            }
            else
            {
                Console.WriteLine("Животные для контактного зоопарка:");
                foreach (var a in contactAnimals)
                {
                    Console.WriteLine($"- {a.Name}, Kindness = {a.Kindness}");
                }
            }
        }

        private static void PrintInventory(IZoo zoo)
        {
            var items = zoo.GetInventoryItems();
            Console.WriteLine("Список всего инвентаря (вкл. животных):");
            foreach (var item in items)
            {
                if (item is Animal animal)
                {
                    Console.WriteLine($"[Animal] {animal.Name}, инв.номер = {animal.Number}");
                }
                else if (item is Thing thing)
                {
                    Console.WriteLine($"[Thing] {thing.Title}, инв.номер = {thing.Number}");
                }
            }
        }

        /// <summary>
        /// Регистрируем зависимости в DI-контейнере
        /// </summary>
        private static void ConfigureServices(IServiceCollection services)
        {
            // Добавляем в контейнер реализацию нашей вет.клиники
            services.AddSingleton<IVetClinic, VetClinic>();
            // Добавляем в контейнер реализацию Zoo
            services.AddSingleton<IZoo, Zoo>();
        }
    }
}
