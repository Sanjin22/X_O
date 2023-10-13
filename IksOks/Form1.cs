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
    public partial class Form1 : Form
    {
        public string Igrac1 { get; set; }
        public string Igrac2 { get; set; }

        public int Brojac { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string igrac1, string igrac2) : this()
        {
            Igrac1 = igrac1;
            Igrac2 = igrac2;
        }

        private void NapraviPotez(object sender)
        {
            if (sender is Button)
            {
                var button = sender as Button;
                if (button.Text == "")
                {
                    if (Brojac % 2 == 0)
                        button.Text = "X";
                    else
                        button.Text = "O";
                    label1.Text = Brojac % 2 == 0 ? Igrac1 : Igrac2;
                }
                if (KrajIgre())
                    PostaviStatusDugmica(false);
                Brojac++;
            }
        }

        private void PostaviStatusDugmica(bool omoguceno, bool resetText = false, bool resetColor = false)
        {
            foreach (var control in this.Controls)
            {
                if(control is Button)
                {
                    var kontola = control as Button;
                    if (kontola != button10)
                    {
                        kontola.Enabled = omoguceno;
                        if (resetText)
                            kontola.Text = "";
                        if(resetColor)
                            kontola.UseVisualStyleBackColor = true;
                    }
                }
            }
            label1.Text = "";
            Brojac = 0;
        }

        private bool KrajIgre()
        {
            return ProvjeriRedove() || ProvjeriKolone() || ProvjeriDijagonale() || ProvjeriNerijeseno();
        }

        private bool ProvjeriNerijeseno()
        {
            foreach(var control in Controls)
            {
                if (control is Button)
                {
                    var kontola = control as Button;
                    if (kontola.Text == "")
                        return false;
                }
            }
            if (!(ProvjeriRedove() || ProvjeriKolone() || ProvjeriDijagonale()))
                return true;
            return false;
        }

        private bool ProvjeriDijagonale()
        {
            return ProvjeriPobjedu(button1, button5, button9) ||
                   ProvjeriPobjedu(button3, button5, button7);
        }

        private bool ProvjeriKolone()
        {
            return ProvjeriPobjedu(button1, button4, button7) ||
                   ProvjeriPobjedu(button2, button5, button8) ||
                   ProvjeriPobjedu(button3, button6, button9);
        }

        private bool ProvjeriRedove()
        {
            return ProvjeriPobjedu(button1, button2, button3) ||
                   ProvjeriPobjedu(button4, button5, button6) ||
                   ProvjeriPobjedu(button7, button8, button9);
        }

        private bool ProvjeriPobjedu(Button button1, Button button2, Button button3)
        {
            if (button1.Text != "" && button1.Text == button2.Text && button1.Text == button3.Text)
            {
                button1.BackColor = button2.BackColor = button3.BackColor = Color.Blue;
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            NapraviPotez(sender);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            PostaviStatusDugmica(true, true, true);
            UcitajImenaIgracaNaStartIRestart();
        }

        public frmXOIgraci forma = new frmXOIgraci();
        private void UcitajImenaIgracaNaStartIRestart()
        {
            forma.ShowDialog();
            Igrac1 = forma.Igrac1;
            Igrac2 = forma.Igrac2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UcitajImenaIgracaNaStartIRestart();

        }
    }
}
