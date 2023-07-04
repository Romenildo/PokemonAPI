using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pokemonAPI.Data;
using pokemonAPI.Dtos;
using pokemonAPI.Interfaces;
using pokemonAPI.Model;

namespace pokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {

        //Injeção de dependencia todas as funcoes do repository do pokemon agora estarão disponiveis no controller
        private readonly IPokemonRepository _repository;
        private readonly IMapper _mapper;
        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _repository = pokemonRepository;
            _mapper = mapper;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            //sem o automapper (   var pokemons = _repository.GetPokemons();   )
            var pokemons = _mapper.Map<List<PokemonDto>>(_repository.GetPokemons());

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            //ou pode usar : var pokemonsDto = _mapper.Map<Pokemon>(pokemons);

            return Ok(pokemons);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_repository.PokemonExists(pokeId)) {
                return NotFound();
            }

            var pokemon =  _mapper.Map<PokemonDto>(_repository.GetPokemon(pokeId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemon);

        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_repository.PokemonExists(pokeId))
            {
                return NotFound();
            }

            var rating = _repository.GetPokemonRating(pokeId);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(rating);

        }


    }
}
