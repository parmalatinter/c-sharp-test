using System;
using System.Windows.Forms;

namespace ConsoleApp.form
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form(string text)
        {
            InitializeComponent();
            textBox.Text = text;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = Properties.Resources.image;
        }

        private void button_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;

            MessageBox.Show(text);

        }
    }
}
