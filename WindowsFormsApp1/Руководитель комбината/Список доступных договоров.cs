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
namespace WindowsFormsApp1.Руководитель_комбината
{
    public partial class Список_доступных_договоров : Form
    {
        private Действия_руководителя ДействияРуководителя;
        List<Agreement> agreements = new List<Agreement>();
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
            StreamReader reader = new StreamReader("agreements.txt");
            agreements.Clear();
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split('|');
                if (line[4].Trim().ToLower() == "доступный") agreements.Add(new Agreement(new Resource(line[0].Trim(), ""), 
                        line[1].Trim(), line[2].Trim(), line[3].Trim(), line[5].Trim(), line[4].Trim()));
            }
            reader.Close();
            if (agreements.Count == 0)
            {
                MessageBox.Show("Доступные договоры отсутствуют", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            dataGridView1.RowCount = agreements.Count;
            for (int i = 0; i < agreements.Count; i++)
            {
                dataGridView1[0, i].Value = agreements[i].Resource.Name;
                dataGridView1[1, i].Value = agreements[i].StartDate;
                dataGridView1[2, i].Value = agreements[i].EndDate;
                dataGridView1[3, i].Value = agreements[i].Remainder;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agreements[dataGridView1.CurrentCell.RowIndex].ChangeStatus();
            //agreements.Remove(agreements[dataGridView1.CurrentCell.RowIndex]);

            Список_доступных_договоров_Load(new object(), new EventArgs());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            new Информация_о_договоре(agreements[dataGridView1.CurrentCell.RowIndex]).Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Список_доступных_договоров_FormClosed(object sender, FormClosedEventArgs e)
        {
            ДействияРуководителя.Show();
        }
    }
}
