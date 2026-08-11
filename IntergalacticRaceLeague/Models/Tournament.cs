namespace IntergalacticRaceLeague.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Location { get; set; } = "";
        public DateTime TournamentDate { get; set; }
        public string Status { get; set; } = "";
        public List<RacerTournament> RacerTournaments { get; set; }
            = new List<RacerTournament>();
    }
}
