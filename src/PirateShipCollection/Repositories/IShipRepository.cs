using PirateShipCollection.Models;

namespace PirateShipCollection.Repositories
{
    public interface IShipRepository
    {
        void Create(Ship ship);
        void Update(Ship ship);
        void Delete(int id);
        Ship GetById(int id);
        void DeleteDatabase();
        void FillDatabase();
    }
}