using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace crudAlumnos.Clases
{
    class CValidaciones
    {
        public static bool EsDNI(string texto)
        {
            // Verifica que el texto tenga exactamente 8 dígitos numéricos
            return Regex.IsMatch(texto, @"^\d{8}$");
        }

        public static bool EsTexto(string texto)
        {
            // Verifica que el texto contenga solo letras y espacios
            return Regex.IsMatch(texto, @"^[a-zA-Z\s]+$");
        }

        public static bool EsEdadValida(string texto)
        {
            // Verifica que el texto contenga solo números y que sea menor a 3 cifras
            int edad;
            if (int.TryParse(texto, out edad))
            {
                return edad >= 0 && edad < 1000;
            }
            return false;
        }

        public static bool EsEmailValido(string texto)
        {
            // Verifica que el texto tenga el formato de una dirección de correo electrónico
            return Regex.IsMatch(texto, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        public bool ValidarCampos(TextBox txtMatricula, TextBox txtNombre, TextBox txtApellido, TextBox txtEdad, TextBox txtEmail, ComboBox cmbCarrera)
        {
            if (!EsDNI(txtMatricula.Text))
            {
                MessageBox.Show("La matrícula debe ser un número de DNI válido.");
                return false;
            }

            if (!EsTexto(txtNombre.Text))
            {
                MessageBox.Show("El nombre debe contener solo letras y espacios.");
                return false;
            }

            if (!EsTexto(txtApellido.Text))
            {
                MessageBox.Show("El apellido debe contener solo letras y espacios.");
                return false;
            }

            if (!EsEdadValida(txtEdad.Text))
            {
                MessageBox.Show("La edad debe ser un número válido y tener menos de 3 cifras.");
                return false;
            }

            if (!EsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("El email debe tener un formato válido.");
                return false;
            }

            if ("" == cmbCarrera.Text)
            {
                MessageBox.Show("Seleccione una carrera");
                return false;
            }

            // Si todas las validaciones pasan, los campos son válidos
            return true;
        }
    }
}
