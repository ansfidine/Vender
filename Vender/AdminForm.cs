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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuAdminPages);
            bunifuFormDock1.SubscribeControlToDragEvents(DashboardPage);
            bunifuFormDock1.SubscribeControlToDragEvents(CategoryPage);
            bunifuFormDock1.SubscribeControlToDragEvents(SellersPage);
            bunifuFormDock1.SubscribeControlToDragEvents(AboutPage);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            indicator.Top=((Control)sender).Top;
            bunifuAdminPages.SetPage(0);

        }

        private void CategoriesButton_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(1);
        }

        private void SellersButton_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(2);
        }

        private void SellingButton_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(3);
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
