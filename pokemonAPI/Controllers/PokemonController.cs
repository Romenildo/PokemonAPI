using Microsoft.AspNetCore.Mvc;
using pokemonAPI.Data;
using pokemonAPI.Interfaces;
using pokemonAPI.Model;

namespace pokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {

        //Injeção de dependencia todas as funcoes do repository do pokemon agora estarão disponiveis no controller
        // e todas as funcoes dos bancos de dadso também com o context
        private readonly IPokemonRepository _repository;
        private readonly DataContext _dataContext;
        public PokemonController(IPokemonRepository pokemonRepository, DataContext dataContext) 
        {
            _repository = pokemonRepository;
            _dataContext = dataContext;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _repository.GetPokemons();

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return Ok(pokemons);
        }

    }
}
