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
            _shipRepository.DeleteDatabase();
        }

        public int FillDatabase()
        {
            return _shipRepository.FillDatabase();
        }
    }
}