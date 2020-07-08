using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Начальник_отдела_сбыта;

namespace WindowsFormsApp1
{
    public partial class Список_активных_договоров : Form
    {
        Информация_о_договоре ИнформацияОДоговоре;
        private Список_добытых_ресурсов списокДобытыхРесурсов;
        private Extraction extraction;
        private List<Agreement> agreements = new List<Agreement>();
        public Список_активных_договоров()
        {
            InitializeComponent();
        }
        public Список_активных_договоров(Список_добытых_ресурсов списокДобытыхРесурсов, Extraction extraction) : this()
        {
            this.списокДобытыхРесурсов = списокДобытыхРесурсов;
            this.extraction = extraction;
        }
        private void Список_активных_договоров_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("agreements.txt");
            agreements.Clear();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split('|');
                if (extraction.Resource.Name.ToLower() == line[0].Trim().ToLower() && line[4].Trim().ToLower() == "активный")
                    agreements.Add(new Agreement(extraction.Resource, line[1].Trim(), line[2].Trim(), line[3].Trim(), line[5].Trim(), line[4].Trim()));
            }
            reader.Close();
            if (agreements.Count == 0)
            {
                MessageBox.Show("Договоры по выбранному ресурсу отсутсвуют", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                списокДобытыхРесурсов.EnableDataGridView();
                Close();
                return;
            }
            dataGridView1.RowCount = agreements.Count;
            for (int i = 0; i < agreements.Count; i++)
            {
                dataGridView1[0, i].Value = agreements[i].StartDate;
                dataGridView1[1, i].Value = agreements[i].EndDate;
                dataGridView1[2, i].Value = agreements[i].Remainder;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Отправить_ресурсы_согласно_договору(this, extraction, agreements[dataGridView1.CurrentCell.RowIndex]).ShowDialog();
            // изменить данные в открытом окне Информация о договоре
            if (ИнформацияОДоговоре != null && !ИнформацияОДоговоре.IsDisposed)
                ИнформацияОДоговоре.UpdateInformation(agreements[dataGridView1.CurrentCell.RowIndex]);
            списокДобытыхРесурсов.UpdateInformation();
            dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value = agreements[dataGridView1.CurrentCell.RowIndex].Remainder;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ИнформацияОДоговоре == null || ИнформацияОДоговоре.IsDisposed)
            {
                ИнформацияОДоговоре = new Информация_о_договоре(agreements[dataGridView1.CurrentCell.RowIndex]);
                ИнформацияОДоговоре.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            списокДобытыхРесурсов.EnableDataGridView();
            Close();
        }

        private void Список_активных_договоров_FormClosed(object sender, FormClosedEventArgs e)
        {
            списокДобытыхРесурсов.EnableDataGridView();
            if (ИнформацияОДоговоре != null && !ИнформацияОДоговоре.IsDisposed)
                ИнформацияОДоговоре.Close();
        }
    }
}
