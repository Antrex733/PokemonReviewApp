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

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
