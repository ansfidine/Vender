using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vender
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        public static void GoToSite(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void About_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminForm admin = new AdminForm();
            admin.Show();
            this.Hide();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            GoToSite("https://www.facebook.com/ansfidine/");
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            GoToSite("https://twitter.com/ansfidine");
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            GoToSite("https://www.linkedin.com/in/youssouf-ansfidine-b585b014a/");
        }
    }
}
