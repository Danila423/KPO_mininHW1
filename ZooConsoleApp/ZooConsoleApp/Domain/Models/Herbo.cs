namespace ZooConsoleApp.Domain.Models
{
    /// <summary>
    /// Базовый класс для травоядных животных.
    /// </summary>
    public abstract class Herbo : Animal
    {
        /// <summary>
        /// Уровень доброты (0..10).
        /// Если > 5, то животное может участвовать
        /// в контактном зоопарке.
        /// </summary>
        public int Kindness { get; set; }

        public Herbo(string name, int inventoryNumber, int food, int kindness)
            : base(name, inventoryNumber, food)
        {
            Kindness = kindness;
        }
    }
}
