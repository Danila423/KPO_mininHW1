namespace ZooConsoleApp.Domain.Models
{
    /// <summary>
    /// Стол.
    /// </summary>
    public class Table : Thing
    {
        public Table(string title, int number) : base(title, number)
        {
        }
    }
}
