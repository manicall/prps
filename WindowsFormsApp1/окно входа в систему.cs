using System;
using System.IO;
using WindowsFormsApp1.Начальник_цеха;
using WindowsFormsApp1.Руководитель_комбината;
using WindowsFormsApp1.Начальник_отдела_сбыта;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        Worker1 worker1 = new Worker1();
        Worker2 worker2 = new Worker2();
        Worker3 worker3 = new Worker3();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (TrySingIn("Director.txt", worker1)) {
                Hide();
                new Действия_руководителя(this).Show();
            }
            else if (TrySingIn("foreman.txt", worker2))
            {
                Hide();
                new Список_оборудования(this).Show();
            }
            else if (TrySingIn("head of sales department.txt", worker3))
            {
                Hide();
                new Список_добытых_ресурсов(this).Show();
            }
            else MessageBox.Show("Неверное имя пользователя или пароль", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        bool TrySingIn(string fileName, Workers worker) {
            StreamReader reader = new StreamReader(fileName);
            while (!reader.EndOfStream)
            {
                string[] line = reader.ReadLine().Split('|');  
                Workers temp = new Workers(line[0].Trim(), line[1].Trim(), line[2].Trim());
                if (temp.SingIn(textBox1.Text, textBox2.Text))
                {
                    worker.Copy(temp);
                    return true;
                }
            }
            reader.Close();
            return false;
        }
    }
}
