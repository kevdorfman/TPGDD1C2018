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
using FrbaHotel.Utilidades;
using System.Data.SqlClient;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class DatosReserva : Form
    {
        private Usuario usuario;

        public DatosReserva(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            //cargarTiposHab(usuario.idHotel);
            cargarRegimenes(usuario.idHotel);
        }

        private void cargarRegimenes(int idHotel)
        {
            DB.ejecutarReader(
                "SELECT Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Regimen r " +
                    "JOIN LA_QUERY_DE_PAPEL.RegimenxHotel rh " +
                        "ON r.Id_Regimen = rh.Id_Regimen " +
                    "WHERE Id_Hotel = @idHotel",
            cargarComboBoxRegimenes, "idHotel", idHotel);
        }

        public void cargarComboBoxRegimenes(SqlDataReader reader)
        {
            comboBoxTipoReg.Items.Add(reader.GetString(0));
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (comboBoxTipoReg.SelectedIndex == -1)
            {
                SeleccionRegimen regimen = new SeleccionRegimen(usuario);
                if (regimen.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("Debe elegir un regimen");
                    return;
                }
                comboBoxTipoReg.SelectedIndex = comboBoxTipoReg.Items.IndexOf(regimen.descripcionRegimen);
            }

            cargarHabitaciones();
        }

        private void cargarHabitaciones()
        {
            int idRegimen = DB.buscarIdRegimen(comboBoxTipoReg.SelectedItem.ToString());

            dataGridViewReserva.DataSource = DB.correrQueryTabla(
                "SELECT h.Nro_Habitacion, Piso, Ubicacion, Tipo_Hab, Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Habitacion h " +
                    "JOIN LA_QUERY_DE_PAPEL.RegimenxHotel rho ON h.Id_Hotel = rho.Id_Hotel " +
                    "JOIN LA_QUERY_DE_PAPEL.ReservaxHabitacion rha ON h.Id_Hotel = rha.Id_Hotel AND h.Nro_Habitacion = rha.Nro_Habitacion " +
                    "JOIN LA_QUERY_DE_PAPEL.Reserva r ON rha.Id_Reserva = r.Id_Reserva " +
	                    "WHERE rho.Id_Hotel = @idHotel " +
	                        "AND rho.Id_Regimen = @idRegimen " +
	                        //"AND r.Habilitada = 1 " +
	                        "AND NOT (Fecha_Inicio BETWEEN @fechaDesde AND @fechaHasta OR Fecha_Fin BETWEEN @fechaDesde AND @fechaHasta)",
                "idHotel", usuario.idHotel, "idRegimen", idRegimen, "fechaDesde", dateTimePickerDesde.Value, "fechaHasta" , dateTimePickerHasta.Value);
        }

        private void dataGridViewReserva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
