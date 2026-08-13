using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.DAL
{
    public class RacerTournamentRepository
    {
        private readonly RaceLeagueContext _context;

        public RacerTournamentRepository(RaceLeagueContext context)
        {
            _context = context;
        }

        public void Add(RacerTournament racerTournament)
        {
            _context.RacerTournaments.Add(racerTournament);
            _context.SaveChanges();
        }

        public List<RacerTournament> GetAll()
        {
            return _context.RacerTournaments.ToList();
        }
    }
}