using ZooConsoleApp.Domain.Models;

namespace ZooConsoleApp.Domain.Services
{
    /// <summary>
    /// Интерфейс ветеринарной клиники,
    /// которая проверяет здоровье животного.
    /// </summary>
    public interface IVetClinic
    {
        /// <summary>
        /// Проверяет состояние здоровья и решает,
        /// можно ли принять животное.
        /// </summary>
        /// <param name="animal">Новое животное</param>
        /// <returns>true - если животное здорово и может быть принято</returns>
        bool CheckAnimalHealth(Animal animal);
    }
}
