using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TPfinalProgramacion1
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\MAXIM\\DESKTOP\\ESCUELA\\PROGRAMACION 1\\WINDOWSFORM1\\TPFINALPROGRAMACION1\\DATABASE1.mdf;Integrated Security=True;";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public class Alumno
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string fechanacimiento { get; set; }
            public int dni { get; set; }
            public string carrera { get; set; }

            public Alumno(string name, string birthdate, string surname, int DNI, string career)
            {
                nombre = name;
                fechanacimiento = birthdate;
                apellido = surname;
                dni = DNI;
                carrera = career;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            string nombre, apellido, carrera;
            int dni;
            try
            {
                dni = Convert.ToInt32(textBox1.Text);
                nombre = textBox2.Text;
                apellido = textBox3.Text;
                carrera = comboBox1.Text;
                DateTime fechanacimiento;


                if (!int.TryParse(textBox1.Text, out dni) || dni <= 0 || (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(carrera)) || !DateTime.TryParse(textBox4.Text, out fechanacimiento))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Realiza las acciones necesarias con las variables
                // ...
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sqlQuery = "INSERT INTO Estudiantes (dni, nombre, apellido, fechanacimiento, carrera) VALUES (@dni, @nombre, @apellido, @fechanacimiento, @carrera)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@dni", dni);
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@apellido", apellido);
                        command.Parameters.AddWithValue("@fechanacimiento", fechanacimiento);
                        command.Parameters.AddWithValue("@carrera", carrera);

                        command.ExecuteNonQuery();

                    }
                }

                MessageBox.Show("Datos guardados correctamente.");
            }
            catch
            {
                MessageBox.Show("Por favor, ingrese un número de DNI válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            button3.Visible = true;
            textBox4.Visible = false;
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            comboBox1.ResetText();

        }
        public static Alumno CreatePerson(string nombre, string fechanacimiento, string apellido, int dni, string carrera)
        {
            return new Alumno(nombre, fechanacimiento, apellido, dni, carrera);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 FormularioCarga = new Form2();
            FormularioCarga.Show();
            FormularioCarga.CargarDatos();
        }

        private void btnAbrirFormularioLogin_Click(object sender, EventArgs e)
        {
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Las credenciales son válidas, habilita el otro botón
                    button2.Enabled = true;
                    MessageBox.Show("Inicio de sesión exitoso");
                    btnAbrirFormularioLogin.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Inicio de sesión fallido");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            textBox4.Visible = true;
            monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            textBox4.Text = selectedDate.ToShortDateString();

            monthCalendar1.Visible = false;
        }
    }
}