namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.class14 = new WindowsFormsApplication1.Class1();
            this.class13 = new WindowsFormsApplication1.Class1();
            this.class12 = new WindowsFormsApplication1.Class1();
            this.class11 = new WindowsFormsApplication1.Class1();
            this.label1 = new System.Windows.Forms.Label();
            this.Lista_Partidas_Jugadas_Posicion = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ListaC = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.class14);
            this.panel1.Controls.Add(this.class13);
            this.panel1.Controls.Add(this.class12);
            this.panel1.Controls.Add(this.class11);
            this.panel1.Location = new System.Drawing.Point(12, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 90);
            this.panel1.TabIndex = 4;
            // 
            // class14
            // 
            this.class14.Location = new System.Drawing.Point(242, 18);
            this.class14.Name = "class14";
            this.class14.Size = new System.Drawing.Size(53, 52);
            this.class14.TabIndex = 3;
            this.class14.Text = "4";
            this.class14.UseVisualStyleBackColor = true;
            // 
            // class13
            // 
            this.class13.Location = new System.Drawing.Point(167, 18);
            this.class13.Name = "class13";
            this.class13.Size = new System.Drawing.Size(53, 52);
            this.class13.TabIndex = 2;
            this.class13.Text = "3";
            this.class13.UseVisualStyleBackColor = true;
            // 
            // class12
            // 
            this.class12.Location = new System.Drawing.Point(88, 18);
            this.class12.Name = "class12";
            this.class12.Size = new System.Drawing.Size(53, 52);
            this.class12.TabIndex = 1;
            this.class12.Text = "2";
            this.class12.UseVisualStyleBackColor = true;
            // 
            // class11
            // 
            this.class11.Location = new System.Drawing.Point(13, 18);
            this.class11.Name = "class11";
            this.class11.Size = new System.Drawing.Size(53, 52);
            this.class11.TabIndex = 0;
            this.class11.Text = "1";
            this.class11.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre_Jugador";
            // 
            // Lista_Partidas_Jugadas_Posicion
            // 
            this.Lista_Partidas_Jugadas_Posicion.FormattingEnabled = true;
            this.Lista_Partidas_Jugadas_Posicion.Location = new System.Drawing.Point(10, 144);
            this.Lista_Partidas_Jugadas_Posicion.Name = "Lista_Partidas_Jugadas_Posicion";
            this.Lista_Partidas_Jugadas_Posicion.Size = new System.Drawing.Size(309, 212);
            this.Lista_Partidas_Jugadas_Posicion.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Lista_Partidas_Jugadas_Posicion);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(12, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 369);
            this.panel2.TabIndex = 7;
            // 
            // ListaC
            // 
            this.ListaC.FormattingEnabled = true;
            this.ListaC.Location = new System.Drawing.Point(25, 7);
            this.ListaC.Name = "ListaC";
            this.ListaC.Size = new System.Drawing.Size(292, 160);
            this.ListaC.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ListaC);
            this.panel3.Location = new System.Drawing.Point(361, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(343, 175);
            this.panel3.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(435, 192);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(269, 187);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(354, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 391);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Class1 class11;
        private Class1 class12;
        private Class1 class13;
        private Class1 class14;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Lista_Partidas_Jugadas_Posicion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox ListaC;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}