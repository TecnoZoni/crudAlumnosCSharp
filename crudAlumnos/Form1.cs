using Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;


namespace crudAlumnos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();
            objetoAlumnos.MostrarAlumnos(dgvTotalAlumnos);

            //Estas son las carreras del comboBox del formulario 
            cmbCarreras.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCarreras.Items.Add("Desarrollo De Software");
            cmbCarreras.Items.Add("Analista Medio Ambiente");
            cmbCarreras.Items.Add("Comercio Exterior");
            cmbCarreras.Items.Add("Administracion de Empresas");
            cmbCarreras.Items.Add("Higiene y Seguridad");
            cmbCarreras.Items.Add("Sistemas de Control");
            cmbCarreras.Items.Add("Analista Microeletrónica");
            cmbCarreras.Items.Add("Químico Industrial");
            cmbCarreras.Items.Add("Químico Analista");
            cmbCarreras.SelectedIndex = 0;

            //Estas son las carreras del comboBox de busqueda
            cmbCarrerasB.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCarrerasB.Items.Add("TODAS");
            cmbCarrerasB.Items.Add("Desarrollo De Software");
            cmbCarrerasB.Items.Add("Analista Medio Ambiente");
            cmbCarrerasB.Items.Add("Comercio Exterior");
            cmbCarrerasB.Items.Add("Administracion de Empresas");
            cmbCarrerasB.Items.Add("Higiene y Seguridad");
            cmbCarrerasB.Items.Add("Sistemas de Control");
            cmbCarrerasB.Items.Add("Analista Microeletrónica");
            cmbCarrerasB.Items.Add("Químico Industrial");
            cmbCarrerasB.Items.Add("Químico Analista");
            cmbCarrerasB.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            //Verifico las celdas de la matricula para ver si ya esta registrado el numero de matricula del alumno
            //para no reinscribirlo.             
            bool estaDuplicado = false;

            for (int i = 0; i < dgvTotalAlumnos.Rows.Count; i++)
            {
                DataGridViewCell cell = dgvTotalAlumnos.Rows[i].Cells["matricula"];

                if (cell != null && cell.Value != null)
                {
                    string matriculaGuardada = cell.Value.ToString();
                    string matriculaNueva = txtMatricula.Text;

                    if (matriculaGuardada == matriculaNueva)
                    {
                        estaDuplicado = true;
                        break;
                    }
                }
            }

            if (estaDuplicado)
            {
                MessageBox.Show("No se puede inscribir a un alumno con el mismo numero de matricula.");
            }
            else
            {
                //Una vez se halla verificado que el alumno no esta registrado se procede con las verificaciones
                //enviando los datos del formulario a la clase de validaciones.
                Clases.CValidaciones validarTxts = new Clases.CValidaciones();
                if (validarTxts.ValidarCampos(txtMatricula, txtNombre, txtApellido, txtEdad, txtEmail, cmbCarreras))
                {
                    try
                    {
                        //si los campos fueron validos se envian a la funcion inscribirALumnos , se reestablce el form y se
                        //recarga la tabla
                        int matricula = (int)Convert.ToInt64(txtMatricula.Text);
                        String nombre = txtNombre.Text;
                        String apellido = txtApellido.Text;
                        int edad = Convert.ToInt32(txtEdad.Text);
                        String email = txtEmail.Text;
                        String carrera = cmbCarreras.Text;


                        Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();
                        objetoAlumnos.InscribirAlumnos(matricula, nombre, apellido, edad, email, carrera);

                        txtMatricula.Text = "";
                        txtNombre.Text = "";
                        txtApellido.Text = "";
                        txtEdad.Text = "";
                        txtEmail.Text = "";
                        cmbCarreras.SelectedIndex = 0;

                        objetoAlumnos.MostrarAlumnos(dgvTotalAlumnos);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Revisa los campos antes de la inscripcion, error: " + ex);
                    }
                }
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            //Selecciono la matricula, el nombre y el apellido del alumno que se este seleccionado en la tabla (por defeco el primero)
            //mando un mensaje de verificacioncion para la eliminacion, si es correcta ejecuto la funcion BajarAlumnos.
            int matricula = (int)Convert.ToInt64(dgvTotalAlumnos.CurrentRow.Cells["matricula"].Value);
            String nombreSeleccionado = dgvTotalAlumnos.CurrentRow.Cells["nombre"].Value.ToString();
            String apellidoSeleccionado = dgvTotalAlumnos.CurrentRow.Cells["apellido"].Value.ToString();

            DialogResult resultado = MessageBox.Show("¿Realmente desea dar de baja al alumno " + nombreSeleccionado + " " + apellidoSeleccionado + "?", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();
                objetoAlumnos.BajarAlumnos(matricula);

                objetoAlumnos.MostrarAlumnos(dgvTotalAlumnos);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Al darle al boton de modificar guardo el valor de la matricula en una variable
            int matriculaSeleccionada = (int)Convert.ToInt64(dgvTotalAlumnos.CurrentRow.Cells["matricula"].Value);


            //Paso los datos por la clase de validaciones para corroborar que todo este bien
            Clases.CValidaciones validarTxts = new Clases.CValidaciones();
            if (validarTxts.ValidarCampos(txtMatricula, txtNombre, txtApellido, txtEdad, txtEmail, cmbCarreras))
            {
                //Si todo esta bien tomo los valores del formulario y las envio a la funcion Modificar alumnos junto a todos
                //los datos, ademas blanqueo el formulario y recargo la tabla.
                String nombre = txtNombre.Text;
                String apellido = txtApellido.Text;
                int edad = Convert.ToInt32(txtEdad.Text);
                String email = txtEmail.Text;
                String carrera = cmbCarreras.Text;

                Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();
                objetoAlumnos.ModificarAlumnos(matriculaSeleccionada, nombre, apellido, edad, email, carrera);

                txtMatricula.Text = "";
                txtMatricula.Enabled = true;
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";
                txtEmail.Text = "";
                cmbCarreras.SelectedIndex = 0;

                objetoAlumnos.MostrarAlumnos(dgvTotalAlumnos);
            }
        }

        private void dgvTotalAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTotalAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Al hacer doble click en algun campo de una fila de la tabla tomo todos sus datos y los envio al form para su edicion
            try
            {
                int matricula = (int)Convert.ToInt64(dgvTotalAlumnos.CurrentRow.Cells["matricula"].Value);
                String nombreSeleccionado = dgvTotalAlumnos.CurrentRow.Cells["nombre"].Value.ToString();
                String apellidoSeleccionado = dgvTotalAlumnos.CurrentRow.Cells["apellido"].Value.ToString();
                int edadSeleccionada = (int)Convert.ToInt64(dgvTotalAlumnos.CurrentRow.Cells["edad"].Value);
                String emailSeleccionado = dgvTotalAlumnos.CurrentRow.Cells["email"].Value.ToString();
                String carreraSeleccionado = dgvTotalAlumnos.CurrentRow.Cells["carrera"].Value.ToString();

                txtMatricula.Text = matricula.ToString();
                txtMatricula.Enabled = false;
                txtNombre.Text = nombreSeleccionado;
                txtApellido.Text = apellidoSeleccionado;
                txtEdad.Text = edadSeleccionada.ToString();
                txtEmail.Text = emailSeleccionado;
                cmbCarreras.Text = carreraSeleccionado;

            }
            catch
            {
                MessageBox.Show("Seleccione un usuario valido.");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Reinicio la tabla y dejo en blanco el texbox el combo box de busqueda
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();

            objetoAlumnos.MostrarAlumnos(dgvTotalAlumnos);

            txtBusqueda.Text = "";
            cmbCarrerasB.SelectedIndex = 0;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            //Tomo el nombre, la carrera seleccionada en el combo box y la tabla para enviarla a la funcion de Buscar
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();

            string nombre = txtBusqueda.Text;
            string carreraAbuscar = cmbCarrerasB.Text;

            objetoAlumnos.BuscarAlumnos(nombre, carreraAbuscar, dgvTotalAlumnos);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Borro el contenido del form y reinicio la tabla para cancelar la edicion.
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();

            txtMatricula.Text = "";
            txtMatricula.Enabled = true;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtEmail.Text = "";
            cmbCarreras.SelectedIndex = 0;
            txtBusqueda.Text = "";

            objetoAlumnos.MostrarAlumnos(dgvTotalAlumnos);
        }



        private void btnEportarExcel_Click(object sender, EventArgs e)
        {
            try
            {

                // Crear un objeto Excel.
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Crear un nuevo libro de trabajo de Excel.
                Workbook workbook = excel.Workbooks.Add(Type.Missing);

                // Crear una nueva hoja de trabajo de Excel.
                Worksheet worksheet = (Worksheet)workbook.ActiveSheet;

                // Establecer el nombre de la hoja de trabajo de Excel.
                worksheet.Name = "Alumnos";

                // Recorrer las filas y columnas del DataGridView y agregarlas a la hoja de trabajo de Excel.
                for (int i = 1; i < dgvTotalAlumnos.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgvTotalAlumnos.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvTotalAlumnos.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvTotalAlumnos.Columns.Count; j++)
                    {
                        if (dgvTotalAlumnos.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 2, j + 1] = dgvTotalAlumnos.Rows[i].Cells[j].Value.ToString();
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = string.Empty;
                        }

                    }
                }

                // Guardar el archivo de Excel y cerrar el objeto Excel.
                workbook.SaveAs(@"C:\Users\Admin\Desktop\Excels de Alumnos\Alumnos.xlsx");
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Se exporto a Excel con exito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo exportar a excel por un error: " + ex.ToString());
            }
        }

    }
}
