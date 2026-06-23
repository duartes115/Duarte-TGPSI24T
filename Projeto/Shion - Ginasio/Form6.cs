using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Shion___Ginasio
{
    public partial class Form6 : Form
    {
        private string emailLogado;

     
        
        public Form6(string email)
        {
            InitializeComponent();
            emailLogado = email;
            textBox1.BackColor = Color.Black;
            textBox1.ForeColor = Color.White;

            textBox2.BackColor = Color.Black;
            textBox2.ForeColor = Color.White;

            textBox3.BackColor = Color.Black;
            textBox3.ForeColor = Color.White;

            textBox4.BackColor = Color.Black;
            textBox4.ForeColor = Color.White;

            textBox5.BackColor = Color.Black;
            textBox5.ForeColor = Color.White;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                label1.Visible = false;
            }
            else
            {
                label1.Visible = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                label2.Visible = false;
            }
            else
            {
                label2.Visible = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                label3.Visible = false;
            }
            else
            {
                label3.Visible = true;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                label4.Visible = false;
            }
            else
            {
                label4.Visible = true;
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                label6.Visible = false;
            }
            else
            {
                label6.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(emailLogado);
            form4.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

       
            private void guna2Button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string senhaAtual = textBox3.Text;
            string novaSenha = textBox4.Text;
            string confirmarNovaSenha = textBox5.Text;

            if (email != emailLogado)
            {
                MessageBox.Show("O email não corresponde à conta atual.");
                return;
            }

            if (novaSenha != confirmarNovaSenha)
            {
                MessageBox.Show("As novas senhas não coincidem.");
                return;
            }

            SqlConnection conect = new SqlConnection(
                @"Server=(localdb)\MSSQLLocalDB;Database=ShionDB;Trusted_Connection=True;");

            try
            {
                conect.Open();

                string verificar = @"SELECT COUNT(*)
                             FROM utilizadores
                             WHERE nome = @nome
                             AND email = @email
                             AND senha = @senha";

                SqlCommand checkCmd = new SqlCommand(verificar, conect);

                checkCmd.Parameters.AddWithValue("@nome", nome);
                checkCmd.Parameters.AddWithValue("@email", email);
                checkCmd.Parameters.AddWithValue("@senha", senhaAtual);

                int existe = (int)checkCmd.ExecuteScalar();

                if (existe == 0)
                {
                    MessageBox.Show("Nome, email ou senha incorretos.");
                    return;
                }

                string atualizar = @"UPDATE utilizadores
                             SET senha = @novaSenha
                             WHERE email = @email";

                SqlCommand updateCmd = new SqlCommand(atualizar, conect);

                updateCmd.Parameters.AddWithValue("@novaSenha", novaSenha);
                updateCmd.Parameters.AddWithValue("@email", email);

                updateCmd.ExecuteNonQuery();

                MessageBox.Show("Senha alterada com sucesso!");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
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
