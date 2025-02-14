namespace ZooConsoleApp.Domain.Models
{
    /// <summary>
    /// Волк.
    /// </summary>
    public class Wolf : Predator
    {
        public Wolf(string name, int inventoryNumber, int food)
            : base(name, inventoryNumber, food)
        {
        }
    }
}
