using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace crudAlumnos.Clases
{
    class CConexion
    {
        //Esta es la clase conexion, aqui se lleva a cabo la conexion a la base de datos, para poder lograr esto hay 
        //que instalar la libreria Data.Mysql en el proyecto a travez de los paquetes NuGet.

        //Instancioamos el metodo MySqlConnection con el nombre conex
        MySqlConnection conex = new MySqlConnection();

        //Acá creamos la cadena de conexion a la base de datos
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
                //Intentamos conectarnos a la base de datos con el metodo nombrado anteriormente, pasandole la cadena
                // de conexion creada, y la abrimos con la funcion Open(); del metodo
                conex.ConnectionString = cadenaConexion;
                conex.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó a la base de datos, error: " + ex.ToString());
            }

            return conex;
        }

        public void cerraConexion()
        {
            //Cerramos la conexion a la base de datos con la funcion Close(); del metodo.
            conex.Close();
        }


    }
}
