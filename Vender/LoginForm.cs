using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vender
{
    public partial class Login : Form
    {
        DBConnect dBCon = new DBConnect();
        public Login()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(AdminPage);
            bunifuFormDock1.SubscribeControlToDragEvents(SellersPage);     
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            TextBoxadminUPassword.Clear();
            TextBoxadminUsername.Clear();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.Clear();
            bunifuTextBox2.Clear();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (TextBoxadminUsername.Text.Equals("") && TextBoxadminUPassword.Text.Equals(""))
            {
                LabelErrorAdmin.Text = ("Enter username and password");
            }
            else if (TextBoxadminUsername.Text == "")
            {
                LabelErrorAdmin.Text = ("Enter username");
            }
            else if (TextBoxadminUPassword.Text == "")
            {
                LabelErrorAdmin.Text = ("Enter password");
            }
            
                else
            {
                SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM admin WHERE username='" + TextBoxadminUsername.Text + "' AND password='" + TextBoxadminUPassword.Text + "'", dBCon.GetCon());
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    AdminForm form = new AdminForm();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    LabelErrorAdmin.Text = ("Incorrect username or password ");
                }
            }
        }

        private void TextBoxadminUsername_MouseClick(object sender, MouseEventArgs e)
        {
            LabelErrorAdmin.Text = "";
        }

        private void TextBoxadminUPassword_Click(object sender, EventArgs e)
        {
            LabelErrorAdmin.Text = "";
        }
    }
}
