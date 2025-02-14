namespace ZooConsoleApp.Domain.Models
{
    /// <summary>
    /// Тигр.
    /// </summary>
    public class Tiger : Predator
    {
        public Tiger(string name, int inventoryNumber, int food)
            : base(name, inventoryNumber, food)
        {
        }
    }
}
