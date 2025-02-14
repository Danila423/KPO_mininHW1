namespace ZooConsoleApp.Domain.Models
{
    /// <summary>
    /// Базовый класс для хищных животных.
    /// </summary>
    public abstract class Predator : Animal
    {
        public Predator(string name, int inventoryNumber, int food)
            : base(name, inventoryNumber, food)
        {
        }
    }
}
