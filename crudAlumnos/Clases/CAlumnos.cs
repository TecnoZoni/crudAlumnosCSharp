using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace crudAlumnos.Clases
{
    class CAlumnos
    {
        public void MostrarAlumnos(DataGridView tablaAlumnos)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "select * from alumnos";
                tablaAlumnos.DataSource = null;

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaAlumnos.DataSource = dt;
                objetoConexion.cerraConexion();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la base de datos por un error: " + ex.ToString());
            }
        }

        public void InscribirAlumnos(int matricula, String nombre, String apellido, int edad, String email, String carrera)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "insert into alumnos(matricula, nombre, apellido, edad, email, carrera)" +
                    "values('" + matricula + "','" + nombre + "','" + apellido + "','" + edad + "','" + email + "','" + carrera + "');";


                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myComand.ExecuteReader();
                MessageBox.Show("El alumno se Inscribio Correctamente");

                objetoConexion.cerraConexion();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo inscribir el aulmno por un error: " + ex.ToString());
            }
        }

        public void BajarAlumnos(int matricula)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "DELETE FROM alumnos WHERE matricula='" + matricula + "';";

                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myComand.ExecuteReader();
                MessageBox.Show("El alumno se dio de baja Correctamente.");

                objetoConexion.cerraConexion();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se dio de baja el alumno por un error: " + ex.ToString());
            }
        }

        public void ModificarAlumnos(int matricula, String nombre, String apellido, int edad, String email, String carrera)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "UPDATE alumnos SET nombre = '" + nombre + "', apellido = '" + apellido + "', edad = '" + edad +
               "', email = '" + email + "', carrera = '" + carrera + "' WHERE matricula = '" + matricula + "';";



                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myComand.ExecuteReader();
                MessageBox.Show("El alumno se Modifico Correctamente");


                objetoConexion.cerraConexion();

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar el aulmno por un error: " + ex.ToString());
            }
        }

        public void BuscarAlumnosMatricula(int matricula)
        {
            CConexion objetoConexion = new CConexion();

            string query = "SELECT * FROM alumnos WHERE matricula LIKE '%" + matricula + "%';";

            MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
            MySqlDataReader reader = myComand.ExecuteReader();
            MessageBox.Show("El alumno con la matricula"+matricula+" se encontro Correctamente.");

            objetoConexion.cerraConexion();
        }

        public void BuscarAlumnos(string nombre, string apellido)
        {
            try
            {
                CConexion objetoConexion = new CConexion();
               
                string query = "SELECT * FROM alumnos WHERE nombre LIKE '%"+nombre+ "%' OR apellido LIKE '%" + apellido + "%';";

                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myComand.ExecuteReader();
                MessageBox.Show("El alumno se busco Correctamente");


                objetoConexion.cerraConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo encontrar al aulmno por un error: " + ex.ToString());
            }
        }*/
    }
}
