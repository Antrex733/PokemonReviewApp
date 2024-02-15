using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repositories.Interfaces;

namespace PokemonReviewApp.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository,
            IOwnerRepository ownerRepository,
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _ownerRepository = ownerRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var result = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if (!ModelState.IsValid)
                return BadRequest(result);

            return Ok(result);
        }
        
        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        public IActionResult GetPokemon(int pokeId) 
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();

            var result = _pokemonRepository.GetPokemon(pokeId);
            if (result is null)
                return BadRequest();

            return Ok(result);
        }
        
        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();

            var result = _pokemonRepository.GetPokemonRating(pokeId);
            if (result is (decimal)default)
                return BadRequest();

            return Ok(result);
        }
        [HttpPost("{pokeId}/rating")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon([FromQuery]int ownerId,
            [FromQuery] int categoryId, [FromBody] PokemonDto pokemon)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
                return NotFound();
            if (!_categoryRepository.CategoriesExists(ownerId))
                return NotFound();

            var result = _pokemonRepository.GetPokemonRating(pokeId);
            if (result is (decimal)default)
                return BadRequest();

            return Ok(result);
        }
    }
}
