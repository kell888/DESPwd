using System;
using System.Windows.Forms;

namespace DESPwd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox9.Text = DESUtil.Encoder(textBox8.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox11.Text = DESUtil.Decoder(textBox9.Text);
        }
    }
}
