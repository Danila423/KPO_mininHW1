using ZooConsoleApp.Domain.Interfaces;
using ZooConsoleApp.Domain.Models;

namespace ZooConsoleApp.Domain.Services
{
    /// <summary>
    /// Реализация нашего Зоопарка.
    /// </summary>
    public class Zoo : IZoo
    {
        private readonly IVetClinic _vetClinic;

        private readonly List<IInventory> _inventory = new();

        private readonly List<Animal> _animals = new();

        public Zoo(IVetClinic vetClinic)
        {
            _vetClinic = vetClinic;
        }

        public bool AddAnimal(Animal animal)
        {
            if (_vetClinic.CheckAnimalHealth(animal))
            {
                _animals.Add(animal);
                _inventory.Add(animal);
                return true;
            }
            return false;
        }

        public bool AddInventory(IInventory item)
        {
            // Если это животное — проверяем здоровье и добавляем
            if (item is Animal animal)
            {
                return AddAnimal(animal);
            }
            else
            {
                // Просто добавляем вещь
                _inventory.Add(item);
                return true;
            }
        }

        public IReadOnlyCollection<Animal> GetAllAnimals()
        {
            return _animals.AsReadOnly();
        }

        public int GetTotalFoodConsumption()
        {
            // Суммируем Food по всем животным
            return _animals.Sum(a => a.Food);
        }

        public IReadOnlyCollection<Herbo> GetContactZooAnimals()
        {
            // Ищем всех Herbo, у кого Kindness > 5
            return _animals
                .OfType<Herbo>()
                .Where(h => h.Kindness > 5)
                .ToList()
                .AsReadOnly();
        }

        public IReadOnlyCollection<IInventory> GetInventoryItems()
        {
            return _inventory.AsReadOnly();
        }
    }
}
