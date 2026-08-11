namespace IntergalacticRaceLeague.Models
{
    public class RacerTournament
    {
        public int RacerId { get; set; }
        public Racer Racer { get; set; } = null!;
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;
        public int Position { get; set; }
        public int FinishTime { get; set; }
    }
}
