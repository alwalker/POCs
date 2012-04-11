using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsTestMessageBoxIcons
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Asterisk", "test", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            MessageBox.Show("Error", "test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("Exclamation", "test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show("Hand", "test", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            MessageBox.Show("Information", "test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("None", "test", MessageBoxButtons.OK, MessageBoxIcon.None);
            MessageBox.Show("Question", "test", MessageBoxButtons.OK, MessageBoxIcon.Question);
            MessageBox.Show("Stop", "test", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            MessageBox.Show("Warning", "test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
