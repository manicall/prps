﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Начальник_отдела_сбыта
{
    public partial class Информация_о_ресурсе : Form
    {
        private Extraction extraction;
        private Список_добытых_ресурсов списокДобытыхРесурсов;
        public Информация_о_ресурсе()
        {
            InitializeComponent();
        }
        public Информация_о_ресурсе(Список_добытых_ресурсов списокДобытыхРесурсов, Extraction extraction) : this()
        {
            this.списокДобытыхРесурсов = списокДобытыхРесурсов;
            this.extraction = extraction;
        }

        private void Информация_о_ресурсе_Load(object sender, EventArgs e)
        {
            UpdateInformation(extraction);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void UpdateInformation(Extraction extraction) {
                textBox1.Text = extraction.Resource.Name;
                textBox2.Text = extraction.VolumeReserve;
                textBox3.Text = extraction.VolumeSale;
                textBox4.Text = extraction.VolumeExport;
                textBox5.Text = extraction.VolumeUndistributed;
                textBox6.Text = extraction.Resource.Description;       
        }
    }
}
