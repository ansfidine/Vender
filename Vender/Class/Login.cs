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
        private string tableName;
        private string rowPassword;
        private string rowUsername;
        private string auThentificationState;

        public Admin(string username,string password,string table,string rowusername,string rowpassword)
        {
            Username = username;
            Password = password;
            tableName = table;
            rowUsername = rowusername;
            rowPassword = rowpassword;
        }

        DBConnect dBCon = new DBConnect();
        public void Login()
        {
            string username = this.Username;
            string password = this.Password;
            string table = this.tableName;
            string rowusername = this.rowUsername;
            string rowpassword = this.rowPassword;

            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM "+table+" WHERE "+rowusername+"='" + username + "' AND "+rowpassword+"='" + password + "'", dBCon.GetCon());
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
