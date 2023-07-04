using pokemonAPI.Data;
using pokemonAPI.Interfaces;
using pokemonAPI.Model;

namespace pokemonAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryID)
        {
            //pegar todos os pokemons na categoria que possui o id passado ex: todos os pokemons que possui o id de fogo
            return _context.PokemonCategories.Where(e => e.CategoryId == categoryID).Select(c => c.Pokemon).ToList();
        }
    }
}
