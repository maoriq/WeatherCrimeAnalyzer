using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCrimeAnalyzer
{
    public static class WeatherService
    {
        public static List<WeatherData> LoadWeatherFromCsv(string filePath)
        {
            var weatherList = new List<WeatherData>();
            var lines = File.ReadAllLines(filePath).Skip(1); // Пропуск заголовка

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var data = new WeatherData
                {
                    Date = DateTime.Parse(parts[0]),
                    MinTemp = double.Parse(parts[1], CultureInfo.InvariantCulture),
                    MaxTemp = double.Parse(parts[2], CultureInfo.InvariantCulture),
                    AvgTemp = double.Parse(parts[3], CultureInfo.InvariantCulture),
                    Description = parts[4]
                };
                weatherList.Add(data);
            }

            return weatherList;
        }
    }

}
