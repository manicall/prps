using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace WindowsFormsApp1.Начальник_цеха
{
    public partial class Form6 : Form
    {
        public Оборудование оборудование;
        public Form6()
        {
            InitializeComponent();
        }
        public Form6(Оборудование оборудование) : this()
        {
            this.оборудование = оборудование;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            оборудование.таблица_оборудование.Rows[0].Cells[2].Value = textBox3.Text;
            Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
