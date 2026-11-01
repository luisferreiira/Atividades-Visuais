using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {
        int idAlterar;

        public Sistema()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        

        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }







        private void Sistema_Load(object sender, EventArgs e)
        {
            listarCBGeneros();
            listarGridBandas();
        }

        public void listarCBGeneros() {
            Connection conexao = new Connection();
            DataTable tabelaDados = new DataTable();
            tabelaDados = conexao.listaGeneros();
            cbGenero.DataSource = tabelaDados;
            cbGenero.DisplayMember = "genero"; // o que mostra no form
            cbGenero.ValueMember = "idgenero"; // o que vale na inserção

            cbAlteraGenero.DataSource = tabelaDados;
            cbAlteraGenero.DisplayMember = "genero"; // o que mostra no form
            cbAlteraGenero.ValueMember = "idgenero"; // o que vale na inserção
        }

        public void listarGridBandas() {
            Connection conexao = new Connection();
            dgBandas.DataSource = conexao.listaBandas();
            dgBandas.Columns["idbandas"].Visible = false;
        }
        


        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            // busca por nome
            (dgBandas.DataSource as DataTable).DefaultView.RowFilter =
                string.Format("nome like '{0}%'", txtBusca.Text);
        }

        private void btnRemoveBanda_Click(object sender, EventArgs e)
        {
            int linha = dgBandas.CurrentRow.Index;
            int id = Convert.ToInt32(
                    dgBandas.Rows[linha].Cells["idbandas"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir este registro?",
                "Sim, excluir banda", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                Connection conexao = new Connection();
                bool retorno = conexao.deletaBanda(id);
                if (retorno == true)
                {
                    MessageBox.Show("Banda excluída com sucesso!");
                    listarGridBandas();
                }// fim if retorno true
                else
                    MessageBox.Show(conexao.mensagem);
            }// fim if Ok Cancela
            else
                MessageBox.Show("Exclusão cancelada");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int linha = dgBandas.CurrentRow.Index;// pega a linha selecionada
            idAlterar = Convert.ToInt32(
              dgBandas.Rows[linha].Cells["idbandas"].Value.ToString());
            txtAlteraNome.Text =
                 dgBandas.Rows[linha].Cells["nome"].Value.ToString();
            txtAlteraIntegrantes.Text =
                dgBandas.Rows[linha].Cells["integrantes"].Value.ToString();
            txtAlteraRanking.Text =
                dgBandas.Rows[linha].Cells["ranking"].Value.ToString();
            cbAlteraGenero.Text =
                dgBandas.Rows[linha].Cells["genero"].Value.ToString();
            tabControl1.SelectedTab = tabAlterar;// muda aba
        }

         private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            Connection conexao = new Connection();
            Banda novaBanda = new Banda();
            novaBanda.Nome = txtAlteraNome.Text;
            novaBanda.Integrantes = Convert.ToInt32(txtAlteraIntegrantes.Text);
            novaBanda.Ranking = Convert.ToInt32(txtAlteraRanking.Text);
            novaBanda.Genero = Convert.ToInt32(cbAlteraGenero.SelectedValue.ToString());
            bool retorno = conexao.alteraBanda(novaBanda, idAlterar);
            if (retorno == false)
                MessageBox.Show(conexao.mensagem);
            else
                MessageBox.Show("Alteração realizada com sucesso!");

            listarGridBandas();


        }

        private void bntAddGenero_Click(object sender, EventArgs e)
        {
            FormAddGenero formGenero = new FormAddGenero();
            this.Hide();
            formGenero.ShowDialog();
            this.Close();
        }

        void limparCampos() {
            txtnome.Clear();
            cbGenero.Text = "";
            txtintegrantes.Clear();
            txtranking.Clear();
            txtnome.Focus();
        }
        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            Connection conexao = new Connection();
            Banda novaBanda = new Banda();
            novaBanda.Nome = txtnome.Text;
            novaBanda.Integrantes = Convert.ToInt32(txtintegrantes.Text);
            novaBanda.Ranking = Convert.ToInt32(txtranking.Text);
            novaBanda.Genero = Convert.ToInt32(cbGenero.SelectedValue.ToString());
            bool retorno = conexao.insereBanda(novaBanda);
            if (!retorno) { MessageBox.Show(conexao.mensagem); }

            limparCampos();
            listarGridBandas();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void marcador_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
