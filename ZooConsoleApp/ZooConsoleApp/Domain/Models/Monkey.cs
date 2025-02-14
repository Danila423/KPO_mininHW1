namespace ZooConsoleApp.Domain.Models
{
    /// <summary>
    /// Пример травоядного (или всеядного) животного - Обезьяна.
    /// </summary>
    public class Monkey : Herbo
    {
        public Monkey(string name, int inventoryNumber, int food, int kindness)
            : base(name, inventoryNumber, food, kindness)
        {
        }
    }
}
