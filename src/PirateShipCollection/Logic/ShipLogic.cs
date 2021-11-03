using System;
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

        public void CreateShip(Ship ship)
        {
            _logger.LogInformation($"Create ship.{Environment.NewLine}Ship:{Environment.NewLine}{ship}");
            _shipRepository.Create(ship);
        }

        public void UpdateShip(Ship ship)
        {
            _logger.LogInformation($"Update ship.{Environment.NewLine}New ship:{Environment.NewLine}{ship}");
            _shipRepository.Update(ship);
        }

        public void DeleteShip(int shipId)
        {
            _logger.LogInformation($"Delete ship.{Environment.NewLine}Id: {shipId}");
            _shipRepository.Delete(shipId);
        }

        public Ship GetShipById(int shipId)
        {
            _logger.LogInformation($"Get ship by id.{Environment.NewLine}Id: {shipId}");
            var ship = _shipRepository.GetById(shipId);
            if (ship is not null)
                return ship;

            _logger.LogWarning($"Ship not found.{Environment.NewLine}Id: {shipId}");
            throw new Exception("Ship not found");
        }
    }
}