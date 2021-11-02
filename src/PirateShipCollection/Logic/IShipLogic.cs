using PirateShipCollection.Models;

namespace PirateShipCollection.Logic
{
    public interface IShipLogic
    {
        int CreateShip(Ship ship);
        int UpdateShip(Ship ship);
        int DeleteShip(int shipId);
        Ship? GetShipById(int shipId);
    }
}