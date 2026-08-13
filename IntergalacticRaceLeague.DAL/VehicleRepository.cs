using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.DAL
{
    public class VehicleRepository
    {
        private readonly RaceLeagueContext _context;
        public VehicleRepository(RaceLeagueContext context)
        {
            _context = context;
        }
        public List<Vehicle> GetAll()
        {
            return _context.Vehicles.ToList();
        }
        public Vehicle? GetById(int id)
        {
            return _context.Vehicles
                .FirstOrDefault(v => v.Id == id);
        }
        public void Add(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }
        public void Update(Vehicle vehicle)
        {
            _context.SaveChanges();
        }
        public void Delete(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
        }
    }
}