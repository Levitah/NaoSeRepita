﻿namespace NaoSeRepita
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.plyPrincipal = new AxWMPLib.AxWindowsMediaPlayer();
            this.lbxMusicas = new System.Windows.Forms.ListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.fbdDiretorioMusicas = new System.Windows.Forms.FolderBrowserDialog();
            this.btnProxima = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNomeArquivo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.plyPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // plyPrincipal
            // 
            this.plyPrincipal.Enabled = true;
            this.plyPrincipal.Location = new System.Drawing.Point(12, 237);
            this.plyPrincipal.Name = "plyPrincipal";
            this.plyPrincipal.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("plyPrincipal.OcxState")));
            this.plyPrincipal.Size = new System.Drawing.Size(884, 188);
            this.plyPrincipal.TabIndex = 4;
            this.plyPrincipal.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.plyPrincipal_PlayStateChange);
            this.plyPrincipal.MediaError += new AxWMPLib._WMPOCXEvents_MediaErrorEventHandler(this.plyPrincipal_MediaError);
            // 
            // lbxMusicas
            // 
            this.lbxMusicas.FormattingEnabled = true;
            this.lbxMusicas.Location = new System.Drawing.Point(12, 71);
            this.lbxMusicas.Name = "lbxMusicas";
            this.lbxMusicas.Size = new System.Drawing.Size(884, 147);
            this.lbxMusicas.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(383, 431);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(464, 431);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnProxima
            // 
            this.btnProxima.Location = new System.Drawing.Point(868, 431);
            this.btnProxima.Name = "btnProxima";
            this.btnProxima.Size = new System.Drawing.Size(28, 23);
            this.btnProxima.TabIndex = 2;
            this.btnProxima.Text = ">>";
            this.btnProxima.UseVisualStyleBackColor = true;
            this.btnProxima.Click += new System.EventHandler(this.btnProxima_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quantidade: ";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(86, 221);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(13, 13);
            this.lblQuantidade.TabIndex = 6;
            this.lblQuantidade.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Em execução:";
            // 
            // lblNomeArquivo
            // 
            this.lblNomeArquivo.AutoSize = true;
            this.lblNomeArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeArquivo.Location = new System.Drawing.Point(14, 29);
            this.lblNomeArquivo.Name = "lblNomeArquivo";
            this.lblNomeArquivo.Size = new System.Drawing.Size(222, 33);
            this.lblNomeArquivo.TabIndex = 8;
            this.lblNomeArquivo.Text = "lblNomeArquivo";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 466);
            this.Controls.Add(this.lblNomeArquivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProxima);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lbxMusicas);
            this.Controls.Add(this.plyPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Não Se Repita";
            ((System.ComponentModel.ISupportInitialize)(this.plyPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer plyPrincipal;
        private System.Windows.Forms.ListBox lbxMusicas;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.FolderBrowserDialog fbdDiretorioMusicas;
        private System.Windows.Forms.Button btnProxima;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNomeArquivo;
    }
}