namespace ZooConsoleApp.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс для объектов, подлежащих инвентаризации.
    /// </summary>
    public interface IInventory
    {
        /// <summary>
        /// Инвентаризационный номер.
        /// </summary>
        int Number { get; set; }
    }
}
