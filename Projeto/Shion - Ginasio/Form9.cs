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
    public partial class Form9 : Form
    {
        private int idEquipamentoSelecionado = 0;
        public Form9()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string tipo = comboBox1.Text;

            SqlConnection conect = new SqlConnection(
                @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"INSERT INTO equipamentos (nome, tipo)
                         VALUES (@nome, @tipo)";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@tipo", tipo);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Máquina criada com sucesso!");

                textBox1.Clear();

                CarregarEquipamentos();
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
            string item = guna2ComboBox1.SelectedItem.ToString();

            idEquipamentoSelecionado =
                int.Parse(item.Split('-')[0].Trim());
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

        private void label1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Clear();

            comboBox1.Items.Add("Cardio");
            comboBox1.Items.Add("Pernas");
            comboBox1.Items.Add("Polia");
            comboBox1.Items.Add("Braços");
            comboBox1.Items.Add("Peito");
            comboBox1.Items.Add("Costas");

            CarregarEquipamentos();
        
    }
        private void CarregarEquipamentos()
        {
            SqlConnection conect = new SqlConnection(
                @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = "SELECT id, nome FROM equipamentos";

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
            
            if (idEquipamentoSelecionado == 0)
            {
                MessageBox.Show("Selecione uma máquina.");
                return;
            }

            SqlConnection conect = new SqlConnection(
                @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string query = @"DELETE FROM equipamentos
                         WHERE id = @id";

                SqlCommand cmd = new SqlCommand(query, conect);

                cmd.Parameters.AddWithValue("@id", idEquipamentoSelecionado);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Máquina removida com sucesso!");

                idEquipamentoSelecionado = 0;

                CarregarEquipamentos();
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

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string item = guna2ComboBox1.SelectedItem.ToString();

            idEquipamentoSelecionado =
                int.Parse(item.Split('-')[0].Trim());
        }
    }
}
