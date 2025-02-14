using ZooConsoleApp.Domain.Interfaces;

namespace ZooConsoleApp.Domain.Models
{
    /// <summary>
    /// Базовый класс для всех животных.
    /// </summary>
    public abstract class Animal : IAlive, IInventory
    {
        public int Food { get; set; }
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;

        public Animal(string name, int inventoryNumber, int food)
        {
            Name = name;
            Number = inventoryNumber;
            Food = food;
        }
    }
}
