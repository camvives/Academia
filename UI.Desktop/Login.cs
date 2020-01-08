﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {
        public Usuario UsuarioActual { get; set; }
        public Persona PersonaActual { get; set; }

        public formLogin()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            if(Validaciones.ValidarUsuario(txtUsuario.Text, txtClave.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public (Usuario, Persona) BuscarUsuario()
        {
            UsuarioLogic ul = new UsuarioLogic();
            (UsuarioActual, PersonaActual) = ul.GetUsuario(txtUsuario.Text);
            return (UsuarioActual, PersonaActual);
        }
    }
}
