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
using System.IO;


namespace Vender
{
    public partial class AdminForm : Form
    {
        Bunifu.DataViz.WinForms.DataPoint datapoint1;
        //database Object
        private DBConnect dBCon = new DBConnect();

        //Global variables
        int countProduct, countCategory, countSellers ,total,quantity=0;
        string AdminName,username,password="";

        public AdminForm()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(bunifuAdminPages);
            bunifuFormDock1.SubscribeControlToDragEvents(DashboardPage);
            bunifuFormDock1.SubscribeControlToDragEvents(ProductsPage);
            bunifuFormDock1.SubscribeControlToDragEvents(SellersPage);
            bunifuFormDock1.SubscribeControlToDragEvents(CategoryPage);
            bunifuFormDock1.SubscribeControlToDragEvents(SettingPage);
            bunifuFormDock1.SubscribeControlToDragEvents(BillsPage);

            //DataViz Chart Theme Color
            DataViz1.colorSet.Add(Color.FromArgb(139, 0, 220));
        }

        private void dataViz()
        {
            datapoint1 = new Bunifu.DataViz.WinForms.DataPoint(Bunifu.DataViz.WinForms.BunifuDataViz._type.Bunifu_splineArea);
            Bunifu.DataViz.WinForms.Canvas canvas = new Bunifu.DataViz.WinForms.Canvas();
            Random random = new Random();
            datapoint1.addLabely("MON", random.Next(0, 50).ToString());
            datapoint1.addLabely("TUE", random.Next(0, 50).ToString());
            datapoint1.addLabely("WED", random.Next(0, 50).ToString());
            datapoint1.addLabely("FRI", random.Next(0, 50).ToString());
            datapoint1.addLabely("SAT", random.Next(0, 50).ToString());
            datapoint1.addLabely("SAN", random.Next(0, 50).ToString());

            canvas.addData(datapoint1);
            DataViz1.Render(canvas);
        }


        //
        //Change receipt Name 
        //
        private void ReceiptName()
        {
            string name = TextBoxReceipt.Text;
            string path = @"ReceiptName.vf";
            File.WriteAllText(path, name);

            string Text = File.ReadAllText(@"ReceiptName.vf");
            TextBoxReceipt.Text = Text;
        }
        //
        //Admin change usename and password function
        //
        private void adminChangeLogin()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(TextBoxUsername.Text) && String.IsNullOrWhiteSpace(TextBoxPassword.Text))
                {
                    labelPasswordMessage.ForeColor = Color.Red;
                    labelPasswordMessage.Text = "Please enter username or password ";
                }
                else 
                {
                    if (String.IsNullOrEmpty(TextBoxUsername.Text) == false && String.IsNullOrEmpty(TextBoxPassword.Text) == false)
                    {
                        string updateQuery = "UPDATE admin SET username ='" + TextBoxUsername.Text + "',password ='" + TextBoxPassword.Text + "' WHERE ID =1";
                        SqlCommand cmd = new SqlCommand(updateQuery, dBCon.GetCon());
                        dBCon.OpenCon();
                        cmd.ExecuteNonQuery();
                        labelPasswordMessage.ForeColor = Color.Green;
                        labelPasswordMessage.Text = ("Username & Password updated Successfully");
                    }
                    else if(String.IsNullOrEmpty(TextBoxUsername.Text) ==false)
                    {
                        string updateQuery = "UPDATE admin SET username ='" + TextBoxUsername.Text + "' WHERE ID =1";
                        SqlCommand cmd = new SqlCommand(updateQuery, dBCon.GetCon());
                        dBCon.OpenCon();
                        cmd.ExecuteNonQuery();
                        labelPasswordMessage.ForeColor = Color.Green;
                        labelPasswordMessage.Text = ("Username updated Successfully");
                    }
                   
                   else
                    {
                        string updateQuery = "UPDATE admin SET password ='" + TextBoxPassword.Text + "' WHERE ID =1";
                        SqlCommand cmd = new SqlCommand(updateQuery, dBCon.GetCon());
                        dBCon.OpenCon();
                        cmd.ExecuteNonQuery();
                        labelPasswordMessage.ForeColor = Color.Green;
                        labelPasswordMessage.Text = ("Password updated Successfully");
                    }

                }

            }
            catch
            {
                labelPasswordMessage.ForeColor = Color.Red;
                labelPasswordMessage.Text = "Operation Failed ";
            }

           
            
        }
        //Add Category implementation
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
        //Clear Functions implementation
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
        private void ClearSellers()
        {
            TextBoxIDSellers.Clear();
            TextBoxNameSellers.Clear();
            TextBoxPasswordSellers.Clear();
            TextBoxPhoneSellers.Clear();
        }

        //Update Category implementation
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
        //Delete Category implementation
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

        //Get Table Function implementation
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

        // getCagory function implementation used on Manage product section

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

        //Add Products function implementation used on Manage product section
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

        //Update product function implementation used on Manage Product Section
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

        //Delete product function implementation used on Manage Product Section
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

        //
        //Add function implementation used on Sellers section
        //
        private void AddSellers()
        {
            try
            {

                string insertQuery = "INSERT INTO Sellers VALUES(" + TextBoxIDSellers.Text + ",'" + TextBoxNameSellers.Text + "','" + TextBoxPasswordSellers.Text + "','" + TextBoxPhoneSellers.Text + "')";
                SqlCommand cmd = new SqlCommand(insertQuery, dBCon.GetCon());
                dBCon.OpenCon();
                cmd.ExecuteNonQuery();
                LabelMessageSellers.ForeColor = Color.Green;
                LabelMessageSellers.Text = ("Seller " +TextBoxNameSellers.Text+" Added Successfully");
                dBCon.CloseCon();
                getTable(DataGridViewSellers, "Sellers");
                ClearSellers();

            }
            catch
            {
                LabelMessageSellers.ForeColor = Color.Red;
                LabelMessageSellers.Text = "Failed to add Sellers";
            }
        }

        //
        //Update function implementation used on Sellers section
        //
        private void UpdateSellers()
        {
            try
            {
                if (TextBoxIDSellers.Text == "" || TextBoxNameSellers.Text == "" || TextBoxPasswordSellers.Text == "" || TextBoxPhoneSellers.Text == "")
                {
                    LabelMessageProduct.ForeColor = Color.Red;
                    LabelMessageSellers.Text = ("Warning! missing informations");
                }

                else
                {
                    string updateQuery = "UPDATE Sellers SET Name='" + TextBoxNameSellers.Text + "',Password ='" + TextBoxPasswordSellers.Text + "',Phone='" + TextBoxPhoneSellers.Text + "' WHERE ID =" + TextBoxIDSellers.Text + " ";
                    SqlCommand cmd = new SqlCommand(updateQuery, dBCon.GetCon());
                    dBCon.OpenCon();
                    cmd.ExecuteNonQuery();
                    LabelMessageSellers.ForeColor = Color.Green;
                    LabelMessageSellers.Text = ("Seller "+TextBoxNameSellers.Text+" updated Successfully");
                    dBCon.CloseCon();
                    getTable(DataGridViewSellers, "Sellers");
                    ClearSellers();
                }



            }
            catch
            {
                LabelMessageSellers.ForeColor = Color.Red;
                LabelMessageSellers.Text = "Update Failed ";
            }
        }

        //
        //DeleteSellers function implementation used on Sellers section
        //
        private void DeleteSellers()
        {
            try
            {

                string deleteQuery = "DELETE FROM Sellers WHERE ID =" + TextBoxIDSellers.Text + "";
                SqlCommand cmd = new SqlCommand(deleteQuery, dBCon.GetCon());
                dBCon.OpenCon();
                cmd.ExecuteNonQuery();
                LabelMessageSellers.ForeColor = Color.Green;
                LabelMessageSellers.Text = ("Seller "+TextBoxNameSellers.Text+" deleted Successfully");
                dBCon.CloseCon();
                getTable(DataGridViewSellers, "Sellers");
                ClearSellers();

            }
            catch
            {
                LabelMessageSellers.ForeColor = Color.Red;
                LabelMessageSellers.Text = "Delete Failed ";
            }
        }

        //
        //Search Sellers function
        //
        private void SearchSellers()
        {
            string selectQuery = "SELECT * FROM Sellers WHERE Name LIKE '%"+TextBoxSearchSellers.Text+"%'";
            SqlCommand cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridViewSellers.DataSource = table;
            dBCon.CloseCon();
        }

        //
        //Search Bills function
        //
        private void SearchBills()
        {
            dBCon.OpenCon();
            string selectQuery = "SELECT * FROM Bill WHERE Name LIKE '%" + TextBoxSearchBills.Text + "%'";
            SqlCommand cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridViewBills.DataSource = table;

            string selectQuery1 = "SELECT  SUM(Total) AS Total FROM Bill  WHERE Name LIKE '%" + TextBoxSearchBills.Text + "%'";
            SqlCommand cmd1 = new SqlCommand(selectQuery1, dBCon.GetCon());
            total = (int)cmd1.ExecuteScalar();
            LabelBillTotal.Text = total.ToString() + " $";

            dBCon.CloseCon();
        }

        //
        //MoveOnMenu function 
        //
        private void MoveOnMenu(Object sender, int position, int R,int G,int B)
        {
            indicator.BackColor = Color.FromArgb(R,G,B);
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(position);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
        
            bunifuElipse1.ApplyElipse(bunifuGradientPanel2);
            bunifuElipse1.ApplyElipse(bunifuGradientPanel3);
            bunifuElipse1.ApplyElipse(bunifuGradientPanel4);
            dataViz();
            getTable(DataGridViewCategory,"Category");
            getTable(DataGridViewProducts, "Product");
            getTable(DataGridViewSellers, "Sellers");
            getCategory();
            indic.Hide();
            string Text = File.ReadAllText(@"ReceiptName.vf");
            TextBoxReceipt.Text = Text;
            information();
        }
        /// <summary>
        /// Dashboard Information
        /// </summary>
        public void information()
        {
            dBCon.OpenCon();
            
            //Total
            string selectQuery = "SELECT  SUM(Total) AS Total FROM Bill ";
            SqlCommand cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            total = (int)cmd.ExecuteScalar();
            DashlabelTotal.Text = total.ToString() + " $";

            //Product
            selectQuery = "SELECT COUNT(Name) AS total from Product";
            cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            countProduct = (int)cmd.ExecuteScalar();
            DashlabelProduct.Text = countProduct.ToString();

            //Category
            selectQuery = "SELECT COUNT(Name) AS total from Category";
            cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            countCategory = (int)cmd.ExecuteScalar();
            DashlabelCategory.Text = countCategory.ToString();

            //Sellers
            selectQuery = "SELECT COUNT(Name) AS total from Sellers";
            cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            countSellers = (int)cmd.ExecuteScalar();
            DashlabelSellers.Text = countSellers.ToString();

            //Product Quantity
            selectQuery = "SELECT  SUM(Quantity) AS Total FROM Product";
            cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            quantity = (int)cmd.ExecuteScalar();
            DashlabelQuantity.Text = quantity.ToString();

            //Admin Name
            selectQuery = "SELECT  username FROM admin WHERE id = 1";
            cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            AdminName = (string)cmd.ExecuteScalar();
            AdminNameLabel.Text = AdminName.ToString();

            //Username
            selectQuery = "SELECT  username FROM admin WHERE id = 1";
            cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            username = (string)cmd.ExecuteScalar();
            labelUsername.Text = username.ToString();

            //Password
            selectQuery = "SELECT  password FROM admin WHERE id = 1";
            cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            password = (string)cmd.ExecuteScalar();
            labelPassword.Text = password.ToString();
        }

        //
        //Get seller table in Bills Sections
        //
        private void getSellTable()
        {
            string selectQuery = "SELECT * FROM Bill";
            SqlCommand cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridViewBills.DataSource = table;
        }


        //
        //Lateral Button
        //
        private void DashboardButton_Click(object sender, EventArgs e)
        {
           

            indicator.Show();
            indic.Hide();
            indicator.BackColor = Color.FromArgb(96, 0, 152);
            indicator.Top=((Control)sender).Top;
            bunifuAdminPages.SetPage(0);
            information();
        }

        private void CategoriesButton_Click(object sender, EventArgs e)
        {
            indicator.Show();
            indic.Hide();
            indicator.BackColor= Color.ForestGreen;
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(1);
            getCategory();
        }

        private void SellersButton_Click(object sender, EventArgs e)
        {
            indicator.Show();
            indic.Hide();
            indicator.BackColor = Color.FromArgb(55, 206, 211);
            indicator.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(2);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            indicator.Show();
            indic.Hide();
            indicator.BackColor = Color.FromArgb(164, 36, 109);
            indicator.Top = ((Control)sender).Top;
            About about = new About();
            about.Show();
            this.Hide();
            
        }
        private void SellButton_Click(object sender, EventArgs e)
        {
            indicator.Show();
            indic.Hide();
            SellingForm sell = new SellingForm();
            sell.Show();
            sell.labelShowSellerName.Text = "Admin";
            this.Hide();
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            indicator.Show();
            indic.Hide();
            MoveOnMenu(sender,3,96,155,235);

        }
        private void BillButton_Click(object sender, EventArgs e)
        {
            indic.Show();
            indicator.Hide();
            indic.BackColor = Color.FromArgb(255, 0, 0);
            indic.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(4);
            getSellTable();
            LabelBillTotal.Text = total.ToString()+" $";
        }
        private void PasswordButton_Click(object sender, EventArgs e)
        {
            indic.Show();
            indicator.Hide();
            indic.BackColor = Color.FromArgb(38, 17, 60);
            indic.Top = ((Control)sender).Top;
            bunifuAdminPages.SetPage(5);
        }


        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }

        //
        //Minimize Button
        //
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// 
        /// All Called function on Category Section
        /// 
        private void DataGridViewCategory_Click(object sender, EventArgs e)
        {
            LabelMessageCategory.ForeColor = Color.Blue;
            LabelMessageCategory.Text = "Warning! don't change the ID";
            TextBoxIDCategory.Text = DataGridViewCategory.SelectedRows[0].Cells[0].Value.ToString();
            TextBoxNameCategory.Text = DataGridViewCategory.SelectedRows[0].Cells[1].Value.ToString();
            TextBoxDescriptionCategory.Text = DataGridViewCategory.SelectedRows[0].Cells[2].Value.ToString();
        }
        private void ProductCategoryDropdownSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Product WHERE Category ='" + ProductCategoryDropdownSearch.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, dBCon.GetCon());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            DataGridViewProducts.DataSource = table;
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

        /// 
        /// All Called function on Products Section
        /// 

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

        private void refreshButtonProduct_Click(object sender, EventArgs e)
        {
            getTable(DataGridViewProducts, "Product");
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



        /// 
        /// All Called function on Sellers Section
        /// 
        private void DataGridViewSellers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LabelMessageSellers.ForeColor = Color.Blue;
            LabelMessageSellers.Text = "Warning! don't change the ID";
            TextBoxIDSellers.Text = DataGridViewSellers.SelectedRows[0].Cells[0].Value.ToString();
            TextBoxNameSellers.Text = DataGridViewSellers.SelectedRows[0].Cells[1].Value.ToString();
            TextBoxPasswordSellers.Text = DataGridViewSellers.SelectedRows[0].Cells[2].Value.ToString();
            TextBoxPhoneSellers.Text = DataGridViewSellers.SelectedRows[0].Cells[3].Value.ToString();

        }

        private void ButtonAddSellers_Click(object sender, EventArgs e)
        {
            AddSellers();
        }

        private void ButtonUpdateSellers_Click(object sender, EventArgs e)
        {
            UpdateSellers();
        }

        private void ButtonDeleteSellers_Click(object sender, EventArgs e)
        {
            DeleteSellers();
        }

        private void ButtonSearchSellers_Click(object sender, EventArgs e)
        {
            SearchSellers();
        }
        private void ButtonPassChange_Click(object sender, EventArgs e)
        {
            adminChangeLogin();
            information();
        }
        private void ButtonReceipt_Click(object sender, EventArgs e)
        {
            ReceiptName();

        }

        private void TextBoxIDSellers_Click(object sender, EventArgs e)
        {
            LabelMessageSellers.Text ="";
        }

        private void TextBoxNameSellers_Click(object sender, EventArgs e)
        {
            LabelMessageSellers.Text = "";
        }

        private void TextBoxPasswordSellers_Click(object sender, EventArgs e)
        {
            LabelMessageSellers.Text = "";
        }

        private void TextBoxPhoneSellers_Click(object sender, EventArgs e)
        {
            LabelMessageSellers.Text = "";
        }

        private void TextBoxUsername_MouseClick(object sender, MouseEventArgs e)
        {
            labelPasswordMessage.Text = "";
        }

        private void TextBoxPassword_MouseClick(object sender, MouseEventArgs e)
        {
            labelPasswordMessage.Text = "";
        }

        private void ButtonSearchBills_Click(object sender, EventArgs e)
        {
            SearchBills();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

    }
    
}
