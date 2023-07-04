using pokemonAPI.Model;

namespace pokemonAPI.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryID);
        bool CategoryExists(int id);
    }
}
