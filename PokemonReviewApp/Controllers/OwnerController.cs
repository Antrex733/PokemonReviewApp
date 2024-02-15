﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repositories;
using PokemonReviewApp.Repositories.Interfaces;
using System.Diagnostics.Metrics;

namespace PokemonReviewApp.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository,
            ICountryRepository countryRepository,  IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOwner([FromQuery] int countruId, [FromBody]OwnerDto owner)
        {
            if (owner == null)
            {
                return BadRequest(ModelState);
            }
            var ownerDto = _mapper.Map<Owner>(owner);
            ownerDto.Country = _countryRepository.GetCountry(countruId);
            
            if (!_ownerRepository.CreateOwner(ownerDto))
            {
                return BadRequest(ModelState);
            }
            return Ok("Owner created successfully");
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(200, Type = typeof(OwnerDto))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int Id)
        {
            var result = _mapper
                .Map<OwnerDto>(_ownerRepository.GetOwner(Id));
            if (!ModelState.IsValid || !_ownerRepository.OwnerExists(Id))
            {
                return BadRequest(ModelState);
            }
            return Ok(result);
        }

        [HttpGet("GetOwnerOfAPokemon/{pokeId}")]
        [ProducesResponseType(200, Type = typeof(List<OwnerDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnerOfAPokemon(int pokeId)
        {
            var result = _mapper
                .Map<List<OwnerDto>>(_ownerRepository.GetOwnerOfAPokemon(pokeId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(result);
        }

        [HttpGet("GetPokemonByOwner/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int ownerId)
        {
            var result = _mapper
                .Map<List<PokemonDto>>(_ownerRepository.GetPokemonByOwner(ownerId));
            if (!ModelState.IsValid || !_ownerRepository.OwnerExists(ownerId))
            {
                return BadRequest(ModelState);
            }
            return Ok(result);
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwners()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var owners = _ownerRepository.GetOwners();
            var ownersMap = _mapper.Map<List<OwnerDto>>(owners);

            return Ok(owners);
        }
    }
}
