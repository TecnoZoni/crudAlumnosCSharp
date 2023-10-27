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
                Clases.CValidaciones validarTxts = new Clases.CValidaciones();
                if (validarTxts.ValidarCampos(txtMatricula, txtNombre, txtApellido, txtEdad, txtEmail, cmbCarreras))
                {
                    try
                    {
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
                        MessageBox.Show("Revisa los campos antes de la inscripcio, error:" + ex);
                    }
                }
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {

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
            int matriculaSeleccionada = (int)Convert.ToInt64(dgvTotalAlumnos.CurrentRow.Cells["matricula"].Value);



            Clases.CValidaciones validarTxts = new Clases.CValidaciones();
            if (validarTxts.ValidarCampos(txtMatricula, txtNombre, txtApellido, txtEdad, txtEmail, cmbCarreras))
            {
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
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();

            objetoAlumnos.MostrarAlumnos(dgvTotalAlumnos);

            txtBusqueda.Text = "";
            cmbCarrerasB.SelectedIndex = 0;
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();

            string nombre = txtBusqueda.Text;
            string carreraAbuscar = cmbCarrerasB.Text;

            objetoAlumnos.BuscarAlumnos(nombre, carreraAbuscar, dgvTotalAlumnos);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
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

        private void cmbCarrerasB_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();

            string carreraAbuscar = cmbCarrerasB.Text;

            if (carreraAbuscar == "TODAS")
            {
                objetoAlumnos.MostrarAlumnos(dgvTotalAlumnos);
            }
            else
            {
                objetoAlumnos.BuscarAlumnoCarrera(carreraAbuscar, dgvTotalAlumnos);
            }*/
        }


    }
}
