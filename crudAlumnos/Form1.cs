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

            cmbCarreras.Items.Add("Desarrollo De Software");
            cmbCarreras.Items.Add("Analista Medio Ambiente");
            cmbCarreras.Items.Add("Comercio Exterior");
            cmbCarreras.Items.Add("Administracion de Empresas");
            cmbCarreras.Items.Add("Higiene y Seguridad");
            cmbCarreras.Items.Add("Sistemas de Control");
            cmbCarreras.Items.Add("Analista Microeletrónica");
            cmbCarreras.Items.Add("Químico Industrial");
            cmbCarreras.Items.Add("Químico Analista");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInscribir_Click(object sender, EventArgs e)
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
                    cmbCarreras.Text = "";

                    objetoAlumnos.MostrarAlumnos(dgvTotalAlumnos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Revisa los campos antes de la inscripcio, error:" + ex);
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
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";
                txtEmail.Text = "";
                cmbCarreras.Text = "";

                objetoAlumnos.MostrarAlumnos(dgvTotalAlumnos);
            }
        }

        private void dgvTotalAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTotalAlumnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int matricula = (int)Convert.ToInt64(dgvTotalAlumnos.CurrentRow.Cells["matricula"].Value);
            String nombreSeleccionado = dgvTotalAlumnos.CurrentRow.Cells["nombre"].Value.ToString();
            String apellidoSeleccionado = dgvTotalAlumnos.CurrentRow.Cells["apellido"].Value.ToString();
            int edadSeleccionada = (int)Convert.ToInt64(dgvTotalAlumnos.CurrentRow.Cells["edad"].Value);
            String emailSeleccionado = dgvTotalAlumnos.CurrentRow.Cells["email"].Value.ToString();
            String carreraSeleccionado = dgvTotalAlumnos.CurrentRow.Cells["carrera"].Value.ToString();

            txtMatricula.Text = matricula.ToString();
            txtNombre.Text = nombreSeleccionado;
            txtApellido.Text = apellidoSeleccionado;
            txtEdad.Text = edadSeleccionada.ToString();
            txtEmail.Text = emailSeleccionado;
            cmbCarreras.Text = carreraSeleccionado;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int matricula = (int)Convert.ToInt64(txtBusqueda.Text);
                Clases.CAlumnos objetoAlumnos = new Clases.CAlumnos();
                objetoAlumnos.BuscarAlumnosMatricula(matricula);
            

            

        }
    }
}
