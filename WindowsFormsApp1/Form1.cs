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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
                f.Show();
            f.dataGridView1.Rows.Clear(); //подготовили для нового заполнения
            f.dataGridView1.ColumnCount = 3;
            f.dataGridView1.Columns[0].HeaderText = "ФИО";
            f.dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.Automatic;
            f.dataGridView1.Columns[1].HeaderText = "ТЕЛЕФОН";
            f.dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
            f.dataGridView1.Columns[2].HeaderText = "РАЗМЕР ПРОТИВОГАЗА";
            f.dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
