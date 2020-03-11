namespace ProyectoCOM
{
    partial class FormCodificador
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
            this.pictureCodificador = new System.Windows.Forms.PictureBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.txtGenerar = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCodificador)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCodificador
            // 
            this.pictureCodificador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureCodificador.Location = new System.Drawing.Point(0, 52);
            this.pictureCodificador.Name = "pictureCodificador";
            this.pictureCodificador.Size = new System.Drawing.Size(1351, 768);
            this.pictureCodificador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCodificador.TabIndex = 0;
            this.pictureCodificador.TabStop = false;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblMensaje.Location = new System.Drawing.Point(13, 21);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(138, 17);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "Mensaje a codificar: ";
            // 
            // txtGenerar
            // 
            this.txtGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtGenerar.Location = new System.Drawing.Point(157, 18);
            this.txtGenerar.Name = "txtGenerar";
            this.txtGenerar.Size = new System.Drawing.Size(885, 23);
            this.txtGenerar.TabIndex = 2;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnGenerar.Location = new System.Drawing.Point(1048, 13);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(290, 33);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar código de colores";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click_1);
            // 
            // FormCodificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtGenerar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.pictureCodificador);
            this.Name = "FormCodificador";
            this.ShowIcon = false;
            this.Text = "Codificador";
            ((System.ComponentModel.ISupportInitialize)(this.pictureCodificador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCodificador;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.TextBox txtGenerar;
        private System.Windows.Forms.Button btnGenerar;
    }
}