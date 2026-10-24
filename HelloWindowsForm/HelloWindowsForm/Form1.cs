namespace HelloWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double peso = double.Parse(txtPeso.Text);
            double altura = double.Parse(txtAltura.Text);
            double imc = peso / (altura * altura);

            lblResultado.Text = $"RESULTADO: {imc:F2}";

            string classificacao;

            if (imc < 18.5)
            {
                classificacao = "Peso Baixo";
 
                lblClassificacao.BackColor = Color.LightBlue;

            }
            else if (imc < 25.0) {
                classificacao = "Peso Normal";
 
                lblClassificacao.BackColor = Color.Green;
            }
            else if (imc < 30.0) {
                classificacao = "Sobrepeso";
 
                lblClassificacao.BackColor = Color.Yellow;

            }
            else if (imc < 35.0) {
                classificacao = "Obesidade I";
 
                lblClassificacao.BackColor = Color.Orange;

            }
            else if (imc < 40.0) {
                classificacao = "Obesidade II";
 
                lblClassificacao.BackColor = Color.OrangeRed;

            }
            else {
                classificacao = "Obesidade III";
 
                lblClassificacao.BackColor = Color.Red;

            }

            lblClassificacao.Text = $"CLASSIFICAÇÃO: {classificacao}";


        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
