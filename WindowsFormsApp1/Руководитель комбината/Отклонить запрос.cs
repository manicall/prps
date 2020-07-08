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
    public partial class Отклонить_запрос : Form
    {
        Query query;
        Список_запросов СписокЗапросов;
        public Отклонить_запрос()
        {
            InitializeComponent();
        }
        public Отклонить_запрос(Список_запросов СписокЗапросов, Query query) : this()
        {
            this.query = query;
            this.СписокЗапросов = СписокЗапросов;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                query.ChangeStatus("Отклонен", textBox1.Text);
                СписокЗапросов.UpdateInformation(textBox1.Text);
                Close();
            }
            else { MessageBox.Show("Пожалуйста опишите проблему", "Сообщение",MessageBoxButtons.OK, MessageBoxIcon.Information);}
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
