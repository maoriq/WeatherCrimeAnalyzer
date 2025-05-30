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
            var result = new List<(int year, double value)>();

            if (values.Count < n)
                return result;

            // Используем double
            var queue = new Queue<double>(values.Take(n).Select(v => (double)v));

            for (int i = 0; i < n; i++)
            {
                double avg = queue.Average();
                int year = startYear + values.Count + i;
                result.Add((year, avg));

                queue.Dequeue();   // удаляем самое старое значение
                queue.Enqueue(avg); // добавляем новое среднее, не округляя
            }

            return result;
        }


        private void btnForecast_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();

            if (string.IsNullOrWhiteSpace(textBoxN.Text))
            {
                MessageBox.Show("Введите количество лет для прогноза (N).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxN.Text, out int n) || n <= 0)
            {
                MessageBox.Show("Введите положительное целое число для N.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (crimes == null || crimes.Count == 0)
            {
                MessageBox.Show("Сначала загрузите данные.");
                return;
            }

            if (n > crimes.Count)
            {
                MessageBox.Show($"Слишком большое значение N. У вас только {crimes.Count} лет данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var crimeTypes = new[] { "Theft", "Murder", "Fraud" };
            var years = crimes.Select(c => c.Year).ToList();
            int startYear = years.First();

            foreach (var type in crimeTypes)
            {
                if (!crimes[0].CrimeByType.ContainsKey(type))
                {
                    MessageBox.Show($"Тип преступности '{type}' не найден в данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                var values = crimes.Select(c => c.CrimeByType[type]).ToList();

                // Исходная линия
                var series = chart1.Series.Add(type);
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                series.Color = GetBaseColor(type); // разные цвета
                series.BorderWidth = 2;

                for (int i = 0; i < years.Count; i++)
                {
                    series.Points.AddXY(years[i], values[i]);
                }

                // Прогнозная линия
                var forecast = CalculateMovingAverage(values, n, startYear);
                var forecastSeries = chart1.Series.Add($"{type} (прогноз)");
                forecastSeries.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                forecastSeries.Color = series.Color;
                forecastSeries.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
                forecastSeries.BorderWidth = 2;

                foreach (var point in forecast)
                {
                    forecastSeries.Points.AddXY(point.year, point.value);
                }
            }
        }
        private Color GetBaseColor(string type)
        {
            switch (type)
            {
                case "Theft":
                    return Color.Blue;
                case "Murder":
                    return Color.Green;
                case "Fraud":
                    return Color.Orange;
                default:
                    return Color.Gray;
            }
        }


    }

}

