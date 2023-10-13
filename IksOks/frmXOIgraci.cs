using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IksOks
{
    public partial class frmXOIgraci : Form
    {
        public string Igrac1 { get; set; }
        public string Igrac2 { get; set; }
        public frmXOIgraci()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var forma = new Form1();
            Igrac1 = txtIgrac1.Text;
            Igrac2 = txtIgrac2.Text;
            if (txtIgrac1.Text != "" && txtIgrac2.Text != "")
            {
                Hide();
            }
        }
    }
}
