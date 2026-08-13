using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.BLL
{
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleRepository;
        public VehicleService(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public List<Vehicle> GetAll()
        {
            return _vehicleRepository.GetAll();
        }
        public Vehicle? GetById(int id)
        {
            return _vehicleRepository.GetById(id);
        }
        public void Add(Vehicle vehicle)
        {
            _vehicleRepository.Add(vehicle);
        }
        public void Update(Vehicle vehicle)
        {
            _vehicleRepository.Update(vehicle);
        }
        public void Delete(Vehicle vehicle)
        {
            _vehicleRepository.Delete(vehicle);
        }
    }
}