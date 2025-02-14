namespace ZooConsoleApp.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для "живых" сущностей.
    /// </summary>
    public interface IAlive
    {
        /// <summary>
        /// Количество потребляемой еды (в кг) в сутки.
        /// </summary>
        int Food { get; set; }
    }
}
