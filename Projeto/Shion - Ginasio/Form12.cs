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
    public partial class Form12 : Form
    {
        private int idUtilizadorSelecionado = 0;
        public Form12()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = guna2ComboBox1.SelectedItem.ToString();

            idUtilizadorSelecionado =
                int.Parse(item.Split('-')[0].Trim());

            SqlConnection conect = new SqlConnection(
                @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"
        SELECT nome, email
        FROM utilizadores
        WHERE id = @id";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@id", idUtilizadorSelecionado);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    label2.Text = reader["nome"].ToString();
                    label7.Text = reader["email"].ToString();
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

        private void Form12_Load(object sender, EventArgs e)
        {
            SqlConnection conect = new SqlConnection(
@"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"
SELECT u.id, u.nome
FROM utilizadores u
INNER JOIN pedidos p
    ON u.id = p.idUtilizador
WHERE p.estado = 'Negado'";

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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SqlConnection conect = new SqlConnection(
        @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"
        UPDATE pedidos
        SET estado = 'Aceite'
        WHERE idUtilizador = @id";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@id", idUtilizadorSelecionado);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Pedido aceite com sucesso.");

                label2.Text = "";
                label7.Text = "";

                Form12_Load(null, null);
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection conect = new SqlConnection(
        @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string apagarPedido = @"
        DELETE FROM pedidos
        WHERE idUtilizador = @id";

                SqlCommand cmd1 = new SqlCommand(apagarPedido, conect);

                cmd1.Parameters.AddWithValue("@id", idUtilizadorSelecionado);

                cmd1.ExecuteNonQuery();

                string apagarUtilizador = @"
        DELETE FROM utilizadores
        WHERE id = @id";

                SqlCommand cmd2 = new SqlCommand(apagarUtilizador, conect);

                cmd2.Parameters.AddWithValue("@id", idUtilizadorSelecionado);

                cmd2.ExecuteNonQuery();

                MessageBox.Show("Conta rejeitada e removida.");

                label2.Text = "";
                label7.Text = "";

                Form12_Load(null, null);
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
