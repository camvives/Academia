﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {
        public Especialidad EspActual { get; set; }

        public EspecialidadDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadDesktop(Especialidad esp, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.EspActual = esp;

            try
            {
                this.MapearDeDatos();
            }
            catch
            {
                MessageBox.Show("Error al recuperar datos de la especialidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                EspActual = new Especialidad();
                EspActual.State = BusinessEntity.States.New;
            }
            else if(Modo == ModoForm.Modificacion)
            {
                EspActual.State = BusinessEntity.States.Modified;
            }

            this.EspActual.Descripcion = this.txtDesc.Text;
        }

        public override void MapearDeDatos()
        {
            this.txtDesc.Text = EspActual.Descripcion;

            if (this.Modo == ModoForm.Modificacion)
            {
                this.btnAgregar.Text = "Guardar";
            }
        }

        public void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                EspecialidadLogic espLog = new EspecialidadLogic();
                espLog.Save(EspActual);

                if (Modo == ModoForm.Alta)
                {
                    this.Notificar("Nueva Especialidad", "La especialidad ha sido registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.Notificar("Editar Especialidad", "Los cambios han sido registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.Notificar("Error", "Error al registrar especialidad, intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}