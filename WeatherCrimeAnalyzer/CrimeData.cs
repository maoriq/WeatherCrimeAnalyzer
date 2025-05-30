using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherCrimeAnalyzer
{
    public class CrimeData
    {
        public int Year { get; set; }
        public Dictionary<string, int> CrimeByType { get; set; }
    }
}
