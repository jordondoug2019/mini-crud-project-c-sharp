using Microsoft.EntityFrameworkCore;
// The GameContext creates the functionality for the Game Model.
namespace GamesApi.Models
{
    public class GamesContext : DbContext
    {
        public GamesContext(DbContextOptions<GamesContext> options)
            : base(options)
        {
        }

        public DbSet<GamesModel> GamesList { get; set; }
    }
}