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
    public partial class PlanDesktop : ApplicationForm
    {
        public Plan PlanActual { get; set; }
        public PlanDesktop()
        {
            InitializeComponent();
        }

        public PlanDesktop(Plan plan, ModoForm modo) : this()
        {
            this.Modo = modo;
            this.PlanActual = plan;

            try
            {
                this.MapearDeDatos();
                this.Text = "Editar Plan";
            }
            catch
            {
                MessageBox.Show("Error al recuperar datos del plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void CompletarCombobox()
        {
            EspecialidadLogic especialidad = new EspecialidadLogic();

            cmbCarrera.DataSource = especialidad.GetAll();
            cmbCarrera.DisplayMember = "Descripcion";
            cmbCarrera.ValueMember = "ID";
        }

        private void PlanDesktop_Load(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Alta)
            {
                this.CompletarCombobox();
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                PlanActual = new Plan();
                PlanActual.State = BusinessEntity.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                PlanActual.State = BusinessEntity.States.Modified;
            }

            this.PlanActual.Descripcion = this.txtDescripcion.Text;
            Especialidad esp = (Especialidad)cmbCarrera.SelectedItem;
            this.PlanActual.IDEspecialidad = esp.ID;
        }

        public override void MapearDeDatos()
        {
            EspecialidadLogic el = new EspecialidadLogic();
            Especialidad especialidad = el.GetOne(PlanActual.IDEspecialidad);


            this.btnAgregar.Text = "Guardar";
            this.txtDescripcion.Text = PlanActual.Descripcion;
            this.CompletarCombobox();
            this.cmbCarrera.SelectedIndex = cmbCarrera.FindStringExact(especialidad.Descripcion);
        }

        public void GuardarCambios()
        {
            try
            {
                this.MapearADatos();
                PlanLogic planLog = new PlanLogic();
                planLog.Save(PlanActual);

                if (Modo == ModoForm.Alta)
                {
                    this.Notificar("Nuevo Plan", "El plan ha sido registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Modo == ModoForm.Modificacion)
                {
                    this.Notificar("Editar Plan", "Los cambios han sido registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                this.Notificar("Error", "Error al registrar plan, intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public bool Validar()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                this.Notificar("Campo vacío", "Debe completar el campo 'Descripción'", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cmbCarrera.SelectedIndex == -1)
            {
                this.Notificar("Especialidad no válida", "Debe seleccionar una especialidad.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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