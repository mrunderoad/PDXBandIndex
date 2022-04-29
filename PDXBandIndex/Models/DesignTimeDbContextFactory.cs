using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PDXBandIndex.Models
{
  public class PDXBandIndexContextFactory : IDesignTimeDbContextFactory<PDXBandIndexContext>
  {

    PDXBandIndexContext IDesignTimeDbContextFactory<PDXBandIndexContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PDXBandIndexContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new PDXBandIndexContext(builder.Options);
    }
  }
}