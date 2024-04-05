namespace PIX_GI_AtualizacaoVersao
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.informeMensalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.obterDisponibilidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manutençãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarVersaoAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.informeMensalToolStripMenuItem,
            this.manutençãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // informeMensalToolStripMenuItem
            // 
            this.informeMensalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obterDisponibilidadeToolStripMenuItem});
            this.informeMensalToolStripMenuItem.Name = "informeMensalToolStripMenuItem";
            this.informeMensalToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.informeMensalToolStripMenuItem.Text = "Informe Mensal";
            // 
            // obterDisponibilidadeToolStripMenuItem
            // 
            this.obterDisponibilidadeToolStripMenuItem.Name = "obterDisponibilidadeToolStripMenuItem";
            this.obterDisponibilidadeToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.obterDisponibilidadeToolStripMenuItem.Text = "Obter disponibilidade";
            // 
            // manutençãoToolStripMenuItem
            // 
            this.manutençãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.atualizarVersaoAPIToolStripMenuItem});
            this.manutençãoToolStripMenuItem.Name = "manutençãoToolStripMenuItem";
            this.manutençãoToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.manutençãoToolStripMenuItem.Text = "Manutenção";
            // 
            // atualizarVersaoAPIToolStripMenuItem
            // 
            this.atualizarVersaoAPIToolStripMenuItem.Name = "atualizarVersaoAPIToolStripMenuItem";
            this.atualizarVersaoAPIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.atualizarVersaoAPIToolStripMenuItem.Text = "Atualizar Versao API";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem informeMensalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem obterDisponibilidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manutençãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atualizarVersaoAPIToolStripMenuItem;
    }
}