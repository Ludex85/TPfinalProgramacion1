using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;


namespace TPfinalProgramacion1
{

    public partial class Form1 : Form
    {

        private void Form1_Load(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Application.StartupPath);

        }

        string connectionString = "Data Source=|DataDirectory|DATABASE58.db;Version=3;";

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

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre, apellido, carrera;
            int dni;
            nombre = textBox2.Text;
            apellido = textBox3.Text;
            carrera = comboBox1.Text;
            DateTime fechanacimiento;
            DateTime fechalimite = new DateTime(2005, 12, 31);
            DateTime fechamaxima = new DateTime(1982, 12, 31);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Verifica si el DNI ya existe en la tabla de estudiantes.
                string query = "SELECT COUNT(*) FROM Estudiantes WHERE dni = @dni";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@dni", int.TryParse(textBox1.Text, out dni));
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0 || !int.TryParse(textBox1.Text, out dni) || dni <= 0 ||
                        string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                        string.IsNullOrWhiteSpace(carrera) || comboBox1.SelectedIndex < 0 ||
                        !DateTime.TryParse(textBox4.Text, out fechanacimiento) || (fechanacimiento > fechalimite || fechanacimiento < fechamaxima))
                    {
                        MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Realiza las acciones necesarias con las variables
                string sqlQuery = "INSERT INTO Estudiantes (dni, nombre, apellido, fechanacimiento, carrera) VALUES (@dni, @nombre, @apellido, @fechanacimiento, @carrera)";
                using (SQLiteCommand command = new SQLiteCommand(sqlQuery, connection))
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
            button3.Visible = true;
            textBox4.Visible = false;
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            comboBox1.ResetText();
        }

        private Form2 FormularioCarga;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual (Form1)
            FormularioCarga = new Form2();
            FormularioCarga.FormClosed += (s, args) =>
            {
                this.Show(); // Muestra el formulario actual cuando Form2 se cierra
            };
            FormularioCarga.Show();
            FormularioCarga.CargarDatos();
        }


        private void btnAbrirFormularioLogin_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual (Form1)
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Las credenciales son válidas, habilita el otro botón
                    button2.Enabled = true;
                    this.Show(); // Muestra el formulario actual cuando Form3 se cierra
                    MessageBox.Show("Inicio de sesión exitoso");
                    btnAbrirFormularioLogin.Enabled = false;
                }
                else
                {
                    this.Show(); // Muestra el formulario actual cuando Form3 se cierra
                    MessageBox.Show("Inicio de sesión fallido");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = comboBox1.SelectedItem as string;

            // Calcular el ancho máximo de los elementos
            int maxWidth = 0;
            foreach (var item in comboBox1.SelectedItem as string)
            {
                int itemWidth = TextRenderer.MeasureText(selectedValue.ToString(), comboBox1.Font).Width;
                if (itemWidth > maxWidth)
                {
                    maxWidth = itemWidth;
                }
            }

            // Establecer el ancho de la ComboBox al ancho máximo encontrado
            comboBox1.Width = maxWidth + 18;
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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}