﻿using pokemonAPI.Data;
using pokemonAPI.Interfaces;
using pokemonAPI.Model;

namespace pokemonAPI.Repository
{
    public class ReviewRepository : IReviewRepository
    {

        private readonly DataContext _context;
        public ReviewRepository(DataContext context) 
        {
            _context= context;
        }
        public Review GetReview(int id)
        {
            return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(r => r.Pokemon.Id == pokeId).ToList();
        }

        public bool ReviewExists(int id)
        {
            return _context.Reviews.Any(r => r.Id == id);
        }
    }
}
