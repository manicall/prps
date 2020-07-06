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
        Список_активных_договоров СписокАктивныхДоговоров;
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
            UpdateInformation();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (СписокАктивныхДоговоров == null || СписокАктивныхДоговоров.IsDisposed)
            {
                СписокАктивныхДоговоров = new Список_активных_договоров(this, ИнформацияОРесурсе, extractions[dataGridView1.CurrentCell.RowIndex]);
                СписокАктивныхДоговоров.Show();
                dataGridView1.Enabled = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // открыть только одно окно
            if (ИнформацияОРесурсе == null || ИнформацияОРесурсе.IsDisposed)
            {
                ИнформацияОРесурсе = new Информация_о_ресурсе(this, extractions[dataGridView1.CurrentCell.RowIndex]);
                ИнформацияОРесурсе.Show();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Список_добытых_ресурсов_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ИнформацияОРесурсе != null && !ИнформацияОРесурсе.IsDisposed)
                ИнформацияОРесурсе.Close();
            if (СписокАктивныхДоговоров != null && !СписокАктивныхДоговоров.IsDisposed)
                СписокАктивныхДоговоров.Close();
            окноВходаВСистему.Show();
        }
        public void EnableDataGridView()
        {
            dataGridView1.Enabled = true;
        }
        public void UpdateInformation() {
            // изменить данные в открытом окне Информация о ресурсе
            if (ИнформацияОРесурсе != null && !ИнформацияОРесурсе.IsDisposed)
                ИнформацияОРесурсе.UpdateInformation(extractions[dataGridView1.CurrentCell.RowIndex]);
            // перезаписать поле не распределено
            dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value = extractions[dataGridView1.CurrentCell.RowIndex].VolumeUndistributed;
        }
    }
}
