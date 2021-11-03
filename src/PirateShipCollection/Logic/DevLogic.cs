using Microsoft.Extensions.Logging;
using PirateShipCollection.Repositories;

namespace PirateShipCollection.Logic
{
    public class DevLogic : IDevLogic
    {
        private readonly IShipRepository _shipRepository;
        private readonly ILogger<ShipLogic> _logger;

        public DevLogic(IShipRepository shipRepository, ILogger<ShipLogic> logger)
        {
            _shipRepository = shipRepository;
            _logger = logger;
        }

        public void DeleteDatabase()
        {
            _logger.LogInformation("Delete and re-create database.");
            _shipRepository.DeleteDatabase();
        }

        public void FillDatabase()
        {
            _logger.LogInformation("Fill database with test values.");
            _shipRepository.FillDatabase();
        }
    }
}