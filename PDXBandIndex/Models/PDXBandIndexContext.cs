using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PDXBandIndex.Models
{
  public class PDXBandIndexContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Band> Bands { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<GenreBand> GenreBand { get; set; }
    public DbSet<BandShow> BandShow { get; set; }

    public PDXBandIndexContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}