using System.Windows.Forms;
using System.Diagnostics;

namespace Foodies
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://fastfoodpos.000webhostapp.com/");
        }

        private void label9_Click(object sender, System.EventArgs e)
        {

        }
    }
}