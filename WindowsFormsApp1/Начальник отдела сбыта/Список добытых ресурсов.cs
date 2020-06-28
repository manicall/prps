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
    public partial class Список_добытых_ресурсов : Form
    {
        public Список_добытых_ресурсов()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowCount = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            new Распределить_ресурсы().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            new Список_активных_договоров().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
