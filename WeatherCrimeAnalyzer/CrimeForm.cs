using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherCrimeAnalyzer
{
    public partial class CrimeForm : Form
    {
        public CrimeForm()
        {
            InitializeComponent();
        }
        private List<CrimeData> crimes = new List<CrimeData>();
        // Загрузка файла
        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(openFileDialog1.FileName);
                var headers = lines[0].Split(',').Skip(1).ToArray();

                crimes.Clear();
                for (int i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(',');
                    int year = int.Parse(parts[0]);
                    var data = new Dictionary<string, int>();
                    for (int j = 1; j < parts.Length; j++)
                    {
                        data[headers[j - 1]] = int.Parse(parts[j]);
                    }

                    crimes.Add(new CrimeData { Year = year, CrimeByType = data });
                }

                dataGridView1.DataSource = crimes
                    .Select(c => new
                    {
                        Year = c.Year,
                        Theft = c.CrimeByType["Theft"],
                        Murder = c.CrimeByType["Murder"],
                        Fraud = c.CrimeByType["Fraud"]
                    }).ToList();
            }
        }

        // Построить график
        private void btnChart_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            var crimeTypes = crimes[0].CrimeByType.Keys;

            foreach (var type in crimeTypes)
            {
                var series = chart1.Series.Add(type);
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                foreach (var c in crimes)
                {
                    series.Points.AddXY(c.Year, c.CrimeByType[type]);
                }
            }
        }

        // Анализ снижения
        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            var first = crimes.First();
            var last = crimes.Last();

            var changes = new Dictionary<string, int>();
            foreach (var type in first.CrimeByType.Keys)
            {
                int diff = first.CrimeByType[type] - last.CrimeByType[type];
                changes[type] = diff;
            }

            var maxDecrease = changes.OrderByDescending(x => x.Value).First();
            var minDecrease = changes.OrderByDescending(x => x.Value).Last();

            MessageBox.Show($"Максимальное снижение: {maxDecrease.Key} на {maxDecrease.Value}\n" +
                            $"Минимальное снижение: {minDecrease.Key} на {minDecrease.Value}");

        }

        // Прогнозирование
        private List<(int year, double value)> CalculateMovingAverage(List<int> values, int n, int startYear)
        {
            List<(int, double)> result = new List<(int, double)>();
            var queue = new Queue<int>(values.Take(n));

            for (int i = 0; i < n; i++)
            {
                double avg = queue.Average();
                result.Add((startYear + values.Count + i, avg));
                queue.Dequeue();
                queue.Enqueue((int)Math.Round(avg));
            }

            return result;
        }

        private void btnForecast_Click(object sender, EventArgs e)
        {

        }

    }
}
