namespace pokemonAPI.Model
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }


        //One to many
        //Um pokemon podee ter varias review de varios usuarios
        public ICollection<Review> Reviews { get; set; }

        //Many to Many
        //Um pokemon pode ter varios donos e os donos podem ter varios pokemons
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        //Um pokemon pode ter varias categorias, e uma categoria tem varios pokemons
        public ICollection<PokemonCategory> pokemonCategories { get; set; }



    }
}
