using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repositories.Interfaces;

namespace PokemonReviewApp.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly PokemonDbContext _context;

        public CountryRepository(PokemonDbContext pokemonDbContext)
        {
            _context = pokemonDbContext;
        }
        public bool CountryExists(int Id)
        {
            var result = _context.Countries.Any(c => c.Id == Id);
            return result;
        }

        public bool CreateCountry(Country country)
        {
            _context.Add(country);
            return Save();
        }

        public ICollection<Country> GetCountries()
        {
            var results = _context.Countries.ToList();
            return results;
        }

        public Country GetCountry(int Id)
        {
            var result = _context.Countries.FirstOrDefault(c => c.Id == Id);
            return result;
        }

        public Country GetCountryByOwner(int ownerId)
        {
            var result = _context.Owners.FirstOrDefault(i => i.Id == ownerId);

            var result1 = _context.Countries.FirstOrDefault(c => c.Owners.Contains(result));
            return result1;
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            var results = _context.Owners.Where(o => o.CountryId == countryId).ToList();
                return results;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
