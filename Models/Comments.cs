using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BlogDemo.Models
{
    public class Comments : DbHelper
    {
        private string sql;
        public class Comment
        {
            public int cid;
            public int pid;
            public int uid;
            public string body;
            public string created;
            public string username;
        }
        public void Add(int pid, int uid, string body, string created)
        {
            sql = "insert into comments (pid, uid, body, created) values ('" + pid + "', '" + uid + "', '" + body + "', '" + created + "')";
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
        public void Delete(int cid)
        {
            sql = "delete from comments where cid = '" + cid + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
        public List<Comment> Index(int pid)
        {
            sql = "select * from comments where pid = '" + pid + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            List<Comment> commentList = new List<Comment>();
            while (dataReader.Read())
            {
                Comment comment = new Comment();
                comment.cid = (int)dataReader["cid"];
                comment.pid = (int)dataReader["pid"];
                comment.uid = (int)dataReader["uid"];
                comment.body = (string)dataReader["body"];
                comment.created = (string)dataReader["created"];
                Users users = new Users();
                comment.username = users.GetUsername(comment.uid);
                commentList.Add(comment);
            }
            dataReader.Close();  // do not forget to close it
            return commentList;
        }
        public int GetCommentNum(int pid)
        {
            sql = "select count(*) from comments where pid = '" + pid + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            int num = (int)command.ExecuteScalar();
            return num;
        }
    }
}