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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            // Переход на другую форму
            Form3 f2 = new Form3();
            f2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Переход на другую форму
            Form4 f3 = new Form4();
            f3.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bdDataSet1.life". При необходимости она может быть перемещена или удалена.
            this.lifeTableAdapter.Fill(this.bdDataSet1.life);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bdDataSet1.games". При необходимости она может быть перемещена или удалена.
            this.gamesTableAdapter.Fill(this.bdDataSet1.games);

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ip521-14\source\repos\var20pr8\var20pr8\bd.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM games", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable; // Обновление источника данных
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ip521-14\source\repos\var20pr8\var20pr8\bd.mdf;Integrated Security=True;Connect Timeout=30"))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM life", connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable; // Обновление источника данных
            }
        }
    }
}
