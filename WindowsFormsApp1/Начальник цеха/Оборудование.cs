using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Начальник_цеха
{
    public partial class Оборудование : Form
    {
        public Оборудование()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6(this);
            form.ShowDialog();   
        }

        private void Form5_Load(object sender, EventArgs e)
        {         
            this.таблица_оборудование.RowCount = 10;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form8().Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.buttons_disable();
            form.Show();
        }
    }
}
