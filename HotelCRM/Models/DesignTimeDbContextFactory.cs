using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HotelCRM.Models
{
  public class HotelCRMContextFactory : IDesignTimeDbContextFactory<HotelCRMContext>
  {

    HotelCRMContext IDesignTimeDbContextFactory<HotelCRMContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<HotelCRMContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new HotelCRMContext(builder.Options);
    }
  }
}