using ZooConsoleApp.Domain.Models;

namespace ZooConsoleApp.Domain.Services
{
    public class VetClinic : IVetClinic
    {
        public bool CheckAnimalHealth(Animal animal)
        {
            return animal.Food > 0;
        }
    }
}
