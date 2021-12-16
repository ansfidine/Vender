using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Vender
{
    public partial class AdminForm : Form
    {
        private string IdIncidatorCat;
        //database Object
        private DBConnect dBCon = new DBConnect(); 
        public AdminForm()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuAdminPages);
            bunifuFormDock1.SubscribeControlToDragEvents(DashboardPage);
            bunifuFormDock1.SubscribeControlToDragEvents(ProductsPage);
            bunifuFormDock1.SubscribeControlToDragEvents(SellersPage);
            bunifuFormDock1.SubscribeControlToDragEvents(AboutPage);
            bunifuFormDock1.SubscribeControlToDragEvents(CategoryPage);
        }

        //Add Category
        private void AddCategory()
        {
            try
            {

                string insertQuery = "INSERT INTO Category VALUES(" + TextBoxIDCategory.Text + ",'" + TextBoxNameCategory.Text + "','" + TextBoxDescriptionCategory.Text + "')";
                SqlCommand cmd = new SqlCommand(insertQuery, dBCon.GetCon());
                dBCon.OpenCon();
                cmd.ExecuteNonQuery();
                LabelMessageCategory.ForeColor = Color.Green;
                LabelMessageCategory.Text = ("Category Added Successfully");
                dBCon.CloseCon();
                GetTable(DataGridViewCategory, "Category");

            }
            catch
            {
                LabelMessageCategory.ForeColor = Color.Red;
                LabelMessageCategory.Text = "Failed to add Category";
            }
            ClearCategory();
        }

        private void ClearCategory()
        {
            TextBoxIDCategory.Clear();
            TextBoxNameCategory.Clear();
            TextBoxDescriptionCategory.Clear();
        }

        //Update Category 
        private void UpdateCategory()
       
        {
            try
            {
                if(TextBoxIDCategory.Text =="" || TextBoxNameCategory.Text=="" || TextBoxDescriptionCategory.Text=="")
                {
                    LabelMessageCategory.ForeColor = Color.Red;
                    LabelMessageCategory.Text = ("Warning! missing informations");
                }
                else if (IdIncidatorCat != TextBoxIDCategory.Text)
                {
                    LabelMessageCategory.ForeColor = Color.Red;
                    LabelMessageCategory.Text = ("Warning! you can't modify the ID ");
                }
                else
                {
                    string updateQuery = "UPDATE Category SET Name='" + TextBoxNameCategory.Text + "',Description ='" + TextBoxDescriptionCategory.Text + "'WHERE ID =" + TextBoxIDCategory.Text + " ";
                    SqlCommand cmd = new SqlCommand(updateQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    cmd.ExecuteNonQuery();
                    LabelMessageCategory.ForeColor = Color.Green;
                    LabelMessageCategory.Text = ("Category updated Successfully");
                    dBCon.CloseCon();
                    GetTable(DataGridViewCategory, "Category");
                }

                

            }
            catch
            {
                LabelMessageCategory.ForeColor = Color.Red;
                LabelMessageCategory.Text = "Update Failed ";
            }
            ClearCategory();
        }
        //Delete Category
        private void DeleteCategory()
        {
            try
            {
                
                 string deleteQuery = "DELETE FROM Category WHERE ID =" + TextBoxIDCategory.Text + "";
                 SqlCommand cmd = new SqlCommand(deleteQuery, dBCon.GetCon());
                 dBCon.OpenCon();
                 cmd.ExecuteNonQuery();
                 LabelMessageCategory.ForeColor = Color.Green;
                 LabelMessageCategory.Text = ("Category deleted Successfully");
                 dBCon.CloseCon();
                 GetTable(DataGridViewCategory, "Category");
                
                
            }
            catch
            {
                LabelMessageCategory.ForeColor = Color.Red;
                LabelMessageCategory.Text = "Delete Failed ";
            }
            ClearCategory();
        }
        private void GetTable(DataGridView Grid,string sTable)
        {
            string selectedTable = sTable;
            string selectQuery = "SELECT * FROM "+selectedTable+"";
            SqlCommand cmd = new SqlCommand(selectQuery,dBCon.GetCon());
            SqlDataAdapter adapter =new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Grid.DataSource = table;
        }

        private void MoveOnMenu(Object sender, int position, int R,int G,int B)
        {
            indicator.BackColor = Color.FromArgb(R,G,B);
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(position);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            GetTable(DataGridViewCategory,"Category");
            GetTable(DataGridViewProducts, "Product");
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            indicator.BackColor = Color.FromArgb(96, 0, 152);
            indicator.Top=((Control)sender).Top;
            bunifuAdminPages.SetPage(0);

        }

        private void CategoriesButton_Click(object sender, EventArgs e)
        {
            indicator.BackColor= Color.ForestGreen;
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(1);
        }

        private void SellersButton_Click(object sender, EventArgs e)
        {
            indicator.BackColor = Color.FromArgb(55, 206, 211);
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(2);
        }

        

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            indicator.BackColor = Color.FromArgb(164, 36, 109);
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(3);
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            
            MoveOnMenu(sender,4,96,155,235);

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void SellButton_Click(object sender, EventArgs e)
        {

        }

        private void AddButtonCategory_Click(object sender, EventArgs e)
        {
            AddCategory();

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void updateButtonCategory_Click(object sender, EventArgs e)
        {
            UpdateCategory();
        }

        private void DataGridViewCategory_Click(object sender, EventArgs e)
        {
            TextBoxIDCategory.Text = DataGridViewCategory.SelectedRows[0].Cells[0].Value.ToString();
            TextBoxNameCategory.Text= DataGridViewCategory.SelectedRows[0].Cells[1].Value.ToString();
            TextBoxDescriptionCategory.Text= DataGridViewCategory.SelectedRows[0].Cells[2].Value.ToString();
            IdIncidatorCat = TextBoxIDCategory.Text;
        }

        private void TextBoxIDCategory_Click(object sender, EventArgs e)
        {
            LabelMessageCategory.Text = "";
        }

        private void TextBoxNameCategory_Click(object sender, EventArgs e)
        {
            LabelMessageCategory.Text = "";
        }

        private void TextBoxDescriptionCategory_Click(object sender, EventArgs e)
        {
            LabelMessageCategory.Text = "";
        }

        private void deleteButtonCategory_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }
    }
}
