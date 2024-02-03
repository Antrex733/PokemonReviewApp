using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp
{
    public class Seed
    {
        private readonly PokemonDbContext _context;
        public Seed(PokemonDbContext context)
        {
            this._context = context;
        }
        public void SeedDataContext()
        {
            if (_context.Database.CanConnect())
            {
                var pendingMigraction = _context.Database.GetPendingMigrations();
                if (pendingMigraction != null && pendingMigraction.Any())
                {
                    _context.Database.Migrate();
                }
                if (!_context.Categories.Any())
                {
                    // Dodawanie kategorii
                    SeedCategory();
                }
                if (!_context.Countries.Any())
                {
                    // Dodawanie pkrajów
                    SeedCountry();
                }
                if (!_context.Owners.Any())
                {
                    // Dodawanie Właściieli
                    SeedOwners();
                }
                if (!_context.Reviewers.Any())
                {
                    // Dodawanie Właściieli
                    SeedReviewers();
                }
                if (!_context.Pokemons.Any())
                {
                    // Dodawanie pokémonów
                    SeedPokemons();
                }
                if (!_context.Reviews.Any())
                {
                    // Dodawanie recenzji
                    SeedReviews();
                }
            }
        }
        void SeedCategory()
        {
            // Dodawanie kategorii
            var categories = new List<Category>
                {
                    new Category { Name = "Category 1" },
                    new Category { Name = "Category 2" },
                };

            _context.Categories.AddRange(categories);
            _context.SaveChanges();
        }
        void SeedCountry()
        {
            // Dodawanie krajów
            var countries = new List<Country>
                {
                    new Country { Name = "Country 1" },
                    new Country { Name = "Country 2" },
                // Dodaj więcej krajów w razie potrzeby
                };

            _context.Countries.AddRange(countries);
            _context.SaveChanges();
        }
        void SeedOwners()
        {
            // Dodawanie właścicieli
            var owners = new List<Owner>
                {
                    new Owner { FirstName = "John", LastName = "Doe", Gym = "Gym 1", CountryId = 1 },
                    new Owner { FirstName = "Jane", LastName = "Smith", Gym = "Gym 2", CountryId = 2 },
                // Dodaj więcej właścicieli w razie potrzeby
                };

            _context.Owners.AddRange(owners);
            _context.SaveChanges();
        }
        void SeedReviewers()
        {
            // Dodawanie recenzentów
            var reviewers = new List<Reviewer>
            {
                new Reviewer { FirstName = "Reviewer 1 First Name", LastName = "Reviewer 1 Last Name" },
                new Reviewer { FirstName = "Reviewer 2 First Name", LastName = "Reviewer 2 Last Name" },
                // Dodaj więcej recenzentów w razie potrzeby
            };

            _context.Reviewers.AddRange(reviewers);
            _context.SaveChanges();
        }
        void SeedPokemons()
        {
            // Dodawanie pokémonów
            var pokemons = new List<Pokemon>
            {
                    new Pokemon { Name = "Pokemon 1", BirthDate = DateTime.Now, Categories = _context.Categories.Take(1).ToList(), Owners = _context.Owners.Take(1).ToList() },
                    new Pokemon { Name = "Pokemon 2", BirthDate = DateTime.Now, Categories = _context.Categories.Skip(1).Take(1).ToList(), Owners = _context.Owners.Skip(1).Take(1).ToList() },
                // Dodaj więcej pokémonów w razie potrzeby
            };

            _context.Pokemons.AddRange(pokemons);
            _context.SaveChanges();

        }
        void SeedReviews()
        {
                // Dodawanie recenzji
                var reviews = new List<Review>
                {
                    new Review { Title = "Review 1", Text = "Review 1 Text", Rating = 7, ReviewerId = 1, PokemonId = 1 },
                    new Review { Title = "Review 2", Text = "Review 2 Text", Rating = 6, ReviewerId = 2, PokemonId = 2 },
                // Dodaj więcej recenzji w razie potrzeby
                };

                _context.Reviews.AddRange(reviews);
                _context.SaveChanges();
            }
    }
}
