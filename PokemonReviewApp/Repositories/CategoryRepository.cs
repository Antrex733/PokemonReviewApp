using PokemonReviewApp.Models;
using PokemonReviewApp.Repositories.Interfaces;

namespace PokemonReviewApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PokemonDbContext _context;

        public CategoryRepository(PokemonDbContext context)
        {
            _context = context;
        }
        public bool CategoriesExists(int Id)
        {
            var category = _context.Categories.Any(c => c.Id == Id);
            return category;
        }

        public ICollection<Category> GetCategories()
        {
            var categories = _context.Categories.ToList();
            return categories;
        }

        public Category GetCategory(int Id)
        {
            var category = _context.Categories.FirstOrDefault(_c => _c.Id == Id);
            return category;
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            var pokemons = _context.Categories
                .Where(c => c.Id == categoryId)
                .SelectMany(p => p.Pokemons)
                .ToList();
            return pokemons;
        }
    }
}
