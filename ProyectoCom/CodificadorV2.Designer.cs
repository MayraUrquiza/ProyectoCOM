namespace ProyectoCOM
{
    partial class CodificadorV2
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
            this.txtGenerar = new System.Windows.Forms.TextBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.lblCadena = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.cmbTiempo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGenerar
            // 
            this.txtGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txtGenerar.Location = new System.Drawing.Point(156, 32);
            this.txtGenerar.Name = "txtGenerar";
            this.txtGenerar.Size = new System.Drawing.Size(885, 23);
            this.txtGenerar.TabIndex = 4;
            this.txtGenerar.TextChanged += new System.EventHandler(this.txtGenerar_TextChanged);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblMensaje.Location = new System.Drawing.Point(12, 35);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(138, 17);
            this.lblMensaje.TabIndex = 3;
            this.lblMensaje.Text = "Mensaje a codificar: ";
            // 
            // picture
            // 
            this.picture.Location = new System.Drawing.Point(77, 78);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(388, 249);
            this.picture.TabIndex = 5;
            this.picture.TabStop = false;
            // 
            // lblCadena
            // 
            this.lblCadena.AutoSize = true;
            this.lblCadena.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadena.Location = new System.Drawing.Point(30, 370);
            this.lblCadena.Name = "lblCadena";
            this.lblCadena.Size = new System.Drawing.Size(72, 18);
            this.lblCadena.TabIndex = 6;
            this.lblCadena.Text = "cadena: ";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1064, 9);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cmbTiempo
            // 
            this.cmbTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTiempo.FormattingEnabled = true;
            this.cmbTiempo.Items.AddRange(new object[] {
            "1",
            "1,5",
            "2",
            "2,5",
            "3"});
            this.cmbTiempo.Location = new System.Drawing.Point(156, 5);
            this.cmbTiempo.Name = "cmbTiempo";
            this.cmbTiempo.Size = new System.Drawing.Size(121, 21);
            this.cmbTiempo.TabIndex = 8;
            this.cmbTiempo.SelectedIndexChanged += new System.EventHandler(this.cmbTiempo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tiempo:";
            // 
            // CodificadorV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 606);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTiempo);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblCadena);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.txtGenerar);
            this.Controls.Add(this.lblMensaje);
            this.Name = "CodificadorV2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Codificador";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGenerar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Label lblCadena;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ComboBox cmbTiempo;
        private System.Windows.Forms.Label label1;
    }
}