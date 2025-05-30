namespace WeatherCrimeAnalyzer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCrimeForm = new System.Windows.Forms.Button();
            this.btnWeatherForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrimeForm
            // 
            this.btnCrimeForm.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnCrimeForm.Location = new System.Drawing.Point(293, 99);
            this.btnCrimeForm.Name = "btnCrimeForm";
            this.btnCrimeForm.Size = new System.Drawing.Size(180, 72);
            this.btnCrimeForm.TabIndex = 0;
            this.btnCrimeForm.Text = "Криминал";
            this.btnCrimeForm.UseVisualStyleBackColor = false;
            // 
            // btnWeatherForm
            // 
            this.btnWeatherForm.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnWeatherForm.Location = new System.Drawing.Point(293, 237);
            this.btnWeatherForm.Name = "btnWeatherForm";
            this.btnWeatherForm.Size = new System.Drawing.Size(180, 72);
            this.btnWeatherForm.TabIndex = 1;
            this.btnWeatherForm.Text = "Погода";
            this.btnWeatherForm.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 450);
            this.Controls.Add(this.btnWeatherForm);
            this.Controls.Add(this.btnCrimeForm);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrimeForm;
        private System.Windows.Forms.Button btnWeatherForm;
    }
}

