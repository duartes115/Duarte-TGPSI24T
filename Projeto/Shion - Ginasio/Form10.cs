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
    public partial class Form10 : Form
    {
        private string emailLogado;
        public Form10(string email)
        {
            InitializeComponent();
            emailLogado = email;

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(emailLogado);
            form4.Show();
            this.Hide();
        }
    }
}
