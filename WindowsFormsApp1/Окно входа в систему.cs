using System;
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

            /*if (textBox2.Text == "1") new Form2().Show();
            else if (textBox2.Text == "2") new Оборудование().Show();
            else if (textBox2.Text == "3") new Form7().Show();
            else return;
            Hide();*/

            switch (Convert.ToInt32(textBox2.Text)) {
                case 1: 
                    new Список_добытых_ресурсов().Show(); break;
                case 2:
                    new Список_активных_договоров().Show(); break;
                case 3:
                    new Информация_о_ресурсе().Show(); break;
                case 4:
                    new Отправить_ресурсы_согласно_договору().Show(); break;
                case 5:
                    new Распределить_ресурсы().Show(); break;
                case 6:
                    new Добавить_оборудование().Show(); break;
                case 7:
                    new Информация_об_оборудовании().Show(); break;
                case 8:
                    new Отправить_запрос().Show(); break;
                case 9:
                    new Список_оборудования().Show(); break;
                case 10:
                    new Действия_руководителя().Show(); break;
                case 11:
                    new Отклонить_запрос().Show(); break;
                case 12:
                    new Список_доступных_договоров().Show(); break;
                case 13:
                    new Список_запросов().Show(); break;
                case 14:
                    new Информация_о_договоре().Show(); break;
            }

            


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
