namespace ZooConsoleApp.Domain.Models
{
    /// <summary>
    /// Пример травоядного животного - Кролик.
    /// </summary>
    public class Rabbit : Herbo
    {
        public Rabbit(string name, int inventoryNumber, int food, int kindness)
            : base(name, inventoryNumber, food, kindness)
        {
        }
    }
}
