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
            this.cursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.especialidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comisiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddbtnEditarAdmin = new System.Windows.Forms.ToolStripDropDownButton();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.especialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddBtnArchivoAlumno = new System.Windows.Forms.ToolStripDropDownButton();
            this.misDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosPersonalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosDeUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimirCertificadoDeInscripciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnInscribirse = new System.Windows.Forms.ToolStripButton();
            this.tss2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnEstadoAcademico = new System.Windows.Forms.ToolStripButton();
            this.tss3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnConsultaCursos = new System.Windows.Forms.ToolStripButton();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbtnArchivoAdmin,
            this.tsddbtnEditarAdmin,
            this.tsddBtnArchivoAlumno,
            this.tss1,
            this.tsbtnInscribirse,
            this.tss2,
            this.tsbtnEstadoAcademico,
            this.tss3,
            this.tsbtnConsultaCursos});
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
            this.cursoToolStripMenuItem,
            this.toolStripSeparator2,
            this.especialidadToolStripMenuItem,
            this.planToolStripMenuItem,
            this.materiaToolStripMenuItem,
            this.comisiónToolStripMenuItem});
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            resources.ApplyResources(this.nuevoToolStripMenuItem1, "nuevoToolStripMenuItem1");
            // 
            // usuarioToolStripMenuItem1
            // 
            this.usuarioToolStripMenuItem1.Name = "usuarioToolStripMenuItem1";
            resources.ApplyResources(this.usuarioToolStripMenuItem1, "usuarioToolStripMenuItem1");
            this.usuarioToolStripMenuItem1.Click += new System.EventHandler(this.UsuarioToolStripMenuItem1_Click);
            // 
            // cursoToolStripMenuItem
            // 
            this.cursoToolStripMenuItem.Name = "cursoToolStripMenuItem";
            resources.ApplyResources(this.cursoToolStripMenuItem, "cursoToolStripMenuItem");
            this.cursoToolStripMenuItem.Click += new System.EventHandler(this.CursoToolStripMenuItem_Click);
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
            // comisiónToolStripMenuItem
            // 
            this.comisiónToolStripMenuItem.Name = "comisiónToolStripMenuItem";
            resources.ApplyResources(this.comisiónToolStripMenuItem, "comisiónToolStripMenuItem");
            this.comisiónToolStripMenuItem.Click += new System.EventHandler(this.ComisiónToolStripMenuItem_Click);
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
            this.cursosToolStripMenuItem,
            this.toolStripSeparator3,
            this.especialidadesToolStripMenuItem,
            this.planesToolStripMenuItem,
            this.materiasToolStripMenuItem,
            this.comisionesToolStripMenuItem});
            resources.ApplyResources(this.tsddbtnEditarAdmin, "tsddbtnEditarAdmin");
            this.tsddbtnEditarAdmin.Name = "tsddbtnEditarAdmin";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            resources.ApplyResources(this.usuariosToolStripMenuItem, "usuariosToolStripMenuItem");
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.UsuariosToolStripMenuItem_Click);
            // 
            // cursosToolStripMenuItem
            // 
            this.cursosToolStripMenuItem.Name = "cursosToolStripMenuItem";
            resources.ApplyResources(this.cursosToolStripMenuItem, "cursosToolStripMenuItem");
            this.cursosToolStripMenuItem.Click += new System.EventHandler(this.CursosToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
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
            // comisionesToolStripMenuItem
            // 
            this.comisionesToolStripMenuItem.Name = "comisionesToolStripMenuItem";
            resources.ApplyResources(this.comisionesToolStripMenuItem, "comisionesToolStripMenuItem");
            this.comisionesToolStripMenuItem.Click += new System.EventHandler(this.ComisionesToolStripMenuItem_Click);
            // 
            // tsddBtnArchivoAlumno
            // 
            this.tsddBtnArchivoAlumno.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddBtnArchivoAlumno.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.misDatosToolStripMenuItem,
            this.imprimirCertificadoDeInscripciónToolStripMenuItem,
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
            // imprimirCertificadoDeInscripciónToolStripMenuItem
            // 
            this.imprimirCertificadoDeInscripciónToolStripMenuItem.Name = "imprimirCertificadoDeInscripciónToolStripMenuItem";
            resources.ApplyResources(this.imprimirCertificadoDeInscripciónToolStripMenuItem, "imprimirCertificadoDeInscripciónToolStripMenuItem");
            this.imprimirCertificadoDeInscripciónToolStripMenuItem.Click += new System.EventHandler(this.imprimirCertificadoDeInscripciónToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            resources.ApplyResources(this.salirToolStripMenuItem, "salirToolStripMenuItem");
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // tss1
            // 
            this.tss1.Name = "tss1";
            resources.ApplyResources(this.tss1, "tss1");
            // 
            // tsbtnInscribirse
            // 
            this.tsbtnInscribirse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsbtnInscribirse, "tsbtnInscribirse");
            this.tsbtnInscribirse.Name = "tsbtnInscribirse";
            this.tsbtnInscribirse.Click += new System.EventHandler(this.TsbtnInscribirse_Click);
            // 
            // tss2
            // 
            this.tss2.Name = "tss2";
            resources.ApplyResources(this.tss2, "tss2");
            // 
            // tsbtnEstadoAcademico
            // 
            this.tsbtnEstadoAcademico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsbtnEstadoAcademico, "tsbtnEstadoAcademico");
            this.tsbtnEstadoAcademico.Name = "tsbtnEstadoAcademico";
            this.tsbtnEstadoAcademico.Click += new System.EventHandler(this.TsbtnEstadoAcademico_Click);
            // 
            // tss3
            // 
            this.tss3.Name = "tss3";
            resources.ApplyResources(this.tss3, "tss3");
            // 
            // tsbtnConsultaCursos
            // 
            this.tsbtnConsultaCursos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.tsbtnConsultaCursos, "tsbtnConsultaCursos");
            this.tsbtnConsultaCursos.Name = "tsbtnConsultaCursos";
            this.tsbtnConsultaCursos.Click += new System.EventHandler(this.TsbtnConsultaCursos_Click);
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
        private System.Windows.Forms.ToolStripMenuItem cursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem comisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbtnInscribirse;
        private System.Windows.Forms.ToolStripSeparator tss1;
        private System.Windows.Forms.ToolStripSeparator tss2;
        private System.Windows.Forms.ToolStripButton tsbtnEstadoAcademico;
        private System.Windows.Forms.ToolStripSeparator tss3;
        private System.Windows.Forms.ToolStripButton tsbtnConsultaCursos;
        private System.Windows.Forms.ToolStripMenuItem cursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comisiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imprimirCertificadoDeInscripciónToolStripMenuItem;
    }
}

