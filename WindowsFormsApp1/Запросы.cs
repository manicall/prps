using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Руководитель_комбината;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowCount = 10;
        }

        public void buttons_disable()
        {
            this.button1.Visible = false;
            this.button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)  
        {
            new Form10().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
