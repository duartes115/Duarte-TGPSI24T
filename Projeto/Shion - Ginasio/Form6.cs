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

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
