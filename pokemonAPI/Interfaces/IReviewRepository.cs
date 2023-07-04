using pokemonAPI.Model;

namespace pokemonAPI.Interfaces
{
    public interface IReviewRepository
    {

        ICollection<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewsOfAPokemon(int pokeId);
        bool ReviewExists(int id);
    }
}
