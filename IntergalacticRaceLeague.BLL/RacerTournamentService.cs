using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.BLL
{
    public class RacerTournamentService
    {
        private readonly RacerTournamentRepository _racerTournamentRepository;

        public RacerTournamentService(RacerTournamentRepository racerTournamentRepository)
        {
            _racerTournamentRepository = racerTournamentRepository;
        }

        public void Add(RacerTournament racerTournament)
        {
            _racerTournamentRepository.Add(racerTournament);
        }

        public List<RacerTournament> GetAll()
        {
            return _racerTournamentRepository.GetAll();
        }
    }
}