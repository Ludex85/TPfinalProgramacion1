using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Data.SQLite;
using static TPfinalProgramacion1.Form1;
using TPfinalProgramacion1;

namespace TPfinalProgramacion1
{
    public partial class Form2 : Form
    {
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public Form2()
        {
            InitializeComponent();
        }
        // Declaración de variable de cadena para la cadena de conexión
        string connectionString = "Data Source=|DataDirectory|DATABASE58.db;Version=3;";

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private DataTable ObtenerDatosDeBaseDeDatos()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Estudiantes";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // Crea un BindingSource
        private BindingSource miBindingSource = new BindingSource();

        public void CargarDatos()
        {
            dataGridView1.AutoGenerateColumns = true;
            miBindingSource.DataSource = ObtenerDatosDeBaseDeDatos();
            dataGridView1.DataSource = miBindingSource;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AplicarFiltro();
                e.Handled = true; // Evita que se procese la tecla "Enter" en el TextBox
            }
        }
        public void AplicarFiltro()
        {
            string filtro = textBox4.Text.Trim();
            // Obtener la fuente de datos original (por ejemplo, un DataTable)
            DataTable dt = (DataTable)miBindingSource.DataSource;

            // Si el filtro está en blanco, restaurar los datos originales
            if (string.IsNullOrWhiteSpace(filtro))
            {
                dataGridView1.DataSource = dt;
                return;
            }

            // Validar si el filtro es un número válido
            if (int.TryParse(filtro, out int valorFiltro))
            {
                // Aplicar el filtro utilizando LINQ a la columna numérica
                var resultados = from row in dt.AsEnumerable()
                                 let cellValue = row.Field<object>("dni")
                                 where cellValue != null && int.TryParse(cellValue.ToString(), out int valorColumna) && valorColumna == valorFiltro
                                 select row;

                // Verificar si hay resultados antes de asignar al DataGridView
                if (resultados.Any())
                {
                    dataGridView1.DataSource = resultados.CopyToDataTable();
                }
                else
                {
                    // Mostrar un mensaje de que no se encontraron resultados
                    MessageBox.Show("No se encontraron resultados que coincidan con el filtro.");
                }
            }
            else
            {
                // Mostrar un mensaje de error si el valor del filtro no es un número válido
                MessageBox.Show("Ingrese un número válido en el filtro.");
            }
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AplicarFiltro2();
                e.Handled = true; // Evita que se procese la tecla "Enter" en el TextBox
            }
        }

        private void AplicarFiltro2()
        {
            string filtro = textBox1.Text;

            // Obtener la fuente de datos original (por ejemplo, un DataTable)
            DataTable dt = (DataTable)miBindingSource.DataSource;

            // Crear una expresión de consulta para buscar filas que cumplan con la condición
            string filtroExpression = $"nombre LIKE '%{filtro}%'";

            // Aplicar el filtro utilizando la función Select del DefaultView del DataTable
            dt.DefaultView.RowFilter = filtroExpression;

            // Verificar si hay resultados antes de asignar al DataGridView
            if (dt.DefaultView.Count > 0)
            {
                dataGridView1.DataSource = dt.DefaultView.ToTable();
            }
            else
            {
                // Mostrar un mensaje si no se encontraron resultados
                MessageBox.Show("No se encontraron resultados que coincidan con el filtro.");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AplicarFiltro3();
                e.Handled = true; // Evita que se procese la tecla "Enter" en el TextBox
            }
        }
        private void AplicarFiltro3()
        {
            string filtro = textBox3.Text;

            // Obtener la fuente de datos original (por ejemplo, un DataTable)
            DataTable dt = (DataTable)miBindingSource.DataSource;

            // Crear una expresión de consulta para buscar filas que cumplan con la condición
            string filtroExpression = $"apellido LIKE '%{filtro}%'";

            // Aplicar el filtro utilizando la función Select del DefaultView del DataTable
            dt.DefaultView.RowFilter = filtroExpression;

            // Verificar si hay resultados antes de asignar al DataGridView
            if (dt.DefaultView.Count > 0)
            {
                dataGridView1.DataSource = dt.DefaultView.ToTable();
            }
            else
            {
                // Mostrar un mensaje si no se encontraron resultados
                MessageBox.Show("No se encontraron resultados que coincidan con el filtro.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas borrar esta línea de la base de datos?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Obtener el índice de la fila seleccionada
                    int rowIndex = dataGridView1.SelectedRows[0].Index;

                    // Obtener el valor de la clave primaria (supongamos que es una columna llamada "dni")
                    int dni;
                    int.TryParse(dataGridView1.Rows[rowIndex].Cells["dni"].Value.ToString(), out dni);

                    // Eliminar la fila del DataGridView
                    dataGridView1.Rows.RemoveAt(rowIndex);

                    // Actualizar la base de datos eliminando la fila correspondiente
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Estudiantes WHERE dni = @dni", connection))
                        {
                            command.Parameters.AddWithValue("@dni", dni);
                            command.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Eliminación guardada correctamente.");

                }
            }
            else
            {
                return;
            }
        }
        HashSet<string> carrerasPermitidas = new HashSet<string>
{
    "Desarrollo de Software",
    "Analista en Medio Ambiente",
    "Comercio Exterior",
    "Comercialización y Administración de Empresas",
    "Higiene y Seguridad en el Trabajo",
    "Microelectrónica",
    "Químico Superior Industrial",
    "Químico Superior Analista",
    "Sistema de Control"
};


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas modificar los datos?", "Confirmar modificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Obtener la fuente de datos original (por ejemplo, un DataTable)
                DataTable dt = (DataTable)miBindingSource.DataSource;

                // Obtener los cambios pendientes en el DataTable
                DataTable changes = dt.GetChanges();

                if (changes != null)
                {
                    // Realizar las verificaciones necesarias en los datos modificados antes de guardarlos en la base de datos
                    foreach (DataRow row in changes.Rows)
                    {
                        // Verificar que la columna "nombre" no contenga números
                        if (row["nombre"] != DBNull.Value && row["nombre"].ToString().Any(char.IsDigit))
                        {
                            MessageBox.Show("El campo 'nombre' no debe contener números.");
                            return; // Cancelar la actualización
                        }

                        // Verificar que la columna "apellido" no contenga números
                        if (row["apellido"] != DBNull.Value && row["apellido"].ToString().Any(char.IsDigit))
                        {
                            MessageBox.Show("El campo 'apellido' no debe contener números.");
                            return; // Cancelar la actualización
                        }

                        // Verificar que la columna "carrera" sea uno de los valores permitidos
                        if (row["carrera"] != DBNull.Value)
                        {
                            string carrera = row["carrera"].ToString();

                            if (!carrerasPermitidas.Contains(carrera))
                            {
                                MessageBox.Show("El campo 'carrera' debe ser uno de los valores permitidos.");
                                return; // Cancelar la actualización
                            }
                        }

                        // Verificar que el campo "dni" sea un número válido
                        if (row["dni"] != DBNull.Value)
                        {
                            if (!long.TryParse(row["dni"].ToString(), out long dni))
                            {
                                MessageBox.Show("El campo 'dni' debe ser un número válido.");
                                return; // Cancelar la actualización
                            }

                            // Verificar duplicidad en el campo "dni"
                            if (dt.AsEnumerable().Count(r => r.Field<long>("dni") == dni) > 1)
                            {
                                MessageBox.Show("El campo 'dni' ya existe en la base de datos.");
                                return; // Cancelar la actualización
                            }
                        }


                        // Verificar que la columna "fechanacimiento" sea de tipo Date y esté dentro del rango permitido
                        if (row["fechanacimiento"] != DBNull.Value)
                        {
                            if (!DateTime.TryParse(row["fechanacimiento"].ToString(), out DateTime fechaNacimiento))
                            {
                                MessageBox.Show("El campo 'fechanacimiento' debe ser una fecha válida.");
                                return; // Cancelar la actualización
                            }

                            DateTime fechalimite = new DateTime(2005, 12, 31);
                            DateTime fechamaxima = new DateTime(1982, 12, 31);

                            if (fechaNacimiento > fechalimite || fechaNacimiento < fechamaxima)
                            {
                                MessageBox.Show("El campo 'fechanacimiento' debe estar entre " + fechamaxima.ToString("dd/MM/yyyy") + " y " + fechalimite.ToString("dd/MM/yyyy") + ".");
                                return; // Cancelar la actualización
                            }
                        }
                    }

                    try
                    {
                        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                        {
                            connection.Open();

                            // Crear un adaptador de datos (SQLiteDataAdapter)
                            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM Estudiantes", connection))
                            using (SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter))
                            {
                                // Actualizar la base de datos con las modificaciones
                                adapter.Update(changes);
                                // Aceptar los cambios en el DataTable
                                dt.AcceptChanges();
                                MessageBox.Show("Modificaciones guardadas correctamente.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar las modificaciones: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No hay modificaciones para guardar.");
                }
            }
            else
            {
                return;
            }
        }

        private void ExportarAExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Hoja1");

                // Agrega los encabezados de columna
                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    worksheet.Cell(1, col + 1).Value = dataGridView1.Columns[col].HeaderText;
                }

                // Recorre las filas y columnas para agregar los datos
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        object cellValue = dataGridView1.Rows[row].Cells[col].Value;

                        if (cellValue != null)
                        {
                            if (dataGridView1.Columns[col].Name == "dni") // Cambia "NombreColumnaInt" al nombre real de la columna de tipo int
                            {
                                // Conversión para la columna de tipo int
                                int valorInt;
                                if (int.TryParse(cellValue.ToString(), out valorInt))
                                {
                                    worksheet.Cell(row + 2, col + 1).Value = valorInt;
                                }
                                else
                                {
                                    // Manejar el caso en el que el valor no es un número entero válido
                                    worksheet.Cell(row + 2, col + 1).Value = "Valor no válido";
                                }
                            }
                            else if (dataGridView1.Columns[col].Name == "fechanacimiento") // Cambia "NombreColumnaDate" al nombre real de la columna de tipo DateTime
                            {
                                // Conversión para la columna de tipo DateTime
                                DateTime valorDate;
                                if (DateTime.TryParse(cellValue.ToString(), out valorDate))
                                {
                                    worksheet.Cell(row + 2, col + 1).Value = valorDate;
                                }
                                else
                                {
                                    // Manejar el caso en el que el valor no es una fecha válida
                                    worksheet.Cell(row + 2, col + 1).Value = "Fecha no válida";
                                }
                            }
                            else
                            {
                                // Para las columnas de tipo string, simplemente obtén el valor como cadena
                                worksheet.Cell(row + 2, col + 1).Value = cellValue.ToString();
                            }
                        }
                        else
                        {
                            // Manejar el caso en el que la celda es null
                            worksheet.Cell(row + 2, col + 1).Value = "Celda vacía";
                        }
                    }
                }

                // Guarda el archivo Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = "DatosExportados.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Exportación exitosa.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ExportarAExcel();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener la fuente de datos original (por ejemplo, un DataTable)
            DataTable dt = (DataTable)miBindingSource.DataSource;
            // Obtén el valor seleccionado en el ComboBox.
            string selectedValue = comboBox1.SelectedItem as string;

            // Verifica si se ha seleccionado un valor válido.
            if (!string.IsNullOrEmpty(selectedValue))
            {
                string filtro = selectedValue; // Usar el valor seleccionado, no el índice

                // Crear una expresión de consulta insensible a mayúsculas/minúsculas
                string filtroExpression = $"carrera = '{filtro}'";

                // Aplicar el filtro al origen de datos del DataGridView
                (miBindingSource.DataSource as DataTable).DefaultView.RowFilter = filtroExpression;

            }
            if (selectedValue != null && selectedValue.Equals("Todas", StringComparison.OrdinalIgnoreCase))
            {
                // Si no se ha seleccionado un valor válido, muestra todos los datos originales
                (miBindingSource.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            }
            // Verificar si hay resultados antes de asignar al DataGridView
            if (dt.DefaultView.Count > 0)
            {
                dataGridView1.DataSource = dt.DefaultView.ToTable();
            }
            else
            {
                // También puedes restablecer la selección a "Todas" si es necesario.
                comboBox1.SelectedIndex = 0;
                // Mostrar un mensaje si no se encontraron resultados
                MessageBox.Show("No se encontraron resultados que coincidan con el filtro.");
            }
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

    }
}
