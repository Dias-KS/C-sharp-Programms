using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dumpil._1._1
{
    public partial class Form3_2_ : Form
    {
        public Form3_2_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2_2_ frm2_2_ = new Form2_2_();
            frm2_2_.Show();
            this.Hide();
        }
    }
}
