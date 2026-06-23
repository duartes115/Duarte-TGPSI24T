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

namespace Shion___Ginasio
{
    public partial class Form3 : Form
    {
        private string emailUtilizador;
        private string senhaUtilizador;

        public Form3(string email, string senha)
        {
            InitializeComponent();

            emailUtilizador = email;
            senhaUtilizador = senha;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conect = new SqlConnection(
                @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"DELETE FROM utilizadores
                         WHERE email = @email
                         AND senha = @senha";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@email", emailUtilizador);
                cmd.Parameters.AddWithValue("@senha", senhaUtilizador);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Pedido removido com sucesso.");

                Form1 form1 = new Form1(); 
                form1.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conect.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
