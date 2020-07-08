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
    public partial class Отправить_запрос : Form
    {
        private Equipment equipment;
        private Список_оборудования СписокОборудования;
        public Отправить_запрос()
        {
            InitializeComponent();
        }
        public Отправить_запрос(Список_оборудования СписокОборудования, Equipment equipment) : this()
        {
            this.СписокОборудования = СписокОборудования;
            this.equipment = equipment;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            equipment.SendQuery(textBox1.Text,textBox2.Text);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
