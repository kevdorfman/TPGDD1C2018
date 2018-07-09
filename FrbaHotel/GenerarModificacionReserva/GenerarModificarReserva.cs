﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FrbaHotel.Entidades;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class GenerarModificarReserva : Form
    {
        private Usuario usuario;

        public GenerarModificarReserva(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            /*
            DatosReservaAlta datosReserva = new DatosReservaAlta(usuario);
            Hide();
            datosReserva.Show();
             * */
            FormaNueva.DatosReservaAl datosReserva = new FormaNueva.DatosReservaAl(usuario);
            Hide();
            datosReserva.Show();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            ModificarReserva modificarReserva = new ModificarReserva(usuario);
            Hide();
            modificarReserva.Show();
        }
    }
}
