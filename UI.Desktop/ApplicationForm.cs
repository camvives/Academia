using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public enum ModoForm { Alta, Baja, Modificacion, Consulta };

    public partial class ApplicationForm : Form
    {      
        public ModoForm Modo { get; set; }


        public ApplicationForm()
        {
            InitializeComponent();
        }

        public virtual void MapearDeDatos() { }

        public virtual void MapearADatos() { }

        public void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

    }
}
