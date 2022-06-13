using Microsoft.EntityFrameworkCore;
using WeatherFin.Data.WeatherData;
using WeatherFin.HelpClasses;

namespace WeatherFin.Data.Context
{
    public class WeatherContext : DbContext
    {
        public WeatherContext()
        {

        }

        public DbSet<WeatherModel> WeatherModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(HelpConnection.connectionStr);
        }
        public void clearTable()
        {
            if (WeatherModels.Any())
            {
                foreach (var weather in WeatherModels)
                {
                    WeatherModels.Remove(weather);
                }
            }
        }

    }
}
