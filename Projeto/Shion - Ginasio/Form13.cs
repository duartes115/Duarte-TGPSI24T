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
    public partial class Form13 : Form
    {
        private int idPersonalSelecionado = 0;
        public Form13()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Cardio");
            comboBox1.Items.Add("Pernas");
            comboBox1.Items.Add("Polia");
            comboBox1.Items.Add("Braços");
            comboBox1.Items.Add("Peito");
            comboBox1.Items.Add("Costas");

            
            LoadTrainers();
        }

        private void LoadTrainers()
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
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
        string.IsNullOrWhiteSpace(textBox2.Text) ||
        string.IsNullOrWhiteSpace(textBox3.Text) ||
        string.IsNullOrWhiteSpace(textBox4.Text) ||
        string.IsNullOrWhiteSpace(textBox5.Text) ||
        comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Preenche todos os campos.");
                return;
            }

            if (!textBox4.Text.All(char.IsDigit))
            {
                MessageBox.Show("Contacto apenas pode ter números.");
                return;
            }

            if (!textBox5.Text.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Email deve terminar em @gmail.com");
                return;
            }

            SqlConnection conect = new SqlConnection(
        @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"INSERT INTO personal_trainers
        (nome, especialidade, experiencia, formacao, contacto, email)
        VALUES (@nome, @esp, @exp, @form, @cont, @mail)";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                cmd.Parameters.AddWithValue("@esp", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@exp", textBox2.Text);
                cmd.Parameters.AddWithValue("@form", textBox3.Text);
                cmd.Parameters.AddWithValue("@cont", textBox4.Text);
                cmd.Parameters.AddWithValue("@mail", textBox5.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Personal adicionado com sucesso!");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                comboBox1.SelectedIndex = -1;

                LoadTrainers();
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (idPersonalSelecionado == 0)
            {
                MessageBox.Show("Seleciona um personal.");
                return;
            }

            SqlConnection conect = new SqlConnection(
        @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"DELETE FROM personal_trainers
                         WHERE idPersonal = @id";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@id", idPersonalSelecionado);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Personal removido.");

                LoadTrainers();
                idPersonalSelecionado = 0;
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

        private void label5_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }
    }
}
