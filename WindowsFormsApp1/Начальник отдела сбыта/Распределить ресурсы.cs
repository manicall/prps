﻿using System;
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
    public partial class Распределить_ресурсы : Form
    {
        Список_добытых_ресурсов списокДобытыхРесурсов;
        Extraction extraction;
        public Распределить_ресурсы()
        {
            InitializeComponent();
        }
        public Распределить_ресурсы(Список_добытых_ресурсов списокДобытыхРесурсов, Extraction extraction) : this()
        {
            this.списокДобытыхРесурсов = списокДобытыхРесурсов;
            this.extraction = extraction;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBox1.Text) > 0 &&
                    Convert.ToDecimal(textBox2.Text) >= 0 &&
                    Convert.ToDecimal(textBox3.Text) >= 0 ||
                        Convert.ToDecimal(textBox1.Text) >= 0 &&
                        Convert.ToDecimal(textBox2.Text) > 0 &&
                        Convert.ToDecimal(textBox3.Text) >= 0 ||
                            Convert.ToDecimal(textBox1.Text) >= 0 &&
                            Convert.ToDecimal(textBox2.Text) >= 0 &&
                            Convert.ToDecimal(textBox3.Text) > 0
                    )
                {
                    extraction.DistributionOfResources(textBox1.Text, textBox2.Text, textBox3.Text);
                }
                else MessageBox.Show("Следует ввести число больше нуля", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
