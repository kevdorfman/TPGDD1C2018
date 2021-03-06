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

namespace FrbaHotel.GenerarModificacionReserva.DatosReserva
{
    public abstract partial class DatosReserva : Form
    {
        protected Usuario usuario;
        protected DataTable tablaHabSeleccionadas = new DataTable();
        private bool primeraVez = true;

        public DatosReserva(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            cargarTiposHab(usuario.idHotel);
            cargarRegimenes(usuario.idHotel);
        }

        private void cargarTiposHab(int idHotel)
        {
            DB.ejecutarReader(
                "SELECT Descripcion " +
                "FROM LA_QUERY_DE_PAPEL.Tipo_Habitacion ",
            cargarComboBoxTiposHab);
        }

        public void cargarComboBoxTiposHab(SqlDataReader reader)
        {
            while (reader.Read())
            {
                comboBoxTipoHab.Items.Add(reader.GetString(0));
            }
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
            while (reader.Read())
            {
                comboBoxTipoReg.Items.Add(reader.GetString(0));
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            errorProviderReserva.Clear();
            validarDatos();
            if (Validaciones.errorProviderConError(errorProviderReserva, Controls))
                return;

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

        protected void cargarHabitaciones()
        {
            int idRegimen = DB.buscarIdRegimen(comboBoxTipoReg.SelectedItem.ToString());
            string tipoHab = "";
            if (comboBoxTipoHab.SelectedItem != null)
                tipoHab = comboBoxTipoHab.SelectedItem.ToString();

            DataTable tabla = tablaDeHabitaciones(idRegimen, tipoHab);

            dataGridViewHabitaciones.DataSource = tabla;

            if (primeraVez)
            {
                tablaHabSeleccionadas = tabla.Clone();
                tablaHabSeleccionadas.Clear();
                dataGridViewHabReservadas.DataSource = tablaHabSeleccionadas;
                primeraVez = false;
            }
        }

        protected abstract DataTable tablaDeHabitaciones(int idRegimen, string tipoHab);

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            errorProviderReserva.Clear();
            validarDatos();

            if (dataGridViewHabReservadas.Rows.Count == 0)
            {
                errorProviderReserva.SetError(dataGridViewHabReservadas, "Debe elegir al menos una habitacion");
            }

            if (Validaciones.errorProviderConError(errorProviderReserva, Controls))
                return;

            accionBotonSiguiente();
        }

        protected abstract void accionBotonSiguiente();

        protected void abrirConfirmacion(Reserva reserva)
        {
            ConfirmacionReserva confirmacion = new ConfirmacionReserva(reserva, tablaHabSeleccionadas, this);
            confirmacion.Show();
            Hide();
        }

        protected void validarDatos()
        {
            Validaciones.validarFechasAnteriores(errorProviderReserva, Controls);
            if (dateTimePickerDesde.Value > dateTimePickerHasta.Value)
            {
                errorProviderReserva.SetError(dateTimePickerDesde, "No puedes ser posterior a la fecha de egreso");
            }
        }

        private void dataGridViewHabitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            DataGridViewRow fila = dataGridViewHabitaciones.Rows[e.RowIndex];

            if (yaEsta(fila))
                return;
            
            tablaHabSeleccionadas.Rows.Add(
                fila.Cells["Nro_Habitacion"].Value,
                fila.Cells["Piso"].Value,
                fila.Cells["Ubicacion"].Value,
                fila.Cells["Tipo_Habitacion"].Value,
                fila.Cells["Descripcion"].Value,
                fila.Cells["Precio_Por_Habitacion"].Value);
        }

        private bool yaEsta(DataGridViewRow fila)
        {
            foreach (DataGridViewRow row in dataGridViewHabReservadas.Rows)
            {
                if(row.Cells["Nro_Habitacion"].Value.ToString() == fila.Cells["Nro_Habitacion"].Value.ToString())
                    return true;
            }

            return false;
        }

        private void dataGridViewHabReservadas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            string nroHabitacion = dataGridViewHabReservadas.CurrentRow.Cells["Nro_Habitacion"].Value.ToString();

            tablaHabSeleccionadas.Rows.Remove(tablaHabSeleccionadas.Select("Nro_Habitacion = " + nroHabitacion)[0]);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            Limpiador.limpiarControles(Controls);
        }
    }
}
