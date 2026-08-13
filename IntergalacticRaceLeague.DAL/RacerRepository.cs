using IntergalacticRaceLeague.Models;
using Microsoft.EntityFrameworkCore;

namespace IntergalacticRaceLeague.DAL
{
    public class RacerRepository
    {
        private readonly RaceLeagueContext _context;

        public RacerRepository(RaceLeagueContext context)
        {
            _context = context;
        }

        public List<Racer> GetAll()
        {
            return _context.Racers
                .Include(r => r.Vehicle)
                .ToList();
        }

        public Racer? GetById(int id)
        {
            return _context.Racers
                .Include(r => r.Vehicle)
                .FirstOrDefault(r => r.Id == id);
        }

        public void Add(Racer racer)
        {
            _context.Racers.Add(racer);
            _context.SaveChanges();
        }

        public void Update(Racer racer)
        {
            _context.Racers.Update(racer);
            _context.SaveChanges();
        }

        public void Delete(Racer racer)
        {
            _context.Racers.Remove(racer);
            _context.SaveChanges();
        }
    }
}