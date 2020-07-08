using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Информация_о_договоре : Form
    {
        Agreement agreement;
        public Информация_о_договоре()
        {
            InitializeComponent();
        }
        public Информация_о_договоре(Agreement agreement) : this()
        {
            this.agreement = agreement;
        }
        private void Информация_о_договоре_Load(object sender, EventArgs e)
        {
            UpdateInformation(agreement);
        }
        public void UpdateInformation(Agreement agreement) {
            textBox1.Text = agreement.StartDate;
            textBox2.Text = agreement.EndDate;
            textBox3.Text = agreement.Remainder;
            textBox4.Text = agreement.Description;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
