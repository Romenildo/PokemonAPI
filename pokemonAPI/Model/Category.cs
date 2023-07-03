namespace pokemonAPI.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //many to many
        //Uma categoria pode ter varios pokemons
        public ICollection<PokemonCategory> pokemonCategories { get; set; }
    }
}
