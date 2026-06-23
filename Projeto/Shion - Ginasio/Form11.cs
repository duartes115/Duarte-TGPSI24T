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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;

            checkBox1.Checked = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string senha = textBox2.Text;

           
            if (email == "admin@gmail.com" && senha == "admin")
            {
                Form7 form7 = new Form7();
                form7.Show();
                this.Hide();
                return;
            }

            SqlConnection conect = new SqlConnection(
                @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"SELECT estado
                     FROM utilizadores
                     WHERE email = @email
                     AND senha = @senha";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);

                object resultado = cmd.ExecuteScalar();

                if (resultado == null)
                {
                    MessageBox.Show("Email ou senha incorretos.");
                    return;
                }

                string estado = resultado.ToString();

                if (estado == "Negado")
                {
                    MessageBox.Show("A sua conta ainda não foi aprovada.");

                    Form4 form4 = new Form4(email);

                    form4.Show();
                    this.Hide();
                }
                else if (estado == "Aceite")
                {
                    MessageBox.Show("Login efetuado com sucesso!");

                    Form4 form4 = new Form4(email);
                    
                    form4.Show();
                    this.Hide();
                }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
