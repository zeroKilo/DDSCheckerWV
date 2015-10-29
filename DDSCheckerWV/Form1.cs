using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDSCheckerWV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Filter = "*.dds|*.dds";
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                rtb1.Text = new DDSWV(d.FileName).ToString();
            }
        }

        private void visitMSDNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://msdn.microsoft.com/en-us/library/windows/desktop/bb943982(v=vs.85).aspx");
        }
    }
}
