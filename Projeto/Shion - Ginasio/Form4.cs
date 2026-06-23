using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Shion___Ginasio
{
    public partial class Form4 : Form
    {
        private string emailLogado;

        public Form4(string email)
        {
            InitializeComponent();
            emailLogado = email;

            label5.MouseEnter += label5_MouseEnter;
            label5.MouseLeave += label5_MouseLeave;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(emailLogado);
            form5.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10(emailLogado);
               form10.Show();
            this.Hide();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.FromArgb(255, 128, 0);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(emailLogado); 
            form6.Show();
            this.Hide();
        }
    }
}
