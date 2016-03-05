using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BlogDemo.Models
{
    public class Users : DbHelper
    {
        private string sql;
        public class User
        {
            public int uid;
            public string username;
        }
        public int Register(string username, string password)
        {
            // duplication of names
            if (this.IsRegister(username))
            {
                return 0;
            }
            sql = "insert into users (username, password) output inserted.uid values ('" + username + "', '" + password + "')";
            SqlCommand command = new SqlCommand(sql, connection);
            int uid = (int)command.ExecuteScalar();
            return uid;
        }
        public bool IsRegister(string username)
        {
            sql = "select count(*) from users where username = '" + username + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            int num = (int)command.ExecuteScalar();
            if (num > 0)
            {
                // has registed
                return true;
            }
            return false;
        }
        public int Login(string username, string password)
        {
            sql = "select count(*) from users where username = '" + username + "' and password = '" + password + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            int num = (int)command.ExecuteScalar();
            if (num == 1)
            {
                return this.GetUid(username);
            }
            return 0;
        }
        private int GetUid(string username)
        {
            sql = "select uid from users where username = '" + username + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            int uid = (int)command.ExecuteScalar();
            return uid;
        }
        public string GetUsername(int uid)
        {
            sql = "select username from users where uid = '" + uid + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            string username = (string)command.ExecuteScalar();
            return username;
        }
        public List<User> ListUser()
        {
            sql = "select * from users";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            List<User> userList = new List<User>();
            while (dataReader.Read())
            {
                User user = new User();
                user.uid = (int)dataReader["uid"];
                user.username = (string)dataReader["username"];
                userList.Add(user);
            }
            dataReader.Close();  // do not forget to close it
            return userList;
        }
        public void SetState(int uid)
        {
            HttpContext.Current.Session["uid"] = uid;
        }
        public int GetState()
        {
            if (HttpContext.Current.Session["uid"] == null)
            {
                return 0;
            }
            else
            {
                int uid = int.Parse(HttpContext.Current.Session["uid"].ToString());
                return uid;
            }
        }
    }
}