using PirateShipCollection.Models;

namespace PirateShipCollection.Repositories
{
    public interface IShipRepository
    {
        int Create(Ship ship);
        int Update(Ship ship);
        int Delete(int id);
        Ship? GetById(int id);
        void DeleteDatabase();
        int FillDatabase();
    }
}