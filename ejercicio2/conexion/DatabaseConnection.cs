using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ejercicio2.conexion
{
	public class DatabaseConnection
	{
        private static string ruta = "Server=localhost\\SQLEXPRESS02;Database=ejercicio;Trusted_Connection=True;";
        private SqlConnection conexion;

        public SqlConnection GetConnection()
        {
            
            conexion = new SqlConnection(ruta);
            if (conexion == null)
            {
                conexion = new SqlConnection(ruta);
            }
            if (conexion.State == System.Data.ConnectionState.Closed)
            {
                conexion.Open();
            }

            return conexion;
        }
        public void CloseConnection()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }

    }
}