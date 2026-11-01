using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class FormAddGenero : Form
    {
        public FormAddGenero()
        {
            InitializeComponent();
        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {

        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Sistema formPrincipal = new Sistema();
            this.Close();
            formPrincipal.Show();
        }

        private void BtnCadastrarGenero_Click(object sender, EventArgs e)
        {
            Connection conexao = new Connection();
            bool retorno = conexao.insereGenero(txtNomeGenero.Text);
            if (retorno == false)
                MessageBox.Show(conexao.mensagem);
            else
                MessageBox.Show("Gênero adicionado com sucesso");
            txtNomeGenero.Clear();
            txtNomeGenero.Focus();
        }
    }
}
