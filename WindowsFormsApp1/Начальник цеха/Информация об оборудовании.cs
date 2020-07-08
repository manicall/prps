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
    public partial class Информация_об_оборудовании : Form
    {
        private Equipment equipment;
        private Список_оборудования СписокОборудования;
        public Информация_об_оборудовании()
        {
            InitializeComponent();
        }
        public Информация_об_оборудовании(Список_оборудования СписокОборудования, Equipment equipment) : this()
        {
            this.СписокОборудования = СписокОборудования;
            this.equipment = equipment;
        }

        private void Информация_об_оборудовании_Load(object sender, EventArgs e)
        {
            textBox1.Text = equipment.Name;
            textBox2.Text = equipment.Manufacturer;
            textBox3.Text = equipment.Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
