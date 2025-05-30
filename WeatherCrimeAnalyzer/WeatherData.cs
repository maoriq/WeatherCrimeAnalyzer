using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCrimeAnalyzer
{
    public class WeatherData
    {
        public DateTime Date { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
        public double AvgTemp { get; set; }
        public string Description { get; set; }
    }

}
