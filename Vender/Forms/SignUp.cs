using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vender.Forms
{
    public partial class SignUp : Form
    {
        private DBConnect dBCon = new DBConnect();
        public SignUp()
        {
            InitializeComponent();
            
        }

        //
        /// <summary>
        /// Sign Up function
        /// </summary>
        public void signUp()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(TextBoxUsername.Text) && String.IsNullOrWhiteSpace(TextBoxPassword.Text) && String.IsNullOrWhiteSpace(TextBoxtRepeatPassword.Text))
                {
                    LabelMessage.ForeColor = Color.Red;
                    LabelMessage.Text = "Please enter username and password ";
                }
                else
                {
                    if (TextBoxPassword.Text == TextBoxtRepeatPassword.Text)
                    {
                        int state = 0;
                        try
                        {
                            string updateQuery = "UPDATE admin SET username ='" + TextBoxUsername.Text + "',password ='" + TextBoxPassword.Text + "' WHERE ID =1";
                            SqlCommand cmd = new SqlCommand(updateQuery, dBCon.GetCon());
                            dBCon.OpenCon();
                            cmd.ExecuteNonQuery();
                            state = 1;
                        }
                        catch
                        {
                            state = 0;
                            LabelMessage.ForeColor = Color.Red;
                            LabelMessage.Text = ("Error please try again");

                        }

                        if (state == 1)
                        {
                            string stat = "1";
                            string path = @"venderRST.vf";
                            File.WriteAllText(path, stat);
                            AdminForm admin = new AdminForm();
                            admin.Show();
                            this.Hide();
                        }
                        
                    }
                    else
                    {
                        LabelMessage.Text = ("Password not correspond ");
                    }

                }


            }
            catch
            {
                LabelMessage.ForeColor = Color.Red;
                LabelMessage.Text = "Operation Failed ";
            }
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            TextBoxUsername.Text = "";
            TextBoxPassword.Text = "";
            TextBoxtRepeatPassword.Text = "";
        }

        private void ButtonSignUp_Click(object sender, EventArgs e)
        {
            signUp();
        }

        private void TextBoxUsername_Click(object sender, EventArgs e)
        {
            LabelMessage.Text = "";
        }

        private void TextBoxPassword_Click(object sender, EventArgs e)
        {
            LabelMessage.Text = "";
        }

        private void TextBoxtRepeatPassword_Click(object sender, EventArgs e)
        {
            LabelMessage.Text = "";
        }
    }
}
