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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true; 

            checkBox1.Checked = false; 

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

                string nome = textBox2.Text;
                string email = textBox1.Text;
                string senha = textBox3.Text;
            if (email.ToLower() == "admin@gmail.com")
            {
                MessageBox.Show("Este email já foi utilizado.");
                return;
            }
            
            if (!email.EndsWith("@gmail.com"))
                {
                    MessageBox.Show("O email deve terminar em @gmail.com");
                    return;
                }

                SqlConnection conect = new SqlConnection(
                    @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

                try
                {
                    conect.Open();

                    
                    string verificar = "SELECT COUNT(*) FROM utilizadores WHERE email = @email";

                    SqlCommand checkCmd = new SqlCommand(verificar, conect);
                    checkCmd.Parameters.AddWithValue("@email", email);

                    int existe = (int)checkCmd.ExecuteScalar();

                    if (existe > 0)
                    {
                        MessageBox.Show("Este email já está registado.");
                        return;
                    }

                    
                    string query = @"INSERT INTO utilizadores (nome, email, senha)
                         VALUES (@nome, @email, @senha)";

                    SqlCommand cmd = new SqlCommand(query, conect);

                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    cmd.ExecuteNonQuery();

                    
                    string sqlEstado = "SELECT estado FROM utilizadores WHERE email = @email";

                    SqlCommand estadoCmd = new SqlCommand(sqlEstado, conect);
                    estadoCmd.Parameters.AddWithValue("@email", email);

                    string estado = estadoCmd.ExecuteScalar().ToString();

                    MessageBox.Show("Conta criada com sucesso!");

                    if (estado == "Negado")
                    {
                    Form3 form3 = new Form3(email, senha);
                    form3.Show();
                    this.Hide();
                    }
                    

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
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
            textBox3.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
