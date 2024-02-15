using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int Id);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExists(int Id);
        bool CreateReviewer(Reviewer reviewer);
        bool Save();
    }
}
