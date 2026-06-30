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
    public partial class Form8 : Form
    {
        private int idSelecionado = 0;
        public Form8()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                label3.Visible = false;
            }
            else
            {
                label3.Visible = true;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                label5.Visible = false;
            }
            else
            {
                label5.Visible = true;
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                label4.Visible = false;
            }
            else
            {
                label4.Visible = true;
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            SqlConnection conect = new SqlConnection(
@"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = "SELECT id, nome FROM utilizadores";

                SqlCommand cmd = new SqlCommand(query, conect);

                SqlDataReader reader = cmd.ExecuteReader();

                guna2ComboBox1.Items.Clear();

                while (reader.Read())
                {
                    guna2ComboBox1.Items.Add(
                        reader["id"].ToString() + " - " +
                        reader["nome"].ToString());
                }

                reader.Close();
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem == null)
                return;

            string item = guna2ComboBox1.SelectedItem.ToString();

            idSelecionado = int.Parse(item.Split('-')[0].Trim());
        }
        
        
            
       

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            if (idSelecionado == 0)
            {
                MessageBox.Show("Seleciona um utilizador.");
                return;
            }

            SqlConnection conect = new SqlConnection(
        @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"SELECT nome, email, senha
                         FROM utilizadores
                         WHERE id = @id";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@id", idSelecionado);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["nome"].ToString();
                    textBox2.Text = reader["email"].ToString();
                    textBox3.Text = reader["senha"].ToString();
                }

                reader.Close();
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

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (idSelecionado == 0)
            {
                MessageBox.Show("Seleciona um utilizador.");
                return;
            }

            SqlConnection conect = new SqlConnection(
        @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

              
                string deletePedidos = @"DELETE FROM pedidos WHERE idUtilizador = @id";

                SqlCommand cmd1 = new SqlCommand(deletePedidos, conect);
                cmd1.Parameters.AddWithValue("@id", idSelecionado);
                cmd1.ExecuteNonQuery();

                string deleteUser = @"DELETE FROM utilizadores WHERE id = @id";

                SqlCommand cmd2 = new SqlCommand(deleteUser, conect);
                cmd2.Parameters.AddWithValue("@id", idSelecionado);
                cmd2.ExecuteNonQuery();

                MessageBox.Show("Utilizador removido.");

                guna2ComboBox1.Items.Remove(guna2ComboBox1.SelectedItem);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

                idSelecionado = 0;
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

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            if (idSelecionado == 0)
            {
                MessageBox.Show("Seleciona um utilizador.");
                return;
            }

            SqlConnection conect = new SqlConnection(
        @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"UPDATE utilizadores
                         SET nome = @nome,
                             email = @email,
                             senha = @senha
                         WHERE id = @id";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text);
                cmd.Parameters.AddWithValue("@senha", textBox3.Text);
                cmd.Parameters.AddWithValue("@id", idSelecionado);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Utilizador atualizado.");
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
    }
}
