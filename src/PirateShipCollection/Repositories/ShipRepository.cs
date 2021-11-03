using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using PirateShipCollection.Models;

namespace PirateShipCollection.Repositories
{
    public class ShipRepository : IShipRepository
    {
        private readonly DbContext _dbContext;
        private readonly ILogger<ShipRepository> _logger;

        public ShipRepository(DbContext dbContext, ILogger<ShipRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Create(Ship ship)
        {
            _logger.LogInformation("Adding a new ship to the collection.");
            _dbContext.Ships.Add(ship);
            _dbContext.SaveChanges();
        }

        public void Update(Ship ship)
        {
            _logger.LogInformation("Updating a ship in the collection.");

            var oldShip = GetById(ship.Id);
            ship.DbId = oldShip.DbId;
            _dbContext.Entry(oldShip).CurrentValues.SetValues(ship);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _logger.LogInformation("Remove a ship from the collection.");

            var ship = GetById(id);
            _dbContext.Ships.Remove(ship);

            _dbContext.SaveChanges();
        }

        public Ship GetById(int id)
        {
            _logger.LogInformation("Get ship by id.");
            var ship = _dbContext.Ships.SingleOrDefault(s => s.Id == id);
            if (ship is not null)
                return ship;

            _logger.LogWarning($"Ship not found.{Environment.NewLine}Id: {id}");
            throw new Exception("Ship not found.");
        }

        public void DeleteDatabase()
        {
            _dbContext.Database.EnsureCreated();

            _logger.LogInformation("Delete database.");
            _dbContext.Database.EnsureDeleted();

            _logger.LogInformation("Create database.");
            _dbContext.Database.EnsureCreated();
        }

        public void FillDatabase()
        {
            _logger.LogInformation("Fill database with values for testing.");
            var ships = new[]
            {
                new Ship()
                {
                    Id = 1,
                    Category = "Big ship",
                    Name = "Gud ship",
                    Height = 100,
                    Length = 100,
                    Width = 30,
                    Weight = 3034
                },
                new Ship()
                {
                    Id = 2,
                    Category = "Small ship",
                    Name = "Kanuuu",
                    Height = 13,
                    Length = 15,
                    Width = 7,
                    Weight = 200
                },
                new Ship()
                {
                    Id = 3,
                    Category = "Damaged ship",
                    Name = "Damaged ship",
                    Height = 30,
                    Length = 50,
                    Width = 30,
                    Weight = 499
                },
                new Ship()
                {
                    Id = 4,
                    Category = "Tiny ship",
                    Name = "Black Mongoose",
                    Height = 33,
                    Length = 10,
                    Width = 5,
                    Weight = 134
                }
            };

            _dbContext.Ships.AddRange(ships);
            _dbContext.SaveChanges();
        }
    }
}