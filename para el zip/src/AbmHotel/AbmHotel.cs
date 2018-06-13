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

namespace FrbaHotel.AbmHotel
{
    public partial class AbmHotel : Form
    {
        private Usuario usuario;

        public AbmHotel(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            DatosHotel datosHotel = new DatosHotel(usuario);
            datosHotel.Show();
        }

        private void buttonModificacion_Click(object sender, EventArgs e)
        {
            ListadoHotelModif listadoModif = new ListadoHotelModif();
            listadoModif.Show();
        }
    }
}
