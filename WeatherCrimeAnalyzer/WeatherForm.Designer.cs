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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.weatherGridView = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LoadWeather = new System.Windows.Forms.Button();
            this.ForecastButton = new System.Windows.Forms.Button();
            this.nInput = new System.Windows.Forms.TextBox();
            this.futureDaysInput = new System.Windows.Forms.TextBox();
            this.MaxTempDiffLabel = new System.Windows.Forms.Label();
            this.MinTempDiffLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.weatherGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // weatherGridView
            // 
            this.weatherGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.weatherGridView.Location = new System.Drawing.Point(27, 78);
            this.weatherGridView.Name = "weatherGridView";
            this.weatherGridView.RowHeadersWidth = 51;
            this.weatherGridView.RowTemplate.Height = 24;
            this.weatherGridView.Size = new System.Drawing.Size(226, 187);
            this.weatherGridView.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(273, 24);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(367, 336);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart";
            // 
            // LoadWeather
            // 
            this.LoadWeather.Location = new System.Drawing.Point(27, 380);
            this.LoadWeather.Name = "LoadWeather";
            this.LoadWeather.Size = new System.Drawing.Size(226, 23);
            this.LoadWeather.TabIndex = 2;
            this.LoadWeather.Text = "Загрузить данные";
            this.LoadWeather.UseVisualStyleBackColor = true;
            // 
            // ForecastButton
            // 
            this.ForecastButton.Location = new System.Drawing.Point(273, 380);
            this.ForecastButton.Name = "ForecastButton";
            this.ForecastButton.Size = new System.Drawing.Size(367, 23);
            this.ForecastButton.TabIndex = 3;
            this.ForecastButton.Text = "Сделать прогноз";
            this.ForecastButton.UseVisualStyleBackColor = true;
            // 
            // nInput
            // 
            this.nInput.Location = new System.Drawing.Point(27, 294);
            this.nInput.Name = "nInput";
            this.nInput.Size = new System.Drawing.Size(226, 22);
            this.nInput.TabIndex = 4;
            // 
            // futureDaysInput
            // 
            this.futureDaysInput.Location = new System.Drawing.Point(27, 338);
            this.futureDaysInput.Name = "futureDaysInput";
            this.futureDaysInput.Size = new System.Drawing.Size(226, 22);
            this.futureDaysInput.TabIndex = 5;
            // 
            // MaxTempDiffLabel
            // 
            this.MaxTempDiffLabel.AutoSize = true;
            this.MaxTempDiffLabel.Location = new System.Drawing.Point(24, 24);
            this.MaxTempDiffLabel.Name = "MaxTempDiffLabel";
            this.MaxTempDiffLabel.Size = new System.Drawing.Size(167, 16);
            this.MaxTempDiffLabel.TabIndex = 6;
            this.MaxTempDiffLabel.Text = "Максимальный перепад:";
            // 
            // MinTempDiffLabel
            // 
            this.MinTempDiffLabel.AutoSize = true;
            this.MinTempDiffLabel.Location = new System.Drawing.Point(24, 49);
            this.MinTempDiffLabel.Name = "MinTempDiffLabel";
            this.MinTempDiffLabel.Size = new System.Drawing.Size(161, 16);
            this.MinTempDiffLabel.TabIndex = 7;
            this.MinTempDiffLabel.Text = "Минимальный перепад:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Кол-во дней для прогноза";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "N для скользящей средней";
            // 
            // WeatherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 430);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MinTempDiffLabel);
            this.Controls.Add(this.MaxTempDiffLabel);
            this.Controls.Add(this.futureDaysInput);
            this.Controls.Add(this.nInput);
            this.Controls.Add(this.ForecastButton);
            this.Controls.Add(this.LoadWeather);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.weatherGridView);
            this.Name = "WeatherForm";
            this.Text = "WeatherForm";
            ((System.ComponentModel.ISupportInitialize)(this.weatherGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView weatherGridView;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button LoadWeather;
        private System.Windows.Forms.Button ForecastButton;
        private System.Windows.Forms.TextBox nInput;
        private System.Windows.Forms.TextBox futureDaysInput;
        private System.Windows.Forms.Label MaxTempDiffLabel;
        private System.Windows.Forms.Label MinTempDiffLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}