using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp.form
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form(string text)
        {
            InitializeComponent();
            textBox.Text = text;
        }

        private void button_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;

            MessageBox.Show(text);

        }
    }
}
