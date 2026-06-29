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
    public partial class Form14 : Form
    {
        private int idPersonalSelecionado = 0;
        private string emailLogado;
        public Form14(string email)
        {
            InitializeComponent();
            emailLogado = email;
            label7.MouseEnter += label7_MouseEnter;
            label7.MouseLeave += label7_MouseLeave;
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            SqlConnection conect = new SqlConnection(
@"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = "SELECT idPersonal, nome FROM personal_trainers";

                SqlCommand cmd = new SqlCommand(query, conect);

                SqlDataReader reader = cmd.ExecuteReader();

                guna2ComboBox1.Items.Clear();

                while (reader.Read())
                {
                    guna2ComboBox1.Items.Add(
                        reader["idPersonal"].ToString() + " - " +
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

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem == null)
                return;

            string item = guna2ComboBox1.SelectedItem.ToString();

            idPersonalSelecionado =
                int.Parse(item.Split('-')[0].Trim());

            SqlConnection conect = new SqlConnection(
        @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"SELECT nome,
                                especialidade,
                                experiencia,
                                formacao,
                                contacto,
                                email
                         FROM personal_trainers
                         WHERE idPersonal = @id";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@id", idPersonalSelecionado);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    label1.Text = reader["nome"].ToString();
                    label2.Text = reader["especialidade"].ToString();
                    label3.Text = reader["experiencia"].ToString();
                    label4.Text = reader["formacao"].ToString();
                    label5.Text = reader["contacto"].ToString();
                    label6.Text = reader["email"].ToString();
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
        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(emailLogado);
            form4.Show();
            this.Hide();
        }
    }
}
