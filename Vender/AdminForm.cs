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
                getTable(DataGridViewCategory, "Category");
                ClearCategory();
            }
            catch
            {
                LabelMessageCategory.ForeColor = Color.Red;
                LabelMessageCategory.Text = "Failed to add Category";
            }
            
        }
        //Clear Function
        private void ClearCategory()
        {
            TextBoxIDCategory.Clear();
            TextBoxNameCategory.Clear();
            TextBoxDescriptionCategory.Clear();
        }

        private void ClearProduct()
        {
            TextBoxIDProduct.Clear();
            TextBoxNameProduct.Clear();
            TextBoxPriceProduct.Clear();
            TextBoxQuantityProduct.Clear();

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
               
                else
                {
                    string updateQuery = "UPDATE Category SET Name='" + TextBoxNameCategory.Text + "',Description ='" + TextBoxDescriptionCategory.Text + "'WHERE ID =" + TextBoxIDCategory.Text + " ";
                    SqlCommand cmd = new SqlCommand(updateQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    cmd.ExecuteNonQuery();
                    LabelMessageCategory.ForeColor = Color.Green;
                    LabelMessageCategory.Text = ("Category updated Successfully");
                    dBCon.CloseCon();
                    getTable(DataGridViewCategory, "Category");
                    ClearCategory();
                }

                

            }
            catch
            {
                LabelMessageCategory.ForeColor = Color.Red;
                LabelMessageCategory.Text = "Update Failed ";
            }
            
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
                 getTable(DataGridViewCategory, "Category");
                 ClearCategory();

            }
            catch
            {
                LabelMessageCategory.ForeColor = Color.Red;
                LabelMessageCategory.Text = "Delete Failed ";
            }
            
        }

        //Get Table Function
        private void getTable(DataGridView Grid,string sTable)
        {
            string selectedTable = sTable;
            string selectQuery = "SELECT * FROM "+selectedTable+"";
            SqlCommand cmd = new SqlCommand(selectQuery,dBCon.GetCon());
            SqlDataAdapter adapter =new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Grid.DataSource = table;
        }

        // getCagory function used on Manage product section

        private void getCategory()
        {
            string selectQuery = "SELECT * FROM Category";
            SqlCommand cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            ProductCategoryDropdown.DataSource = table;
            ProductCategoryDropdown.ValueMember = "Name";
            ProductCategoryDropdownSearch.DataSource = table;
            ProductCategoryDropdownSearch.ValueMember = "Name";
        }

        //Add Products function used on Manage product section
        private void AddProducts()
        {
            try
            {

                string insertQuery = "INSERT INTO Product VALUES("+TextBoxIDProduct.Text+",'"+TextBoxNameProduct.Text+"',"+TextBoxPriceProduct.Text+","+TextBoxQuantityProduct.Text+",'"+ProductCategoryDropdown.Text+"')";
                SqlCommand cmd = new SqlCommand(insertQuery, dBCon.GetCon());
                dBCon.OpenCon();
                cmd.ExecuteNonQuery();
                LabelMessageProduct.ForeColor = Color.Green;
                LabelMessageProduct.Text = ("Product Added Successfully");
                dBCon.CloseCon();
                getTable(DataGridViewProducts, "Product");
                ClearProduct();

            }
            catch
            {
                LabelMessageProduct.ForeColor = Color.Red;
                LabelMessageProduct.Text = "Failed to add Product";
            }
           
        }

        //Update product function used on Manage Product Section
        private void UpdateProduct()
        {
            try
            {
                if (TextBoxIDProduct.Text == "" || TextBoxNameProduct.Text == "" || TextBoxPriceProduct.Text == "" || TextBoxQuantityProduct.Text=="")
                {
                    LabelMessageProduct.ForeColor = Color.Red;
                    LabelMessageProduct.Text = ("Warning! missing informations");
                }
                
                else
                {
                    string updateQuery = "UPDATE Product SET Name='"+TextBoxNameProduct.Text+"',Price ="+TextBoxPriceProduct.Text + ",Quantity="+TextBoxQuantityProduct.Text+" WHERE ID ="+TextBoxIDProduct.Text+" ";
                    SqlCommand cmd = new SqlCommand(updateQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    cmd.ExecuteNonQuery();
                    LabelMessageProduct.ForeColor = Color.Green;
                    LabelMessageProduct.Text = ("Product updated Successfully");
                    dBCon.CloseCon();
                    getTable(DataGridViewProducts, "Product");
                    ClearProduct();
                }



            }
            catch
            {
                LabelMessageProduct.ForeColor = Color.Red;
                LabelMessageProduct.Text = "Update Failed ";
            }

        }

        //Delete product function used on Manage Product Section
        private void DeleteProduct()
        {
            try
            {

                string deleteQuery = "DELETE FROM Product WHERE ID =" + TextBoxIDProduct.Text + "";
                SqlCommand cmd = new SqlCommand(deleteQuery, dBCon.GetCon());
                dBCon.OpenCon();
                cmd.ExecuteNonQuery();
                LabelMessageProduct.ForeColor = Color.Green;
                LabelMessageProduct.Text = ("Product deleted Successfully");
                dBCon.CloseCon();
                getTable(DataGridViewProducts, "Product");
                ClearProduct();

            }
            catch
            {
                LabelMessageProduct.ForeColor = Color.Red;
                LabelMessageProduct.Text = "Delete Failed ";
            }
        }
        private void MoveOnMenu(Object sender, int position, int R,int G,int B)
        {
            indicator.BackColor = Color.FromArgb(R,G,B);
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(position);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            getTable(DataGridViewCategory,"Category");
            getTable(DataGridViewProducts, "Product");
            getCategory();

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

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void AddButtonCategory_Click(object sender, EventArgs e)
        {
            AddCategory();

        }
        private void deleteButtonCategory_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }

        private void updateButtonCategory_Click(object sender, EventArgs e)
        {
            UpdateCategory();
        }

      

        private void DataGridViewCategory_Click(object sender, EventArgs e)
        {
            LabelMessageCategory.ForeColor = Color.Blue;
            LabelMessageCategory.Text = "Warning! don't change the ID";
            TextBoxIDCategory.Text = DataGridViewCategory.SelectedRows[0].Cells[0].Value.ToString();
            TextBoxNameCategory.Text= DataGridViewCategory.SelectedRows[0].Cells[1].Value.ToString();
            TextBoxDescriptionCategory.Text= DataGridViewCategory.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void DataGridViewProducts_Click(object sender, EventArgs e)
        {
            LabelMessageProduct.ForeColor = Color.Blue;
            LabelMessageProduct.Text = "Warning! don't change the ID";
            TextBoxIDProduct.Text = DataGridViewProducts.SelectedRows[0].Cells[0].Value.ToString();
            TextBoxNameProduct.Text = DataGridViewProducts.SelectedRows[0].Cells[1].Value.ToString();
            TextBoxPriceProduct.Text = DataGridViewProducts.SelectedRows[0].Cells[2].Value.ToString();
            TextBoxQuantityProduct.Text = DataGridViewProducts.SelectedRows[0].Cells[3].Value.ToString();
            ProductCategoryDropdown.SelectedValue = DataGridViewProducts.SelectedRows[0].Cells[4].Value.ToString();
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

        private void TextBoxIDProduct_Click(object sender, EventArgs e)
        {
            LabelMessageProduct.Text = "";
        }

        private void TextBoxNameProduct_Click(object sender, EventArgs e)
        {
            LabelMessageProduct.Text = "";
        }

        private void TextBoxPriceProduct_Click(object sender, EventArgs e)
        {
            LabelMessageProduct.Text = "";
        }

        private void TextBoxQuantityProduct_Click(object sender, EventArgs e)
        {
            LabelMessageProduct.Text = "";
        }

        private void addButtonProduct_Click(object sender, EventArgs e)
        {
            AddProducts();
        }

        private void updateButtonProduct_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void deleteButtonProduct_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }
    }
}
