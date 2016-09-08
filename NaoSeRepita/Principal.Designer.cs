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
            this.pbxAlbumArt = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblMusicaArquivo = new System.Windows.Forms.Label();
            this.lblMusicaNome = new System.Windows.Forms.Label();
            this.lblMusicaAlbum = new System.Windows.Forms.Label();
            this.lblMusicaArtista = new System.Windows.Forms.Label();
            this.lblMusicaAno = new System.Windows.Forms.Label();
            this.lblMusicaDuracao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.plyPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlbumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // plyPrincipal
            // 
            this.plyPrincipal.Enabled = true;
            this.plyPrincipal.Location = new System.Drawing.Point(221, 221);
            this.plyPrincipal.Name = "plyPrincipal";
            this.plyPrincipal.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("plyPrincipal.OcxState")));
            this.plyPrincipal.Size = new System.Drawing.Size(678, 61);
            this.plyPrincipal.TabIndex = 4;
            this.plyPrincipal.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.plyPrincipal_PlayStateChange);
            this.plyPrincipal.MediaError += new AxWMPLib._WMPOCXEvents_MediaErrorEventHandler(this.plyPrincipal_MediaError);
            // 
            // lbxMusicas
            // 
            this.lbxMusicas.FormattingEnabled = true;
            this.lbxMusicas.Location = new System.Drawing.Point(15, 288);
            this.lbxMusicas.Name = "lbxMusicas";
            this.lbxMusicas.Size = new System.Drawing.Size(884, 147);
            this.lbxMusicas.TabIndex = 0;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(382, 441);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(463, 441);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnProxima
            // 
            this.btnProxima.Location = new System.Drawing.Point(871, 441);
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
            this.label1.Location = new System.Drawing.Point(17, 438);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quantidade: ";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(89, 438);
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
            // pbxAlbumArt
            // 
            this.pbxAlbumArt.Location = new System.Drawing.Point(15, 70);
            this.pbxAlbumArt.Name = "pbxAlbumArt";
            this.pbxAlbumArt.Size = new System.Drawing.Size(200, 200);
            this.pbxAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAlbumArt.TabIndex = 9;
            this.pbxAlbumArt.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Arquivo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Música:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Álbum:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Duração:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ano:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Artista:";
            // 
            // lblMusicaArquivo
            // 
            this.lblMusicaArquivo.AutoSize = true;
            this.lblMusicaArquivo.Location = new System.Drawing.Point(280, 70);
            this.lblMusicaArquivo.Name = "lblMusicaArquivo";
            this.lblMusicaArquivo.Size = new System.Drawing.Size(0, 13);
            this.lblMusicaArquivo.TabIndex = 14;
            // 
            // lblMusicaNome
            // 
            this.lblMusicaNome.AutoSize = true;
            this.lblMusicaNome.Location = new System.Drawing.Point(280, 95);
            this.lblMusicaNome.Name = "lblMusicaNome";
            this.lblMusicaNome.Size = new System.Drawing.Size(0, 13);
            this.lblMusicaNome.TabIndex = 14;
            // 
            // lblMusicaAlbum
            // 
            this.lblMusicaAlbum.AutoSize = true;
            this.lblMusicaAlbum.Location = new System.Drawing.Point(280, 120);
            this.lblMusicaAlbum.Name = "lblMusicaAlbum";
            this.lblMusicaAlbum.Size = new System.Drawing.Size(0, 13);
            this.lblMusicaAlbum.TabIndex = 14;
            // 
            // lblMusicaArtista
            // 
            this.lblMusicaArtista.AutoSize = true;
            this.lblMusicaArtista.Location = new System.Drawing.Point(280, 145);
            this.lblMusicaArtista.Name = "lblMusicaArtista";
            this.lblMusicaArtista.Size = new System.Drawing.Size(0, 13);
            this.lblMusicaArtista.TabIndex = 14;
            // 
            // lblMusicaAno
            // 
            this.lblMusicaAno.AutoSize = true;
            this.lblMusicaAno.Location = new System.Drawing.Point(280, 170);
            this.lblMusicaAno.Name = "lblMusicaAno";
            this.lblMusicaAno.Size = new System.Drawing.Size(0, 13);
            this.lblMusicaAno.TabIndex = 14;
            // 
            // lblMusicaDuracao
            // 
            this.lblMusicaDuracao.AutoSize = true;
            this.lblMusicaDuracao.Location = new System.Drawing.Point(280, 195);
            this.lblMusicaDuracao.Name = "lblMusicaDuracao";
            this.lblMusicaDuracao.Size = new System.Drawing.Size(0, 13);
            this.lblMusicaDuracao.TabIndex = 14;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 472);
            this.Controls.Add(this.lblMusicaDuracao);
            this.Controls.Add(this.lblMusicaAno);
            this.Controls.Add(this.lblMusicaArtista);
            this.Controls.Add(this.lblMusicaNome);
            this.Controls.Add(this.lblMusicaAlbum);
            this.Controls.Add(this.lblMusicaArquivo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbxAlbumArt);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlbumArt)).EndInit();
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
        private System.Windows.Forms.PictureBox pbxAlbumArt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMusicaArquivo;
        private System.Windows.Forms.Label lblMusicaNome;
        private System.Windows.Forms.Label lblMusicaAlbum;
        private System.Windows.Forms.Label lblMusicaArtista;
        private System.Windows.Forms.Label lblMusicaAno;
        private System.Windows.Forms.Label lblMusicaDuracao;
    }
}