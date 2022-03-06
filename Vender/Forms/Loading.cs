using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vender.Forms;

namespace Vender
{
    public partial class Loading : Form
    {
        string Text;
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            Text = File.ReadAllText(@"venderRST.vf");
            timer1.Start();
        }
        int startPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 2;
            ProgressBar.Value = startPoint;
            if (ProgressBar.Value == 100)
            {
               if(Text == "0")
                {
                    ProgressBar.Value = 0;
                    timer1.Stop();
                    SignUp signup = new SignUp();
                    signup.Show();
                    this.Hide();
                }
               else
                {
                    ProgressBar.Value = 0;
                    timer1.Stop();
                    Login LoginPage = new Login();
                    this.Hide();
                    LoginPage.Show();
                }
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
