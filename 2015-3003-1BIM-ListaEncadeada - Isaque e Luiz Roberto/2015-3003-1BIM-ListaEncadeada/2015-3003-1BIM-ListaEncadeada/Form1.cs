using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2015_3003_1BIM_ListaEncadeada
{
    public partial class Form1 : Form
    {
        private Lista lista;


        public Form1()
        {
            InitializeComponent();
        }

        private void CarregarPrograma(object sender, EventArgs e)
        {
            lista = new Lista();
        }

        private void InicializarLista(object sender, EventArgs e)
        {
            Elemento elemento = new Elemento(lista.Count);
            lista.Adiciona(elemento);
        }

        private void AdicionaElemento(object sender, EventArgs e)
        {
            Random r = new Random();
            //r.Next(1,100) + (2 * DateTime.Now.Second)
            Elemento elemento = new Elemento(lista.Count);
            lista.Adiciona(elemento);
        }

        private void AdicionaElementoXpos(object sender, EventArgs e)
        {
			Elemento elemento = new Elemento(lista.Count, lista.BuscaElementoX(Convert.ToInt32(numericUpDown1.Value)));
			lista.BuscaElementoX(Convert.ToInt32(numericUpDown1.Value) - 1).Proximo = null;
			lista.Adiciona(elemento);
        }

        private void ExibirLista(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
           
            lista.ImprimeLista(listBox1);
            
        }

		private void button5_Click(object sender, EventArgs e)
		{
			Elemento elemento = new Elemento(lista.Count,( lista.BuscaValor(Convert.ToInt32(numericUpDown2.Value))).Proximo);
			lista.BuscaValor(Convert.ToInt32(numericUpDown2.Value)).Proximo = null;
			lista.Adiciona(elemento);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if(radioButton1.Checked)
			{
			
                Elemento x = lista.BuscaElementoX(Convert.ToInt32(numericUpDown5.Value));
                lista.BuscaElementoX((Convert.ToInt32(numericUpDown5.Value)) - 1).Proximo = x.Proximo;
            }
			else if(radioButton2.Checked == true)
			{
                Elemento x = lista.BuscaValor(Convert.ToInt32(numericUpDown5.Value));
                lista.BuscaElementoX(lista.getPos(x) - 1).Proximo = x.Proximo;
            }
		}

        private void button6_Click(object sender, EventArgs e)
        {
            Elemento x = lista.BuscaElementoX(Convert.ToInt32(numericUpDown3.Value));
            Elemento y = lista.BuscaElementoX(Convert.ToInt32(numericUpDown4.Value));

            if (Convert.ToInt32(numericUpDown4.Value)/* AKA Y */ > Convert.ToInt32(numericUpDown3.Value)/* AKA X */)
            {
                if (x.Proximo != y)
                {
                    Elemento newProx = x.Proximo;
                    Elemento prev = lista.BuscaElementoX((Convert.ToInt32(numericUpDown4.Value)) - 1);
                    lista.BuscaElementoX((Convert.ToInt32(numericUpDown3.Value)) - 1).Proximo = y;
                    x.Proximo = y.Proximo;
                    y.Proximo = newProx;
                    prev.Proximo = x;
                }
                else
                {
                    Elemento prev = lista.BuscaElementoX((Convert.ToInt32(numericUpDown3.Value)) - 1).Proximo = y;
                    x.Proximo = y.Proximo;
                    y.Proximo = x;
                }

            }
            if (Convert.ToInt32(numericUpDown3.Value) > Convert.ToInt32(numericUpDown4.Value))
            {
                if (y.Proximo != x)
                {
                    Elemento newProx = y.Proximo;
                    Elemento prev = lista.BuscaElementoX((Convert.ToInt32(numericUpDown3.Value)) - 1);
                    lista.BuscaElementoX((Convert.ToInt32(numericUpDown4.Value)) - 1).Proximo = x;
                    y.Proximo = x.Proximo;
                    x.Proximo = newProx;
                    prev.Proximo = y;
                }
                else
                {
                    Elemento prev = lista.BuscaElementoX((Convert.ToInt32(numericUpDown4.Value)) - 1).Proximo = x;
                    y.Proximo = x.Proximo;
                    x.Proximo = y;
                }

            }
        }
    }
}
