using LiveMusicFinder.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveMusicFinder.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<LiveShow> LiveShows { get; set; }
  }
}