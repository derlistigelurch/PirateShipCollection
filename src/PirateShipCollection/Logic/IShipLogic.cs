using PirateShipCollection.Models;

namespace PirateShipCollection.Logic
{
    public interface IShipLogic
    {
        void CreateShip(Ship ship);
        void UpdateShip(Ship ship);
        void DeleteShip(int shipId);
        Ship? GetShipById(int shipId);
    }
}