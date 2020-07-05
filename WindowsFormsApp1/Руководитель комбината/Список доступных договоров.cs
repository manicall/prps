using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Руководитель_комбината
{
    public partial class Список_доступных_договоров : Form
    {
        private Действия_руководителя ДействияРуководителя;
        public Список_доступных_договоров()
        {
            InitializeComponent();
        }
        public Список_доступных_договоров(Действия_руководителя form) : this()
        {
            ДействияРуководителя = form;
        }

        private void Список_доступных_договоров_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowCount = 10;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Список_доступных_договоров_FormClosed(object sender, FormClosedEventArgs e)
        {
            ДействияРуководителя.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            new Информация_о_договоре().Show();
        }
    }
}
