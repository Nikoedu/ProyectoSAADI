namespace SAADI
{
    partial class PantallaInicioAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaInicioAlumno));
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seleccionarActividadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarAvanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.axShockwaveFlash2 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash2)).BeginInit();
            this.SuspendLayout();
            // 
            // rToolStripMenuItem
            // 
            this.rToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.seleccionarActividadToolStripMenuItem,
            this.guardarAvanceToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.rToolStripMenuItem.Name = "rToolStripMenuItem";
            this.rToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.rToolStripMenuItem.Text = "Menu";
            this.rToolStripMenuItem.Click += new System.EventHandler(this.rToolStripMenuItem_Click);
            // 
            // seleccionarActividadToolStripMenuItem
            // 
            this.seleccionarActividadToolStripMenuItem.Name = "seleccionarActividadToolStripMenuItem";
            this.seleccionarActividadToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.seleccionarActividadToolStripMenuItem.Text = "Seleccionar Actividad";
            this.seleccionarActividadToolStripMenuItem.Click += new System.EventHandler(this.seleccionarActividadToolStripMenuItem_Click);
            // 
            // guardarAvanceToolStripMenuItem
            // 
            this.guardarAvanceToolStripMenuItem.Name = "guardarAvanceToolStripMenuItem";
            this.guardarAvanceToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.guardarAvanceToolStripMenuItem.Text = "Guardar Avance";
            this.guardarAvanceToolStripMenuItem.Click += new System.EventHandler(this.guardarAvanceToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(895, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // axShockwaveFlash1
            // 
            this.axShockwaveFlash1.Enabled = true;
            this.axShockwaveFlash1.Location = new System.Drawing.Point(239, 27);
            this.axShockwaveFlash1.Name = "axShockwaveFlash1";
            this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            this.axShockwaveFlash1.Size = new System.Drawing.Size(650, 600);
            this.axShockwaveFlash1.TabIndex = 4;
            this.axShockwaveFlash1.Enter += new System.EventHandler(this.axShockwaveFlash1_Enter);
            // 
            // axShockwaveFlash2
            // 
            this.axShockwaveFlash2.Enabled = true;
            this.axShockwaveFlash2.Location = new System.Drawing.Point(7, 27);
            this.axShockwaveFlash2.Name = "axShockwaveFlash2";
            this.axShockwaveFlash2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash2.OcxState")));
            this.axShockwaveFlash2.Size = new System.Drawing.Size(233, 600);
            this.axShockwaveFlash2.TabIndex = 5;
            this.axShockwaveFlash2.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(this.axShockwaveFlash1_FlashCall);
            this.axShockwaveFlash2.Enter += new System.EventHandler(this.axShockwaveFlash2_Enter);
            // 
            // PantallaInicioAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 636);
            this.Controls.Add(this.axShockwaveFlash2);
            this.Controls.Add(this.axShockwaveFlash1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PantallaInicioAlumno";
            this.Text = "Inicio Alumno";
            this.Load += new System.EventHandler(this.PantallaInicioAlumno_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem rToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seleccionarActividadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarAvanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
        public AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash2;

    }
}