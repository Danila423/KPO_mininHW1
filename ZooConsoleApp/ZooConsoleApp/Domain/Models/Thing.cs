using ZooConsoleApp.Domain.Interfaces;

namespace ZooConsoleApp.Domain.Models
{
    /// <summary>
    /// Базовый класс для не-живых объектов (вещей), состоящих на балансе.
    /// </summary>
    public class Thing : IInventory
    {
        public int Number { get; set; }

        /// <summary>
        /// Наименование вещи.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        public Thing(string title, int number)
        {
            Title = title;
            Number = number;
        }
    }
}
