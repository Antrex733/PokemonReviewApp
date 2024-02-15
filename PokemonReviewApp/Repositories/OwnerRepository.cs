using PokemonReviewApp.Models;
using PokemonReviewApp.Repositories.Interfaces;

namespace PokemonReviewApp.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PokemonDbContext _context;

        public OwnerRepository(PokemonDbContext context)
        {
            _context = context;
        }
        public bool CreateOwner(Owner owner)
        {
            _context.Add(owner);
            return Save();
        }

        public Owner GetOwner(int Id)
        {
            var owner = _context.Owners.FirstOrDefault(o => o.Id == Id);
            return owner;
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
        {
            var owners = _context.Pokemons
                .Where(p => p.Id == pokeId)
                .SelectMany(o => o.Owners);
                
            return owners.ToList();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            var pokemons = _context.Owners
                .Where(o => o.Id == ownerId)
                .SelectMany(p => p.Pokemons);

            return pokemons.ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            var owners = _context.Owners;

            return owners.ToList();
        }

        public bool OwnerExists(int Id)
        {
            var owner = _context.Owners.FirstOrDefault();
            if (owner == null)
            {
                return false;
            }
            return true;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
