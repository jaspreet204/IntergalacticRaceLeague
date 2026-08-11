namespace IntergalacticRaceLeague.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int TopSpeed { get; set; }
        public List<Racer> Racers { get; set; }
    }
}
