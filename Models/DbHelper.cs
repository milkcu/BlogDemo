using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BlogDemo.Models
{
    public class DbHelper
    {
        protected SqlConnection connection;
        public DbHelper()
        {
            string connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\Projects\\VisualStudioProjects\\BlogDemo\\App_Data\\Database.mdf;Integrated Security=True;User Instance=True";
            connection = new SqlConnection(connString);
            connection.Open();
            //connection.Close();
        }
    }
}