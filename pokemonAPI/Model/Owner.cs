namespace pokemonAPI.Model
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gym { get; set; }

        //One to one
        //um dono tem uma cidade
        public Country Country { get; set; }

        //Many to many
        //Um dono pode ter varios Pokemons, e um pokemon pode ter varios donos
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
    }
}
