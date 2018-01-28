namespace NaoSeRepita
{
    partial class TagSelection
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
            this.lstTags = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstTags
            // 
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(12, 12);
            this.lstTags.Name = "lstTags";
            this.lstTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstTags.Size = new System.Drawing.Size(277, 212);
            this.lstTags.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(214, 235);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // TagSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 270);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lstTags);
            this.Name = "TagSelection";
            this.Text = "Não Se Repita - Tag Selection";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Button btnOK;
    }
}