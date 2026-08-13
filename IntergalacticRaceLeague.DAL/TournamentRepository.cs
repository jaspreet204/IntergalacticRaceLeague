using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.DAL
{
    public class TournamentRepository
    {
        private readonly RaceLeagueContext _context;
        public TournamentRepository(RaceLeagueContext context)
        {
            _context = context;
        }
        public List<Tournament> GetAll()
        {
            return _context.Tournaments.ToList();
        }
        public Tournament? GetById(int id)
        {
            return _context.Tournaments
                .FirstOrDefault(t => t.Id == id);
        }
        public void Add(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            _context.SaveChanges();
        }
        public void Update(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
            _context.SaveChanges();
        }
        public void Delete(Tournament tournament)
        {
            _context.Tournaments.Remove(tournament);
            _context.SaveChanges();
        }
    }
}