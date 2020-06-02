using System;
using WindowsFormsApp1.Начальник_цеха;
using WindowsFormsApp1.Руководитель_комбината;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "1") new Form2().Show();
            else if (textBox2.Text == "2") new Form5().Show();
            else if (textBox2.Text == "3") new Form7().Show();
            else return;
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
