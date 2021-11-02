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

        public int Create(Ship ship)
        {
            _dbContext.Ships.Add(ship);
            return _dbContext.SaveChanges() > 0
                ? ship.Id
                : -1;
        }

        public int Update(Ship ship)
        {
            var oldShip = GetByCode(ship.Code);
            _dbContext.Entry(oldShip).CurrentValues.SetValues(ship);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var ship = GetById(id);
            if (ship is null)
                return -1;

            _dbContext.Ships.Remove(ship);
            return _dbContext.SaveChanges();
        }

        public Ship? GetById(int id)
        {
            return _dbContext.Ships.SingleOrDefault(s => s.Id == id);
        }

        public void DeleteDatabase()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        public int FillDatabase()
        {
            var ships = new[]
            {
                new Ship()
                {
                    Code = 1,
                    Category = "Big ship",
                    Name = "Gud ship",
                    Height = 100,
                    Length = 100,
                    Width = 30,
                    Weight = 3034
                },
                new Ship()
                {
                    Code = 2,
                    Category = "Small ship",
                    Name = "Kanuuu",
                    Height = 13,
                    Length = 15,
                    Width = 7,
                    Weight = 200
                },
                new Ship()
                {
                    Code = 3,
                    Category = "Damaged ship",
                    Name = "Damaged ship",
                    Height = 30,
                    Length = 50,
                    Width = 30,
                    Weight = 499
                },
                new Ship()
                {
                    Code = 4,
                    Category = "Tiny ship",
                    Name = "Black Mongoose",
                    Height = 33,
                    Length = 10,
                    Width = 5,
                    Weight = 134
                }
            };

            _dbContext.Ships.AddRange(ships);
            return _dbContext.SaveChanges();
        }

        private Ship? GetByCode(int code)
        {
            return _dbContext.Ships.FirstOrDefault(s => s.Code == code);
        }
    }
}