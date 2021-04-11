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
    public partial class Form2_2_ : Form
    {
        public Form2_2_()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1_2_ frm1_2_ = new Form1_2_();
            frm1_2_.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3_2_ frm3_2_ = new Form3_2_();
            frm3_2_.Show();
            this.Hide();
        }

        
    }
}
