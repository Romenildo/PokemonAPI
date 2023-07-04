using pokemonAPI.Data;
using pokemonAPI.Interfaces;
using pokemonAPI.Model;

namespace pokemonAPI.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context) 
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            //pegar todas as review quais possui o pokemon passado como id
            var reviews = _context.Reviews.Where(r => r.Pokemon.Id == pokeId);

            if(reviews.Count() > 0)
            {
                return 0;
            }
            //Fazer a media de todas as notas das review do pokemon
            return ((decimal)reviews.Sum(r => r.Rating) / reviews.Count());

        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId);
        }
    }
}
