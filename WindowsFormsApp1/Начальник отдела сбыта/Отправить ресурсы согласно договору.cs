using System;
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
    public partial class Отправить_ресурсы_согласно_договору : Form
    {
        private Extraction extraction;
        private Список_активных_договоров списокАктивныхДоговоров;
        private Agreement agreement;
        public Отправить_ресурсы_согласно_договору()
        {
            InitializeComponent();
        }

        public Отправить_ресурсы_согласно_договору(Список_активных_договоров списокАктивныхДоговоров, Extraction extraction, Agreement agreement) : this()
        {
            this.списокАктивныхДоговоров = списокАктивныхДоговоров;
            this.extraction = extraction;
            this.agreement = agreement;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(textBox1.Text) > 0)
                {
                    if (extraction.CheckReduceUndistributed(textBox1.Text))
                        if (agreement.SendResourcesAccordingToAgreement(textBox1.Text))
                            extraction.ReduceUndistributed(textBox1.Text);
                }
                else MessageBox.Show("Следует ввести число больше нуля", "Сообщение", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error); }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
