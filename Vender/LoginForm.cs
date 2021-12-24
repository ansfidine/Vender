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
        public string sellerName;
        DBConnect dBCon = new DBConnect();

        //
        //AdminLogin function
        //
        private void AdminLogin()
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


                Admin administrator = new Admin(TextBoxadminUsername.Text, TextBoxadminUPassword.Text,"admin","username","password");
                administrator.Login();
                if (administrator.GetState() == "success")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                    this.Hide();
                }
                else
                {
                    LabelErrorAdmin.Text = ("Incorrect username or password ");
                }

            }

            
        }
        //
        //SellerLogin function 
        //
        private void SellerLogin()
        {
            if (TextBoxUsernameSellerLogin.Text.Equals("") && TexteBoxPaswordSellerLogin.Text.Equals(""))
            {
                LabelSellerMessage.Text = ("Enter username and password");
            }
            else if (TextBoxUsernameSellerLogin.Text == "")
            {
                LabelSellerMessage.Text = ("Enter username");
            }
            else if (TexteBoxPaswordSellerLogin.Text == "")
            {
                LabelSellerMessage.Text = ("Enter password");
            }

            else
            {


                Admin Seller = new Admin(TextBoxUsernameSellerLogin.Text, TexteBoxPaswordSellerLogin.Text, "Sellers","Name","Password");
                Seller.Login();
                if (Seller.GetState() == "success")
                {
                    SellingForm sell = new SellingForm();
                    sell.Show();
                    sell.labelShowSellerName.Text = TextBoxUsernameSellerLogin.Text;
                    sellerName = TextBoxUsernameSellerLogin.Text;
                    this.Hide();              
                }
                else
                {
                    LabelSellerMessage.Text = ("Incorrect username or password ");
                }

            }


        }
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
            TextBoxUsernameSellerLogin.Clear();
            TexteBoxPaswordSellerLogin.Clear();
        }

   

        private void TextBoxadminUsername_MouseClick(object sender, MouseEventArgs e)
        {
            LabelErrorAdmin.Text = "";
        }

        private void TextBoxadminUPassword_Click(object sender, EventArgs e)
        {
            LabelErrorAdmin.Text = "";
        }

        private void ButtonLoginSeller_Click(object sender, EventArgs e)
        {
            SellerLogin();
        }

        private void ClearButtonSeller_Click(object sender, EventArgs e)
        {
            TextBoxUsernameSellerLogin.Clear();
            TexteBoxPaswordSellerLogin.Clear();
        }

        private void AdminLoginButton_Click(object sender, EventArgs e)
        {
            AdminLogin();
        }

        private void TextBoxUsernameSellerLogin_TextChanged(object sender, EventArgs e)
        {
            LabelSellerMessage.Text = "";
        }

        private void TexteBoxPaswordSellerLogin_TextChanged(object sender, EventArgs e)
        {
            LabelSellerMessage.Text = "";
        }

        private void TextBoxUsernameSellerLogin_Click(object sender, EventArgs e)
        {
            LabelSellerMessage.Text = "";
        }

        private void TexteBoxPaswordSellerLogin_Click(object sender, EventArgs e)
        {
            LabelSellerMessage.Text = "";
        }
    }
}
