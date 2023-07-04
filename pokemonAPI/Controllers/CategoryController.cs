using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pokemonAPI.Dtos;
using pokemonAPI.Interfaces;
using pokemonAPI.Model;
using pokemonAPI.Repository;

namespace pokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _repository = categoryRepository;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_repository.GetCategories());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_repository.CategoryExists(categoryId))
            {
                return NotFound();
            }

            var category = _mapper.Map<CategoryDto>(_repository.GetCategory(categoryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(category);

        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategoryId (int categoryId) 
        {
            var pokemons = _mapper.Map<List<PokemonDto>>(_repository.GetPokemonByCategory(categoryId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }
    }
}
