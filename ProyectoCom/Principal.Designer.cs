namespace ProyectoCOM
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
            this.btnCod = new System.Windows.Forms.Button();
            this.btnDecod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCod
            // 
            this.btnCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnCod.Location = new System.Drawing.Point(79, 45);
            this.btnCod.Name = "btnCod";
            this.btnCod.Size = new System.Drawing.Size(210, 87);
            this.btnCod.TabIndex = 0;
            this.btnCod.Text = "Codificador";
            this.btnCod.UseVisualStyleBackColor = true;
            this.btnCod.Click += new System.EventHandler(this.btnCod_Click);
            // 
            // btnDecod
            // 
            this.btnDecod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnDecod.Location = new System.Drawing.Point(79, 169);
            this.btnDecod.Name = "btnDecod";
            this.btnDecod.Size = new System.Drawing.Size(210, 87);
            this.btnDecod.TabIndex = 1;
            this.btnDecod.Text = "Decodificador";
            this.btnDecod.UseVisualStyleBackColor = true;
            this.btnDecod.Click += new System.EventHandler(this.btnDecod_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(370, 313);
            this.Controls.Add(this.btnDecod);
            this.Controls.Add(this.btnCod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Principal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Codificador y decodificador por colores";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCod;
        private System.Windows.Forms.Button btnDecod;
    }
}