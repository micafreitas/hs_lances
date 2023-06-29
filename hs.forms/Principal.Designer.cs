namespace Hs
{
    partial class Principal
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
            this.components = new System.ComponentModel.Container();
            this.btnProcessarTodos = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnContas = new System.Windows.Forms.FlowLayoutPanel();
            this.carteiraClienteDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            this.npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.carteiraClienteDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcessarTodos
            // 
            this.btnProcessarTodos.Location = new System.Drawing.Point(0, 0);
            this.btnProcessarTodos.Name = "btnProcessarTodos";
            this.btnProcessarTodos.Size = new System.Drawing.Size(914, 30);
            this.btnProcessarTodos.TabIndex = 0;
            this.btnProcessarTodos.Text = "Efetuar lances de todas as contas";
            this.btnProcessarTodos.UseVisualStyleBackColor = true;
            this.btnProcessarTodos.Click += new System.EventHandler(this.btnProcessarTodos_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnProcessarTodos);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 557);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pnContas);
            this.panel2.Location = new System.Drawing.Point(3, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(911, 517);
            this.panel2.TabIndex = 4;
            // 
            // pnContas
            // 
            this.pnContas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnContas.Location = new System.Drawing.Point(0, 0);
            this.pnContas.Name = "pnContas";
            this.pnContas.Size = new System.Drawing.Size(911, 517);
            this.pnContas.TabIndex = 0;
            // 
            // npgsqlCommandBuilder1
            // 
            this.npgsqlCommandBuilder1.QuotePrefix = "\"";
            this.npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // npgsqlDataAdapter1
            // 
            this.npgsqlDataAdapter1.DeleteCommand = null;
            this.npgsqlDataAdapter1.InsertCommand = null;
            this.npgsqlDataAdapter1.SelectCommand = null;
            this.npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 559);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.Text = "HS Consórcios";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.carteiraClienteDtoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnProcessarTodos;
        private Panel panel1;
        private BindingSource carteiraClienteDtoBindingSource;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel pnContas;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
    }
}