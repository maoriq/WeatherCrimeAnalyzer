using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrimeForm_Click(object sender, EventArgs e)
        {
            CrimeForm form = new CrimeForm();
            form.Show();
        }

        private void btnWeatherForm_Click(object sender, EventArgs e)
        {

        }
    }
}
