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
        
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("workers.txt");
            string[] line = reader.ReadLine().Split('|');
            if (new Worker1(line[0].Trim(), line[1].Trim(), line[2].Trim()).SingIn(textBox1.Text, textBox2.Text)) 
                { Hide(); new Список_добытых_ресурсов(this).Show(); return; }
            line = reader.ReadLine().Split('|');
            if (new Worker2(line[0].Trim(), line[1].Trim(), line[2].Trim()).SingIn(textBox1.Text, textBox2.Text)) 
                { Hide(); new Список_оборудования(this).Show(); return; }
            line = reader.ReadLine().Split('|');
            if (new Worker3(line[0].Trim(), line[1].Trim(), line[2].Trim()).SingIn(textBox1.Text, textBox2.Text))
                { Hide(); new Действия_руководителя(this).Show(); return; }
            MessageBox.Show("Неверное имя пользователя или пароль");
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
