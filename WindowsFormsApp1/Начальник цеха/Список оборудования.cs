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
    public partial class Список_оборудования : Form
    {
        Form1 окноВходаВСистему;
        public Список_оборудования()
        {
            InitializeComponent();
        }
        public Список_оборудования(Form1 form1) : this()
        {
            окноВходаВСистему = form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Добавить_оборудование form = new Добавить_оборудование(this);
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
            new Отправить_запрос().Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Список_запросов form = new Список_запросов();
            form.buttons_disable();
            form.Show();
        }
    }
}
