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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowCount = 10;
            this.dataGridView1.ColumnCount = 3;

            this.dataGridView1.Columns[0].HeaderText = "Название";
            this.dataGridView1.Columns[1].HeaderText = "Описание";
            this.dataGridView1.Columns[2].HeaderText = "Общий объем добытых ресурсов";
            this.dataGridView1.Columns[0].Width = 150;
            this.dataGridView1.Columns[1].Width = 400;
            this.dataGridView1.Columns[2].MinimumWidth = 200;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Distribution_of_resourses().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }
    }
}
