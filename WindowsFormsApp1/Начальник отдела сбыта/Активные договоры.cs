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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowCount = 10;
            this.dataGridView1.ColumnCount = 4;

            this.dataGridView1.Columns[0].HeaderText = "Дата начала";
            this.dataGridView1.Columns[1].HeaderText = "Дата окончания";
            this.dataGridView1.Columns[2].HeaderText = "Описание предмета договора";
            this.dataGridView1.Columns[3].HeaderText = "Остаток";
            this.dataGridView1.Columns[0].Width = 150;
            this.dataGridView1.Columns[1].Width = 300;
            this.dataGridView1.Columns[2].Width = 150;
            this.dataGridView1.Columns[3].Width = 150;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ = new Form4().ShowDialog();
        }
    }
}
