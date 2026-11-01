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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Connection conexao = new Connection();
            if (conexao.verificaLogin(txtUser.Text, txtPassword.Text))
            {
                Sistema formPrincipal = new Sistema();
                this.Hide();
                formPrincipal.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Algo deu errado! " + conexao.mensagem);
        }
    }
}
