namespace pokemonAPI.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Country> Countries { get; set;}

    }
}
