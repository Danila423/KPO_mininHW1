using ZooConsoleApp.Domain.Interfaces;
using ZooConsoleApp.Domain.Models;

namespace ZooConsoleApp.Domain.Services
{
    /// <summary>
    /// Интерфейс нашего Зоопарка.
    /// </summary>
    public interface IZoo
    {
        /// <summary>
        /// Добавить животное в зоопарк (с проверкой здоровья).
        /// </summary>
        /// <param name="animal">Животное</param>
        /// <returns>true, если успешно принято</returns>
        bool AddAnimal(Animal animal);


        bool AddInventory(IInventory item);

        IReadOnlyCollection<Animal> GetAllAnimals();

        int GetTotalFoodConsumption();

        IReadOnlyCollection<Herbo> GetContactZooAnimals();

        IReadOnlyCollection<IInventory> GetInventoryItems();
    }
}
