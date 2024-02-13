using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int Id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
        bool CountryExists(int Id);
        bool CreateCountry(Country country);
        bool Save();
    }
}
