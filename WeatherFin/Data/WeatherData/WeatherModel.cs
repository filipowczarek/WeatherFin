using System.ComponentModel.DataAnnotations;

namespace WeatherFin.Data.WeatherData
{
    public class WeatherModel
    {
        [Key]
        public int WeatherId { get; set; }
        public string CityName { get; set; }
        public DateTime? dateOfMeasurement { get; set; }
        public double temperature { get; set; }
        public string weatherDescription { get; set; }

    }
}
