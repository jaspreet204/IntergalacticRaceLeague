using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague.BLL
{
    public class TournamentService
    {
        private readonly TournamentRepository _tournamentRepository;

        public TournamentService(TournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public List<Tournament> GetAll()
        {
            return _tournamentRepository.GetAll();
        }

        public Tournament? GetById(int id)
        {
            return _tournamentRepository.GetById(id);
        }

        public void Add(Tournament tournament)
        {
            _tournamentRepository.Add(tournament);
        }

        public void Update(Tournament tournament)
        {
            _tournamentRepository.Update(tournament);
        }

        public void Delete(Tournament tournament)
        {
            _tournamentRepository.Delete(tournament);
        }
    }
}