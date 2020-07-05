using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Начальник_отдела_сбыта;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Список_добытых_ресурсов : Form
    {

        Информация_о_ресурсе ИнформацияОРесурсе;
        private List<Extraction> extractions = new List<Extraction>();
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
            StreamReader reader = new StreamReader("List of extracted resources.txt");
            extractions.Clear();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split('|');
                extractions.Add(
                    new Extraction(new Resource(line[0].Trim(), line[5].Trim()),
                    line[1].Trim(), line[2].Trim(), line[3].Trim(), line[4].Trim())
                    );
            }
            reader.Close();

            dataGridView1.RowCount = extractions.Count;
            for (int i = 0; i < extractions.Count; i++)
            {
                dataGridView1[0, i].Value = extractions[i].Resource.Name;
                dataGridView1[1, i].Value = extractions[i].VolumeUndistributed;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Распределить_ресурсы(this, extractions[dataGridView1.CurrentCell.RowIndex]).ShowDialog();
            foreach (Form frm in Application.OpenForms)
                if (frm.Name == "Информация_о_ресурсе") {
                    ИнформацияОРесурсе.UpdateInformation(extractions[dataGridView1.CurrentCell.RowIndex]);
                    break;
                }
            dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value = extractions[dataGridView1.CurrentCell.RowIndex].VolumeUndistributed;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Список_активных_договоров().Show();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            ИнформацияОРесурсе = new Информация_о_ресурсе(this, extractions[dataGridView1.CurrentCell.RowIndex]);
            ИнформацияОРесурсе.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Список_добытых_ресурсов_FormClosed(object sender, FormClosedEventArgs e)
        {
            окноВходаВСистему.Show();
        }

    }
}
