namespace IntergalacticRaceLeague.Models
{
    public class RacerTournament
    {
        public int RacerId { get; set; }

        public Racer? Racer { get; set; }

        public int TournamentId { get; set; }

        public Tournament? Tournament { get; set; }

        public int Position { get; set; }

        public int FinishTime { get; set; }
    }
}