namespace UI.Desktop
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsddbtnArchivoAdmin = new System.Windows.Forms.ToolStripDropDownButton();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.especialidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbtnEditarAdmin = new System.Windows.Forms.ToolStripDropDownButton();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddBtnArchivoAlumno = new System.Windows.Forms.ToolStripDropDownButton();
            this.misDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosPersonalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbtnArchivoAdmin,
            this.tsddbtnEditarAdmin,
            this.tsddBtnArchivoAlumno});
            resources.ApplyResources(this.tsMenu, "tsMenu");
            this.tsMenu.Name = "tsMenu";
            // 
            // tsddbtnArchivoAdmin
            // 
            this.tsddbtnArchivoAdmin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbtnArchivoAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem1});
            resources.ApplyResources(this.tsddbtnArchivoAdmin, "tsddbtnArchivoAdmin");
            this.tsddbtnArchivoAdmin.Name = "tsddbtnArchivoAdmin";
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem1,
            this.toolStripSeparator2,
            this.especialidadToolStripMenuItem,
            this.planToolStripMenuItem,
            this.materiaToolStripMenuItem});
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            resources.ApplyResources(this.nuevoToolStripMenuItem1, "nuevoToolStripMenuItem1");
            // 
            // usuarioToolStripMenuItem1
            // 
            this.usuarioToolStripMenuItem1.Name = "usuarioToolStripMenuItem1";
            resources.ApplyResources(this.usuarioToolStripMenuItem1, "usuarioToolStripMenuItem1");
            this.usuarioToolStripMenuItem1.Click += new System.EventHandler(this.UsuarioToolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // especialidadToolStripMenuItem
            // 
            this.especialidadToolStripMenuItem.Name = "especialidadToolStripMenuItem";
            resources.ApplyResources(this.especialidadToolStripMenuItem, "especialidadToolStripMenuItem");
            this.especialidadToolStripMenuItem.Click += new System.EventHandler(this.EspecialidadToolStripMenuItem_Click);
            // 
            // planToolStripMenuItem
            // 
            this.planToolStripMenuItem.Name = "planToolStripMenuItem";
            resources.ApplyResources(this.planToolStripMenuItem, "planToolStripMenuItem");
            this.planToolStripMenuItem.Click += new System.EventHandler(this.PlanToolStripMenuItem_Click);
            // 
            // materiaToolStripMenuItem
            // 
            this.materiaToolStripMenuItem.Name = "materiaToolStripMenuItem";
            resources.ApplyResources(this.materiaToolStripMenuItem, "materiaToolStripMenuItem");
            this.materiaToolStripMenuItem.Click += new System.EventHandler(this.MateriaToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // salirToolStripMenuItem1
            // 
            this.salirToolStripMenuItem1.Name = "salirToolStripMenuItem1";
            resources.ApplyResources(this.salirToolStripMenuItem1, "salirToolStripMenuItem1");
            this.salirToolStripMenuItem1.Click += new System.EventHandler(this.SalirToolStripMenuItem1_Click);
            // 
            // tsddbtnEditarAdmin
            // 
            this.tsddbtnEditarAdmin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbtnEditarAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.especialidadesToolStripMenuItem,
            this.planesToolStripMenuItem,
            this.materiasToolStripMenuItem});
            resources.ApplyResources(this.tsddbtnEditarAdmin, "tsddbtnEditarAdmin");
            this.tsddbtnEditarAdmin.Name = "tsddbtnEditarAdmin";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            resources.ApplyResources(this.usuariosToolStripMenuItem, "usuariosToolStripMenuItem");
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.UsuariosToolStripMenuItem_Click);
            // 
            // especialidadesToolStripMenuItem
            // 
            this.especialidadesToolStripMenuItem.Name = "especialidadesToolStripMenuItem";
            resources.ApplyResources(this.especialidadesToolStripMenuItem, "especialidadesToolStripMenuItem");
            this.especialidadesToolStripMenuItem.Click += new System.EventHandler(this.EspecialidadesToolStripMenuItem_Click);
            // 
            // planesToolStripMenuItem
            // 
            this.planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            resources.ApplyResources(this.planesToolStripMenuItem, "planesToolStripMenuItem");
            this.planesToolStripMenuItem.Click += new System.EventHandler(this.PlanesToolStripMenuItem_Click);
            // 
            // materiasToolStripMenuItem
            // 
            this.materiasToolStripMenuItem.Name = "materiasToolStripMenuItem";
            resources.ApplyResources(this.materiasToolStripMenuItem, "materiasToolStripMenuItem");
            this.materiasToolStripMenuItem.Click += new System.EventHandler(this.MateriasToolStripMenuItem_Click);
            // 
            // tsddBtnArchivoAlumno
            // 
            this.tsddBtnArchivoAlumno.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddBtnArchivoAlumno.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.misDatosToolStripMenuItem,
            this.salirToolStripMenuItem});
            resources.ApplyResources(this.tsddBtnArchivoAlumno, "tsddBtnArchivoAlumno");
            this.tsddBtnArchivoAlumno.Name = "tsddBtnArchivoAlumno";
            // 
            // misDatosToolStripMenuItem
            // 
            this.misDatosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datosPersonalesToolStripMenuItem,
            this.datosDeUsuarioToolStripMenuItem});
            this.misDatosToolStripMenuItem.Name = "misDatosToolStripMenuItem";
            resources.ApplyResources(this.misDatosToolStripMenuItem, "misDatosToolStripMenuItem");
            // 
            // datosPersonalesToolStripMenuItem
            // 
            this.datosPersonalesToolStripMenuItem.Name = "datosPersonalesToolStripMenuItem";
            resources.ApplyResources(this.datosPersonalesToolStripMenuItem, "datosPersonalesToolStripMenuItem");
            this.datosPersonalesToolStripMenuItem.Click += new System.EventHandler(this.DatosPersonalesToolStripMenuItem_Click);
            // 
            // datosDeUsuarioToolStripMenuItem
            // 
            this.datosDeUsuarioToolStripMenuItem.Name = "datosDeUsuarioToolStripMenuItem";
            resources.ApplyResources(this.datosDeUsuarioToolStripMenuItem, "datosDeUsuarioToolStripMenuItem");
            this.datosDeUsuarioToolStripMenuItem.Click += new System.EventHandler(this.DatosDeUsuarioToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // formMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.Controls.Add(this.tsMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.Name = "formMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripDropDownButton tsddbtnArchivoAdmin;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton tsddbtnEditarAdmin;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem especialidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsddBtnArchivoAlumno;
        private System.Windows.Forms.ToolStripMenuItem misDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosPersonalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosDeUsuarioToolStripMenuItem;
    }
}

