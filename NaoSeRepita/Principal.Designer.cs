namespace NaoSeRepita
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
            ((System.ComponentModel.ISupportInitialize)(this.plyPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // plyPrincipal
            // 
            this.plyPrincipal.Enabled = true;
            this.plyPrincipal.Location = new System.Drawing.Point(12, 185);
            this.plyPrincipal.Name = "plyPrincipal";
            this.plyPrincipal.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("plyPrincipal.OcxState")));
            this.plyPrincipal.Size = new System.Drawing.Size(508, 197);
            this.plyPrincipal.TabIndex = 1;
            this.plyPrincipal.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.plyPrincipal_PlayStateChange);
            this.plyPrincipal.MediaError += new AxWMPLib._WMPOCXEvents_MediaErrorEventHandler(this.plyPrincipal_MediaError);
            // 
            // lbxMusicas
            // 
            this.lbxMusicas.FormattingEnabled = true;
            this.lbxMusicas.Location = new System.Drawing.Point(12, 28);
            this.lbxMusicas.Name = "lbxMusicas";
            this.lbxMusicas.Size = new System.Drawing.Size(427, 147);
            this.lbxMusicas.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(445, 152);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(445, 28);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 394);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lbxMusicas);
            this.Controls.Add(this.plyPrincipal);
            this.Name = "Principal";
            this.Text = "Principal";
            ((System.ComponentModel.ISupportInitialize)(this.plyPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer plyPrincipal;
        private System.Windows.Forms.ListBox lbxMusicas;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.FolderBrowserDialog fbdDiretorioMusicas;
    }
}