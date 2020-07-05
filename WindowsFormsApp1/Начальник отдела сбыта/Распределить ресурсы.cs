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
    public partial class Распределить_ресурсы : Form
    {
        Список_добытых_ресурсов списокДобытыхРесурсов;
        Extraction extraction;
        public Распределить_ресурсы()
        {
            InitializeComponent();
        }
        public Распределить_ресурсы(Список_добытых_ресурсов списокДобытыхРесурсов, Extraction extraction) : this()
        {
            this.списокДобытыхРесурсов = списокДобытыхРесурсов;
            this.extraction = extraction;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            extraction.DistributionOfResources(textBox1.Text, textBox2.Text, textBox3.Text);


            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
