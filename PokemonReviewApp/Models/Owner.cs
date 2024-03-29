﻿using System.Text.Json.Serialization;

namespace PokemonReviewApp.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }

        [JsonIgnore]
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
