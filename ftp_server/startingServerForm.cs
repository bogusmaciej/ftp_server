using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ftp_server
{
    public partial class startingServerForm : Form
    {
        public startingServerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            serverForm server1 = new serverForm();
            server1.ShowDialog();
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void message_Click(object sender, EventArgs e)
        {

        }
    }
}
