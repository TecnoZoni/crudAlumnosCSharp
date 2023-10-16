using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace crudAlumnos.Clases
{
    class CConexion
    {
        MySqlConnection conex = new MySqlConnection();

        static string servidor = "localhost";
        static string bd = "crudalumnos";
        static string usuario = "root";
        static string password = "A13e6minzoni";
        static string puerto = "3306";

        string cadenaConexion = "server=" + servidor +
            ";" + "port=" + puerto + ";" + "user id=" +
            usuario + ";" + "password=" + password + ";" +
            "database=" + bd + ";";

        public MySqlConnection establecerConexion()
        {
            try
            {
                conex.ConnectionString = cadenaConexion;
                conex.Open();
                //MessageBox.Show("Se conectó a la base de datos");

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la base de datos, error: " + ex.ToString());
            }

            return conex;
        }

        public void cerraConexion()
        {
            conex.Close();
        }


    }
}
