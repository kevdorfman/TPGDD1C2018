﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FrbaHotel.Utilidades
{
    class DB
    {
        public static SqlConnection conexionDB = new SqlConnection("Data Source=LOCALHOST\\SQLSERVER2012;Initial Catalog=GD1C2018;User ID=gdHotel2018; Password=gd2018");

        private static SqlCommand nuevoComando(String query, params object[] args)
        {
            SqlCommand comando = new SqlCommand(query, conexionDB);

            for (int i = 0; i < args.Length; i += 2)
            {
                comando.Parameters.AddWithValue("@" + args[i].ToString(), args[i + 1]);
            }

            return comando;
        }

        public static void ejecutarProcedimiento(String nombre, params object[] args)
        {
            SqlCommand comando = nuevoComando(nombre, args);

            comando.CommandType = CommandType.StoredProcedure;

            ejecutarComandoProcedimiento(comando);
        }

        public static void ejecutarComandoProcedimiento(SqlCommand comando)
        {
            try
            {
                conexionDB.Open();
                comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                conexionDB.Close();
                throw ex;
            }

            conexionDB.Close();
        }

        public static void ejecutarReader(String query, Action<SqlDataReader> usarReader)
        {
            SqlCommand comando = nuevoComando(query);

            comando.CommandType = CommandType.Text;

            conexionDB.Open();
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                usarReader(reader);
            }
            conexionDB.Close();
        }

        public static int correrQuery(String query)
        {
            SqlCommand comando = new SqlCommand(query, conexionDB);
            int filasAfectadas = 0;
            try
            {
                conexionDB.Open();
                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                conexionDB.Close();
                throw ex;
            }

            conexionDB.Close();
            return filasAfectadas;
        }

        public static Object correrQueryEscalar(String query)
        {
            SqlCommand comando = new SqlCommand(query, conexionDB);
            Object retorno;
            try
            {
                conexionDB.Open();
                retorno = comando.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                conexionDB.Close();
                throw ex;
            }

            conexionDB.Close();
            return retorno;
        }

        public static DataTable correrQueryTabla(String query)
        {
            SqlCommand comando = new SqlCommand(query, conexionDB);
            DataTable tabla = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    conexionDB.Open();
                    adapter.Fill(tabla);
                }
            }
            catch (SqlException exception)
            {
                conexionDB.Close();
                throw exception;
            }

            conexionDB.Close();
            return tabla;
        }
    }
}