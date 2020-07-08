using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Руководитель_комбината;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Список_запросов : Form
    {
        Действия_руководителя ДействияРуководителя = new Действия_руководителя();
        List<Query> queries = new List<Query>();
        public Список_запросов()
        {
            InitializeComponent();
        }
        public Список_запросов(Действия_руководителя ДействияРуководителя) : this()
        {
            this.ДействияРуководителя = ДействияРуководителя;
        }

        private void Список_запросов_Load(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("queries.txt");
            queries.Clear();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split('|');
                    queries.Add(new Query(new Equipment(line[0].Trim(), line[1].Trim()), line[2].Trim(), line[3].Trim(), line[4].Trim(), line[5].Trim(), line[6].Trim()));
            }
            reader.Close();
            if (queries.Count == 0)
            {
                MessageBox.Show("Договоры по выбранному ресурсу отсутсвуют", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            dataGridView1.RowCount = queries.Count;
            for (int i = 0; i < queries.Count; i++)
            {
                dataGridView1[0, i].Value = queries[i].Equipment.Name;
                dataGridView1[1, i].Value = queries[i].Equipment.Manufacturer;
                dataGridView1[2, i].Value = queries[i].QueryDate;
                dataGridView1[3, i].Value = queries[i].DeliveryDate;
                dataGridView1[4, i].Value = queries[i].Number;
                dataGridView1[5, i].Value = queries[i].Status;
                dataGridView1[6, i].Value = queries[i].DescriptionOfProblem;
            }
        }

        public void buttons_disable()
        {
            this.button1.Visible = false;
            this.button2.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            queries[dataGridView1.CurrentCell.RowIndex].ChangeStatus("Принят");
            UpdateInformation();
        }
        private void button2_Click(object sender, EventArgs e)  
        {
            new Отклонить_запрос(this, queries[dataGridView1.CurrentCell.RowIndex]).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Список_запросов_FormClosed(object sender, FormClosedEventArgs e)
        {
            ДействияРуководителя.Show();
        }
        public void UpdateInformation() {
            dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value = "Принят";
            dataGridView1[6, dataGridView1.CurrentCell.RowIndex].Value = "";
        }
        public void UpdateInformation(string descriptionOfProblem)
        {
            dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value = "Отклонен";
            dataGridView1[6, dataGridView1.CurrentCell.RowIndex].Value = descriptionOfProblem;
        }
    }
}
