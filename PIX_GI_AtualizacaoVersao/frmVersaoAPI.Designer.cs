namespace PIX_GI_AtualizacaoVersao
{
    partial class frmVersaoAPI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNovaVersao = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNovaVersao = new System.Windows.Forms.TextBox();
            this.btnGerarVersao = new System.Windows.Forms.Button();
            this.txtCaminho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNovaVersao)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Location = new System.Drawing.Point(12, 57);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.Size = new System.Drawing.Size(281, 440);
            this.dgvHistorico.TabIndex = 0;
            this.dgvHistorico.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorico_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Histórico";
            // 
            // dgvNovaVersao
            // 
            this.dgvNovaVersao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNovaVersao.Location = new System.Drawing.Point(299, 57);
            this.dgvNovaVersao.Name = "dgvNovaVersao";
            this.dgvNovaVersao.Size = new System.Drawing.Size(985, 440);
            this.dgvNovaVersao.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nova versão";
            // 
            // txtNovaVersao
            // 
            this.txtNovaVersao.Location = new System.Drawing.Point(516, 31);
            this.txtNovaVersao.Name = "txtNovaVersao";
            this.txtNovaVersao.Size = new System.Drawing.Size(100, 20);
            this.txtNovaVersao.TabIndex = 4;
            // 
            // btnGerarVersao
            // 
            this.btnGerarVersao.Location = new System.Drawing.Point(750, 29);
            this.btnGerarVersao.Name = "btnGerarVersao";
            this.btnGerarVersao.Size = new System.Drawing.Size(177, 23);
            this.btnGerarVersao.TabIndex = 5;
            this.btnGerarVersao.Text = "Gerar YAML novo";
            this.btnGerarVersao.UseVisualStyleBackColor = true;
            this.btnGerarVersao.Click += new System.EventHandler(this.btnGerarVersao_Click);
            // 
            // txtCaminho
            // 
            this.txtCaminho.Location = new System.Drawing.Point(516, 5);
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.Size = new System.Drawing.Size(411, 20);
            this.txtCaminho.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Caminho Versões:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(411, 20);
            this.textBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmVersaoAPI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 515);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtCaminho);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGerarVersao);
            this.Controls.Add(this.txtNovaVersao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvNovaVersao);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvHistorico);
            this.Name = "frmVersaoAPI";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNovaVersao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvNovaVersao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNovaVersao;
        private System.Windows.Forms.Button btnGerarVersao;
        private System.Windows.Forms.TextBox txtCaminho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

