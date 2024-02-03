using Microsoft.EntityFrameworkCore;

namespace PokemonReviewApp.Models
{
    public class PokemonDbContext: DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasMany(c => c.Categories)
                .WithMany(p => p.Pokemons);

            modelBuilder.Entity<Pokemon>()
                .HasMany(o => o.Owners)
                .WithMany(p => p.Pokemons);

            modelBuilder.Entity<Pokemon>()
                .HasMany(r => r.Reviews)
                .WithOne(p => p.Pokemon)
                .HasForeignKey(pi => pi.PokemonId);

            modelBuilder.Entity<Owner>()
                .HasOne(c => c.Country)
                .WithMany(o => o.Owners)
                .HasForeignKey(ci => ci.CountryId);

            modelBuilder.Entity<Reviewer>()
                .HasMany(r => r.Reviews)
                .WithOne(ri => ri.Reviewer)
                .HasForeignKey(rp => rp.ReviewerId);


        }
    }
}
