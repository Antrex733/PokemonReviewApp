using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int Id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoriesExists(int Id);
        bool CreateCategory(Category category);
        bool Save();
    }
}
