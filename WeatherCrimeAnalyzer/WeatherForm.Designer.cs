namespace WeatherCrimeAnalyzer
{
    partial class WeatherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.weatherGridView = new System.Windows.Forms.DataGridView();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LoadWeather = new System.Windows.Forms.Button();
            this.ForecastButton = new System.Windows.Forms.Button();
            this.nInput = new System.Windows.Forms.TextBox();
            this.futureDaysInput = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.weatherGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // weatherGridView
            // 
            this.weatherGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.weatherGridView.Location = new System.Drawing.Point(234, 23);
            this.weatherGridView.Name = "weatherGridView";
            this.weatherGridView.RowHeadersWidth = 51;
            this.weatherGridView.RowTemplate.Height = 24;
            this.weatherGridView.Size = new System.Drawing.Size(591, 129);
            this.weatherGridView.TabIndex = 0;
            this.weatherGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.weatherGridView_CellContentClick);
            // 
            // chart
            // 
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(32, 158);
            this.chart.Name = "chart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(793, 335);
            this.chart.TabIndex = 1;
            this.chart.Text = "chart";
            // 
            // LoadWeather
            // 
            this.LoadWeather.Location = new System.Drawing.Point(32, 121);
            this.LoadWeather.Name = "LoadWeather";
            this.LoadWeather.Size = new System.Drawing.Size(180, 31);
            this.LoadWeather.TabIndex = 2;
            this.LoadWeather.Text = "Загрузить данные";
            this.LoadWeather.UseVisualStyleBackColor = true;
            this.LoadWeather.Click += new System.EventHandler(this.LoadWeather_Click);
            // 
            // ForecastButton
            // 
            this.ForecastButton.Location = new System.Drawing.Point(32, 502);
            this.ForecastButton.Name = "ForecastButton";
            this.ForecastButton.Size = new System.Drawing.Size(793, 33);
            this.ForecastButton.TabIndex = 3;
            this.ForecastButton.Text = "Сделать прогноз";
            this.ForecastButton.UseVisualStyleBackColor = true;
            this.ForecastButton.Click += new System.EventHandler(this.ForecastButton_Click);
            // 
            // nInput
            // 
            this.nInput.Location = new System.Drawing.Point(34, 42);
            this.nInput.Name = "nInput";
            this.nInput.Size = new System.Drawing.Size(178, 22);
            this.nInput.TabIndex = 4;
            // 
            // futureDaysInput
            // 
            this.futureDaysInput.Location = new System.Drawing.Point(32, 93);
            this.futureDaysInput.Name = "futureDaysInput";
            this.futureDaysInput.Size = new System.Drawing.Size(180, 22);
            this.futureDaysInput.TabIndex = 5;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Кол-во дней для прогноза";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "N для скользящей средней";
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 547);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.futureDaysInput);
            this.Controls.Add(this.nInput);
            this.Controls.Add(this.ForecastButton);
            this.Controls.Add(this.LoadWeather);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.weatherGridView);
            this.Name = "WeatherForm";
            this.Text = "WeatherForm";
            ((System.ComponentModel.ISupportInitialize)(this.weatherGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView weatherGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button LoadWeather;
        private System.Windows.Forms.Button ForecastButton;
        private System.Windows.Forms.TextBox nInput;
        private System.Windows.Forms.TextBox futureDaysInput;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}