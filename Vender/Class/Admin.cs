using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Vender
{
    class Admin
    {
        private string Username;
        private string Password;
        private string auThentificationState;

        public Admin(string username,string password)
        {
            Username = username;
            Password = password;
        }

        DBConnect dBCon = new DBConnect();
        public void Login()
        {
            string username = this.Username;
            string password = this.Password;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM admin WHERE username='" + username + "' AND password='" + password + "'", dBCon.GetCon());
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                auThentificationState = "success";
              
            }
            else
            {
                auThentificationState = "failed";
            
            }
            
        }

        public string GetState()
        {
            return auThentificationState;
        }

    }
}
