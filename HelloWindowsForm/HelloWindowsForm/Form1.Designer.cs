namespace HelloWindowsForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtPeso = new TextBox();
            txtAltura = new TextBox();
            btnCalcular = new Button();
            lblResultado = new Label();
            lblClassificacao = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(179, 32);
            label1.Name = "label1";
            label1.Size = new Size(444, 41);
            label1.TabIndex = 0;
            label1.Text = "SISTEMA DE CÁLCULO DE IMC";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(234, 140);
            label2.Name = "label2";
            label2.Size = new Size(95, 23);
            label2.TabIndex = 1;
            label2.Text = "PESO (kg):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(234, 191);
            label3.Name = "label3";
            label3.Size = new Size(113, 23);
            label3.TabIndex = 2;
            label3.Text = "ALTURA (m):";
            label3.Click += label3_Click;
            // 
            // txtPeso
            // 
            txtPeso.Font = new Font("Segoe UI", 10F);
            txtPeso.Location = new Point(390, 133);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(161, 30);
            txtPeso.TabIndex = 4;
            // 
            // txtAltura
            // 
            txtAltura.Font = new Font("Segoe UI", 10F);
            txtAltura.Location = new Point(390, 188);
            txtAltura.Name = "txtAltura";
            txtAltura.Size = new Size(161, 30);
            txtAltura.TabIndex = 5;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = SystemColors.Control;
            btnCalcular.Font = new Font("Cascadia Mono", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnCalcular.ForeColor = Color.FromArgb(0, 192, 0);
            btnCalcular.Location = new Point(349, 252);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(129, 40);
            btnCalcular.TabIndex = 6;
            btnCalcular.Text = "CALCULAR";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // lblResultado
            // 
            lblResultado.AutoSize = true;
            lblResultado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResultado.Location = new Point(274, 332);
            lblResultado.Name = "lblResultado";
            lblResultado.Size = new Size(117, 23);
            lblResultado.TabIndex = 7;
            lblResultado.Text = "RESULTADO: ";
            lblResultado.Click += label4_Click;
            // 
            // lblClassificacao
            // 
            lblClassificacao.AutoSize = true;
            lblClassificacao.BorderStyle = BorderStyle.Fixed3D;
            lblClassificacao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClassificacao.Location = new Point(274, 370);
            lblClassificacao.Name = "lblClassificacao";
            lblClassificacao.Size = new Size(152, 25);
            lblClassificacao.TabIndex = 8;
            lblClassificacao.Text = "CLASSIFICAÇÃO: ";
            lblClassificacao.Click += label4_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblClassificacao);
            Controls.Add(lblResultado);
            Controls.Add(btnCalcular);
            Controls.Add(txtAltura);
            Controls.Add(txtPeso);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPeso;
        private TextBox txtAltura;
        private Button btnCalcular;
        private Label lblResultado;
        private Label lblClassificacao;
    }
}
