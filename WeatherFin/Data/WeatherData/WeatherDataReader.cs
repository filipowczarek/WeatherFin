using Microsoft.EntityFrameworkCore;
using System.IO;
using WeatherFin.Data.Context;

namespace WeatherFin.Data.WeatherData
{
    public class WeatherDataReader
    {
        public WeatherContext context = new WeatherContext();
        string[] weatherInfoLines =  File.ReadAllLines(@"Data\weatherInfo.csv");

        public void readDataToDB()
        {
            context.clearTable();
            foreach (string row in weatherInfoLines)
            {
                var fields = row.Split("\",\"");
                WeatherModel weatherModel = new WeatherModel{CityName = fields[1], dateOfMeasurement = DateTime.Parse(fields[2]), temperature = Int32.Parse(fields[3]), weatherDescription = fields[4].Remove(fields[4].Length-1)};
                context.Add(weatherModel);

            }
            context.SaveChanges();
        }
        public IEnumerable<WeatherModel> readDataToList()
        {
            List<WeatherModel> resultData = new List<WeatherModel>();
            foreach (var weather in context.WeatherModels)
            {
                resultData.Add(weather);
            }
            return resultData;
        }

        public IEnumerable<WeatherModel> searchData(IEnumerable<WeatherModel> listToSearch, string city, DateTime date)
        {
            if (listToSearch != null && city != null)
            {
                IEnumerable<WeatherModel> listToReturn;
                listToReturn = listToSearch.Where(e => e.CityName.Contains(city) && e.dateOfMeasurement.Value.Date.ToString().Contains(date.ToString()));
                return listToReturn;
            }
            return null;
        }
    }
}
