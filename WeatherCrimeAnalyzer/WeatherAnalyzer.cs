using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCrimeAnalyzer
{
    public static class WeatherAnalyzer
    {
        public static (WeatherData day, double diff) GetMaxTempDiffDay(List<WeatherData> data)
        {
            return data
                .Select(d => (d, diff: d.MaxTemp - d.MinTemp))
                .OrderByDescending(t => t.diff)
                .First();
        }

        public static (WeatherData day, double diff) GetMinTempDiffDay(List<WeatherData> data)
        {
            return data
                .Select(d => (d, diff: d.MaxTemp - d.MinTemp))
                .OrderBy(t => t.diff)
                .First();
        }

        public static List<double> GetMovingAverage(List<double> source, int period)
        {
            var result = new List<double>();
            for (int i = 0; i <= source.Count - period; i++)
            {
                var avg = source.Skip(i).Take(period).Average();
                result.Add(avg);
            }
            return result;
        }

        public static List<double> Forecast(List<double> source, int period, int futureDays)
        {
            var data = new List<double>(source);
            for (int i = 0; i < futureDays; i++)
            {
                double avg = data.Skip(data.Count - period).Take(period).Average();
                data.Add(avg);
            }
            return data.Skip(source.Count).ToList(); // Только прогноз
        }
    }

}
