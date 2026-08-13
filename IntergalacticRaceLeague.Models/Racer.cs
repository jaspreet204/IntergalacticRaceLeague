namespace IntergalacticRaceLeague.Models
{
    public class Racer
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Planet { get; set; } = "";
        public int Age { get; set; }
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public string UserId { get; set; } = "";
        public List<RacerTournament> RacerTournaments { get; set; }
            = new List<RacerTournament>();
    }
}
