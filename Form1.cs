using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MerceariaDoSrAntonio
{
    public partial class Form1 : Form
    {
        public string itens = "";
        public string formas = "";
        public double compra = 0.0;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }

        public void itens1()
        {
            foreach (CheckBox c in Controls.OfType<CheckBox>())
            {
                if (c.Checked)
                {
                    itens += c.Text + "\n";
                }
            }
        }

        public void formas1()
        {
            double resul = 0.0;

            if (rdbCartao.Checked)
            {

                resul = compra * 0.05;
                compra += resul;
            }

            if (rdbDinheiro.Checked)
            {
                resul = compra * 0.08;
                compra -= resul;
            }

            if (rdbPix.Checked)
            {
                resul = compra * 0.05;
                compra -= resul;
            }
        }
        public void valores1()
        {
            Dictionary<CheckBox, double> valores = new Dictionary<CheckBox, double>();

            valores.Clear();

            valores.Add(chkRefrigerante, 8.90);
            valores.Add(chkAzeite,38.50);
            valores.Add(chkBolodechocolate, 3.50);
            valores.Add(chkLeite, 4.99);
            valores.Add(chkMacarrão, 2.30);
            valores.Add(chkSucodelaranja, 5.75);
            valores.Add(chkChocolateaoleite, 6.50);
            valores.Add(chkPaodeforma, 3.20);
            valores.Add(chkArroz, 10.75);
            valores.Add(chkFeijão, 9.90);

            foreach(KeyValuePair<CheckBox,double> v in valores)
            {
                if (v.Key.Checked)
                {
                    compra += v.Value;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //avançar

            if (!rdbCartao.Checked && !rdbDinheiro.Checked && !rdbPix.Checked)
            {
                string msg2 = "Você não escolheu uma forma de pagamento";

                MessageBox.Show(msg2, "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                itens1();
                valores1();
                formas1();

                compra = Math.Round(compra, 2);

                string msg1 = $"Seus itens são:\n\n{itens} \n\n TOTAL: R${compra}";

                MessageBox.Show(msg1, "Sua compra!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                compra = 0.0;

                foreach (CheckBox l in Controls.OfType<CheckBox>())
                {
                    if (l.Checked)
                    {
                        itens = "";
                        l.Checked = false;
                    }
                }
                foreach (RadioButton y in Controls.OfType<RadioButton>())
                {
                    if (y.Checked)
                    {
                        y.Checked = false;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancelar

            foreach (CheckBox x in Controls.OfType<CheckBox>())
            {
                if (x.Checked)
                {
                    x.Checked = false;
                }
            }

            foreach (RadioButton y in Controls.OfType<RadioButton>())
            {
                if (y.Checked)
                {
                    y.Checked = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //sair

            Application.Exit();
        }
    }
}

