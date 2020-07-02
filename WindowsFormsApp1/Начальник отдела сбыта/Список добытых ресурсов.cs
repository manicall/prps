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
        private Form1 окноВходаВСистему;
        public Список_добытых_ресурсов()
        {
            InitializeComponent();
        }
        public Список_добытых_ресурсов(Form1 form1) : this()
        {
            окноВходаВСистему = form1;
        }

        private void Список_добытых_ресурсов_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 10;
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

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Список_добытых_ресурсов_FormClosed(object sender, FormClosedEventArgs e)
        {
            окноВходаВСистему.Show();
        }
    }
}
