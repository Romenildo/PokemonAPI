using pokemonAPI.Model;

namespace pokemonAPI.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();


    }
}
