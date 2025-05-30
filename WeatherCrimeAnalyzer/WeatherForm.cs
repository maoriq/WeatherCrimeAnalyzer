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

                // Заполнение DataGridView данными
                weatherGridView.DataSource = weatherList;

                // Отображение графика и статистики
                PlotGraph();
                ShowStats();
            }
        }

        // Метод для построения графика
        private void PlotGraph()
        {
            chart.Series.Clear();

            // Серия для минимальных температур (синим)
            var minSeries = new Series("Min")
            {
                Color = System.Drawing.Color.Blue,
                ChartType = SeriesChartType.Line
            };

            // Серия для максимальных температур (красным)
            var maxSeries = new Series("Max")
            {
                Color = System.Drawing.Color.Red,
                ChartType = SeriesChartType.Line
            };

            // Добавление точек для минимальных и максимальных температур
            for (int i = 0; i < weatherList.Count; i++)
            {
                minSeries.Points.AddXY(i + 1, weatherList[i].MinTemp);
                maxSeries.Points.AddXY(i + 1, weatherList[i].MaxTemp);
            }

            // Добавляем серии на график
            chart.Series.Add(minSeries);
            chart.Series.Add(maxSeries);
        }

        // Метод для отображения статистики (макс и мин перепад температур)
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

            // Получаем список средних температур
            var avgTemps = weatherList.Select(d => d.AvgTemp).ToList();

            // Получаем прогноз
            var forecast = WeatherAnalyzer.Forecast(avgTemps, n, futureDays);

            // Серия для прогноза (зелёным)
            var forecastSeries = new Series("Forecast")
            {
                Color = System.Drawing.Color.Green,
                ChartType = SeriesChartType.Line
            };

            // Добавляем данные прогноза на график
            for (int i = 0; i < forecast.Count; i++)
            {
                forecastSeries.Points.AddXY(weatherList.Count + i + 1, forecast[i]);
            }

            // Добавляем серию прогноза на график
            chart.Series.Add(forecastSeries);
        }

        private void weatherGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
