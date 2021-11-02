using Microsoft.Extensions.Logging;
using PirateShipCollection.Models;
using PirateShipCollection.Repositories;

namespace PirateShipCollection.Logic
{
    public class ShipLogic : IShipLogic
    {
        private readonly IShipRepository _shipRepository;
        private readonly ILogger<ShipLogic> _logger;

        public ShipLogic(IShipRepository shipRepository, ILogger<ShipLogic> logger)
        {
            _shipRepository = shipRepository;
            _logger = logger;
        }

        public int CreateShip(Ship ship)
        {
            return _shipRepository.Create(ship);
        }

        public int UpdateShip(Ship ship)
        {
            return _shipRepository.Update(ship);
        }

        public int DeleteShip(int shipId)
        {
            return _shipRepository.Delete(shipId);
        }

        public Ship? GetShipById(int shipId)
        {
            return _shipRepository.GetById(shipId);
        }
    }
}