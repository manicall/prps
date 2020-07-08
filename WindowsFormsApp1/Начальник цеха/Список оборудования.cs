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
    public partial class Список_оборудования : Form
    {
        Информация_об_оборудовании ИнформацияОбОборудовании;
        List<Equipment> equipments = new List<Equipment>();
        Form1 окноВходаВСистему;
        public Список_оборудования()
        {
            InitializeComponent();
        }
        public Список_оборудования(Form1 form1) : this()
        {
            окноВходаВСистему = form1;
        }
        private void Список_оборудования_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("equipments.txt");
            equipments.Clear();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split('|');
                equipments.Add(new Equipment(line[0].Trim(), line[1].Trim(), line[2].Trim()));
            }
            reader.Close();
            
            if (equipments.Count == 0)
            {
                MessageBox.Show("Договоры по выбранному ресурсу отсутсвуют", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            dataGridView1.RowCount = equipments.Count;
            for (int i = 0; i < equipments.Count; i++)
            {
                dataGridView1[0, i].Value = equipments[i].Name;
                dataGridView1[1, i].Value = equipments[i].Manufacturer;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Добавить_оборудование form = new Добавить_оборудование(this, equipments);
            if (form.ShowDialog() == DialogResult.OK) { AddInDataGridView(equipments[equipments.Count - 1]); }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new Отправить_запрос(this, equipments[dataGridView1.CurrentCell.RowIndex]).ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (ИнформацияОбОборудовании == null || ИнформацияОбОборудовании.IsDisposed)
            {
                ИнформацияОбОборудовании = new Информация_об_оборудовании(this, equipments[dataGridView1.CurrentCell.RowIndex]);
                ИнформацияОбОборудовании.Show();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Список_оборудования_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ИнформацияОбОборудовании != null && !ИнформацияОбОборудовании.IsDisposed)
                ИнформацияОбОборудовании.Close();
            окноВходаВСистему.Show();
        }

        private void AddInDataGridView(Equipment equipment)
        {
            dataGridView1.RowCount = equipments.Count;
            dataGridView1[0, dataGridView1.RowCount - 1].Value = equipment.Name;
            dataGridView1[1, dataGridView1.RowCount - 1].Value = equipment.Manufacturer;
        }
    }
}
