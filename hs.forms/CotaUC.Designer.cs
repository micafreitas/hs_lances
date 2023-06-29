namespace hs.forms
{
    partial class CotaUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCompetenciaProcessamento = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblProcessoAtual = new System.Windows.Forms.Label();
            this.prgProcesso = new System.Windows.Forms.ProgressBar();
            this.btnEfetuarLances = new System.Windows.Forms.Button();
            this.lblCotasAProcessar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCotasProcessadasAnteriormente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblContasAtivas = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblCompetenciaProcessamento);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblProcessoAtual);
            this.panel1.Controls.Add(this.prgProcesso);
            this.panel1.Controls.Add(this.btnEfetuarLances);
            this.panel1.Controls.Add(this.lblCotasAProcessar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblCotasProcessadasAnteriormente);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblContasAtivas);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblConta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 82);
            this.panel1.TabIndex = 0;
            // 
            // lblCompetenciaProcessamento
            // 
            this.lblCompetenciaProcessamento.AutoSize = true;
            this.lblCompetenciaProcessamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCompetenciaProcessamento.Location = new System.Drawing.Point(823, 61);
            this.lblCompetenciaProcessamento.Name = "lblCompetenciaProcessamento";
            this.lblCompetenciaProcessamento.Size = new System.Drawing.Size(12, 15);
            this.lblCompetenciaProcessamento.TabIndex = 12;
            this.lblCompetenciaProcessamento.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(641, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Competência de processamento: ";
            // 
            // lblProcessoAtual
            // 
            this.lblProcessoAtual.AutoSize = true;
            this.lblProcessoAtual.Location = new System.Drawing.Point(15, 61);
            this.lblProcessoAtual.Name = "lblProcessoAtual";
            this.lblProcessoAtual.Size = new System.Drawing.Size(12, 15);
            this.lblProcessoAtual.TabIndex = 10;
            this.lblProcessoAtual.Text = "-";
            // 
            // prgProcesso
            // 
            this.prgProcesso.Location = new System.Drawing.Point(15, 41);
            this.prgProcesso.Name = "prgProcesso";
            this.prgProcesso.Size = new System.Drawing.Size(860, 10);
            this.prgProcesso.TabIndex = 9;
            // 
            // btnEfetuarLances
            // 
            this.btnEfetuarLances.Location = new System.Drawing.Point(759, 8);
            this.btnEfetuarLances.Name = "btnEfetuarLances";
            this.btnEfetuarLances.Size = new System.Drawing.Size(117, 23);
            this.btnEfetuarLances.TabIndex = 8;
            this.btnEfetuarLances.Text = "Efetuar Lances";
            this.btnEfetuarLances.UseVisualStyleBackColor = true;
            this.btnEfetuarLances.Click += new System.EventHandler(this.btnEfetuarLances_Click);
            // 
            // lblCotasAProcessar
            // 
            this.lblCotasAProcessar.AutoSize = true;
            this.lblCotasAProcessar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCotasAProcessar.Location = new System.Drawing.Point(673, 12);
            this.lblCotasAProcessar.Name = "lblCotasAProcessar";
            this.lblCotasAProcessar.Size = new System.Drawing.Size(12, 15);
            this.lblCotasAProcessar.TabIndex = 7;
            this.lblCotasAProcessar.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(570, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cotas a processar: ";
            // 
            // lblCotasProcessadasAnteriormente
            // 
            this.lblCotasProcessadasAnteriormente.AutoSize = true;
            this.lblCotasProcessadasAnteriormente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCotasProcessadasAnteriormente.Location = new System.Drawing.Point(491, 12);
            this.lblCotasProcessadasAnteriormente.Name = "lblCotasProcessadasAnteriormente";
            this.lblCotasProcessadasAnteriormente.Size = new System.Drawing.Size(12, 15);
            this.lblCotasProcessadasAnteriormente.TabIndex = 5;
            this.lblCotasProcessadasAnteriormente.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cotas Processadas Anteriormente: ";
            // 
            // lblContasAtivas
            // 
            this.lblContasAtivas.AutoSize = true;
            this.lblContasAtivas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContasAtivas.Location = new System.Drawing.Point(218, 12);
            this.lblContasAtivas.Name = "lblContasAtivas";
            this.lblContasAtivas.Size = new System.Drawing.Size(12, 15);
            this.lblContasAtivas.TabIndex = 3;
            this.lblContasAtivas.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cotas Ativas: ";
            // 
            // lblConta
            // 
            this.lblConta.AutoSize = true;
            this.lblConta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConta.Location = new System.Drawing.Point(57, 12);
            this.lblConta.Name = "lblConta";
            this.lblConta.Size = new System.Drawing.Size(12, 15);
            this.lblConta.TabIndex = 1;
            this.lblConta.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conta: ";
            // 
            // CotaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "CotaUC";
            this.Size = new System.Drawing.Size(907, 99);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label lblCotasProcessadasAnteriormente;
        private Label label4;
        private Label lblContasAtivas;
        private Label label3;
        private Label lblConta;
        private Button btnEfetuarLances;
        private Label lblCotasAProcessar;
        private ProgressBar prgProcesso;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private Label lblProcessoAtual;
        private Label lblCompetenciaProcessamento;
        private Label label5;
    }
}
