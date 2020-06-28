using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Руководитель_комбината
{
    public partial class Список_доступных_договоров : Form
    {
        public Список_доступных_договоров()
        {
            InitializeComponent();
        }

        private void Список_доступных_договоров_Load(object sender, EventArgs e)
        {
            this.dataGridView1.RowCount = 10;
        }
    }
}
