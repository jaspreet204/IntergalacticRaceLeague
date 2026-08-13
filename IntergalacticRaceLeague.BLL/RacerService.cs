using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.BLL
{
    public class RacerService
    {
        private readonly RacerRepository _racerRepository;
        public RacerService(RacerRepository racerRepository)
        {
            _racerRepository = racerRepository;
        }
        public List<Racer> GetAll()
        {
            return _racerRepository.GetAll();
        }
        public Racer? GetById(int id)
        {
            return _racerRepository.GetById(id);
        }
        public void Add(Racer racer)
        {
            _racerRepository.Add(racer);
        }
        public void Update(Racer racer)
        {
            _racerRepository.Update(racer);
        }
        public void Delete(Racer racer)
        {
            _racerRepository.Delete(racer);
        }
    }
}