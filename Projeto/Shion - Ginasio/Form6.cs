using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form6()
        {

            InitializeComponent();
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
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
