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
            this.ListaC = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.class14 = new WindowsFormsApplication1.Class1();
            this.class13 = new WindowsFormsApplication1.Class1();
            this.class12 = new WindowsFormsApplication1.Class1();
            this.class11 = new WindowsFormsApplication1.Class1();
            this.label1 = new System.Windows.Forms.Label();
            this.Lista_Partidas_Jugadas_Posicion = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListaC
            // 
            this.ListaC.FormattingEnabled = true;
            this.ListaC.Location = new System.Drawing.Point(14, 13);
            this.ListaC.Name = "ListaC";
            this.ListaC.Size = new System.Drawing.Size(300, 134);
            this.ListaC.TabIndex = 8;
            this.ListaC.SelectedIndexChanged += new System.EventHandler(this.ListaC_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ListaC);
            this.panel3.Location = new System.Drawing.Point(374, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(330, 155);
            this.panel3.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(388, 252);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 176);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(720, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.class14);
            this.panel1.Controls.Add(this.class13);
            this.panel1.Controls.Add(this.class12);
            this.panel1.Controls.Add(this.class11);
            this.panel1.Location = new System.Drawing.Point(11, 29);
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
            this.class12.Location = new System.Drawing.Point(85, 18);
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
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre_Jugador";
            // 
            // Lista_Partidas_Jugadas_Posicion
            // 
            this.Lista_Partidas_Jugadas_Posicion.FormattingEnabled = true;
            this.Lista_Partidas_Jugadas_Posicion.Location = new System.Drawing.Point(11, 125);
            this.Lista_Partidas_Jugadas_Posicion.Name = "Lista_Partidas_Jugadas_Posicion";
            this.Lista_Partidas_Jugadas_Posicion.Size = new System.Drawing.Size(309, 121);
            this.Lista_Partidas_Jugadas_Posicion.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Lista_Partidas_Jugadas_Posicion);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(12, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 264);
            this.panel2.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(388, 217);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Invitar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(12, 325);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(330, 55);
            this.panel4.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(16, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "NOTIFICACIONES";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "Aceptar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(94, 398);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "Denegar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 440);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListaC;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private Class1 class14;
        private Class1 class13;
        private Class1 class12;
        private Class1 class11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Lista_Partidas_Jugadas_Posicion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}