﻿using System.Text.Json.Serialization;

namespace PokemonReviewApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public DateTime BirthDate { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
