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
    public partial class Действия_руководителя : Form
    {
        Form1 окноВходаВСистему;
        public Действия_руководителя()
        {
            InitializeComponent();
        }
        public Действия_руководителя(Form1 form1) : this()
        {
            окноВходаВСистему = form1;
        }

    }
}
