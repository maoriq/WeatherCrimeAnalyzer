using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WeatherCrimeAnalyzer
{
    public partial class WeatherForm : Form
    {
        private List<WeatherData> weatherList;

        public WeatherForm()
        {
            InitializeComponent();
        }

        // Обработчик кнопки "Загрузить данные"
        private void LoadWeather_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                weatherList = WeatherService.LoadWeatherFromCsv(filePath);
                weatherGridView.DataSource = weatherList;
                PlotGraph();
                ShowStats();
            }
        }

        // Метод для построения графика
        private void PlotGraph()
        {
            chart.Series.Clear();

            var minSeries = new Series("Min")
            {
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Line
            };

            var maxSeries = new Series("Max")
            {
                Color = System.Drawing.Color.Red,
                ChartType = SeriesChartType.Line
            };

            for (int i = 0; i < weatherList.Count; i++)
            {
                minSeries.Points.AddXY(i + 1, weatherList[i].MinTemp);
                maxSeries.Points.AddXY(i + 1, weatherList[i].MaxTemp);
            }

            chart.Series.Add(minSeries);
            chart.Series.Add(maxSeries);
        }

        private void ShowStats()
        {
            var maxDiff = WeatherAnalyzer.GetMaxTempDiffDay(weatherList);
            var minDiff = WeatherAnalyzer.GetMinTempDiffDay(weatherList);

            MessageBox.Show($"Максимальный перепад: {maxDiff.diff}°C ({maxDiff.day.Date.ToShortDateString()})\n" +
                            $"Минимальный перепад: {minDiff.diff}°C ({minDiff.day.Date.ToShortDateString()})");
        }

        // Обработчик кнопки "Сделать прогноз"
        private void ForecastButton_Click(object sender, EventArgs e)
        {
            int n = int.Parse(nInput.Text);  // Пользователь вводит N для скользящей средней
            int futureDays = int.Parse(futureDaysInput.Text);  // Количество дней для прогноза

            var avgTemps = weatherList.Select(d => d.AvgTemp).ToList();

            var forecast = WeatherAnalyzer.Forecast(avgTemps, n, futureDays);

            var forecastSeries = new Series("Прогноз")
            {
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Line
            };

            for (int i = 0; i < forecast.Count; i++)
            {
                forecastSeries.Points.AddXY(weatherList.Count + i + 1, forecast[i]);
            }
            chart.Series.Add(forecastSeries);
        }

        private void weatherGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
