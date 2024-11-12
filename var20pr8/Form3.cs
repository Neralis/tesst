using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace var20pr8
{
    public partial class Form3 : Form
    {
        int Points = 0;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем массив RadioButton
            RadioButton[] radioButtons = new RadioButton[]
            {
                 otvet1, otvet2, otvet3, otvet4, otvet5, otvet6
            };

            // Пример: проверяем, какие RadioButton выбраны и выполняем действие
            for (int i = 0; i < radioButtons.Length; i++)
            {
                if (radioButtons[i].Checked)
                {
                    Points++;
                }
            }

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                // Строка подключения к вашей базе данных
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ip521-14\source\repos\var20pr8\var20pr8\bd.mdf;Integrated Security=True;Connect Timeout=30";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Открываем соединение
                        connection.Open();

                        // SQL-запрос для вставки данных
                        string query = "INSERT INTO games (FIO, [Group], Points) VALUES (@Value1, @Value2, @Value3)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Добавляем параметры к запросу
                            command.Parameters.AddWithValue("@Value1", textBox2.Text);
                            command.Parameters.AddWithValue("@Value2", textBox1.Text);
                            command.Parameters.AddWithValue("@Value3", Points);

                            // Выполняем запрос
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Данные успешно записаны в базу данных.");

                        // Переход на другую форму
                        Form2 f2 = new Form2();
                        f2.Show();
                        this.Hide();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
                    }
                }
            }
        }
    }
}
