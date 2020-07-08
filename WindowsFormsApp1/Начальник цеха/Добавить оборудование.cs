using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1.Начальник_цеха
{
    public partial class Добавить_оборудование : Form
    {
        private Список_оборудования оборудование;
        private List<Equipment> equipments;
        public Добавить_оборудование()
        {
            InitializeComponent();
        }
        public Добавить_оборудование(Список_оборудования оборудование, List<Equipment> equipments) : this()
        {
            this.оборудование = оборудование;
            this.equipments = equipments;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            equipments.Add(new Equipment(textBox1.Text, textBox2.Text, textBox3.Text));
            StreamReader reader = new StreamReader("equipments.txt");
            string Str = reader.ReadToEnd();
            reader.Close();
            if (Str[Str.Length - 1] == '\n') Str = Str.Remove(Str.Length - 1);
            StreamWriter writer = new StreamWriter("equipments.txt");
            writer.WriteLine(Str);
            writer.Write("{0}|{1}|{2}", textBox1.Text.PadRight(24), textBox2.Text.PadRight(10), textBox3.Text);
            writer.Close();
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
