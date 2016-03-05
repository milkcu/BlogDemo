using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;

namespace BlogDemo.Models
{
    public class Posts : DbHelper
    {
        private int limit = 10;
        private string sql;
        public class Post {
            public int pid;
            public int uid;
            public string title;
            public string body;
            public string created;
            public string username;
        }
        public int Add(int uid, string title, string body, string created)
        {
            sql = "insert into posts (uid, title, body, created) output inserted.pid values ('" + uid + "', '" + title + "', '" + body + "', '" + created + "')";
            SqlCommand command = new SqlCommand(sql, connection);
            int pid = (int)command.ExecuteScalar();
            return pid;
        }
        public Post Show(int pid)
        {
            sql = "select * from posts where pid = '" + pid + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            Post post = new Post();
            while (dataReader.Read())
            {
                post.pid = (int)dataReader["pid"]; ;
                post.uid = (int)dataReader["uid"];
                post.title = (string)dataReader["title"];
                post.body = (string)dataReader["body"];
                post.created = (string)dataReader["created"];
                Users users = new Users();
                post.username = users.GetUsername(post.uid);
            }
            dataReader.Close();
            return post;
        }
        public void Delete(int pid)
        {
            sql = "delete from posts where pid = '" + pid + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
        public List<Post> Index(int uid, int page)
        {
            int offset = (page - 1) * limit;
            if (uid == 0)
            {
                //sql = "select * from posts limit " + limit + " offset " + offset;
                sql = "select top " + limit + " * from posts where pid not in (select top " + offset + " pid from posts order by pid desc) order by pid desc;";
            }
            else
            {
                //sql = "select * from posts limit " + limit + " offset " + offset + " where uid = '" + uid + "'";
                sql = "select top " + limit + " * from posts where uid = '" + uid + "' and pid not in (select top " + offset + " pid from posts where uid = '" + uid + "' order by pid desc) order by pid desc;";
            }
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader dataReader = command.ExecuteReader();
            List<Post> postList = new List<Post>();
            while (dataReader.Read())
            {
                Post post = new Post();
                post.pid = (int) dataReader["pid"];
                post.uid = (int) dataReader["uid"];
                post.title = (string) dataReader["title"];
                post.body = (string) dataReader["body"];
                post.created = (string) dataReader["created"];
                Users users = new Users();
                post.username = users.GetUsername(post.uid);
                postList.Add(post);
            }
            dataReader.Close();  // do not forget to close it
            return postList;
        }
        public int GetPageNum(int uid)
        {
            if (uid == 0)
            {
                sql = "select count(*) from posts";
            }
            else
            {
                sql = "select count(*) from posts where uid = '" + uid + "'";
            }
            SqlCommand command = new SqlCommand(sql, connection);
            int num = (int)command.ExecuteScalar();
            int pageNum = (num + limit - 1) / limit;
            return pageNum;
        }
        public void Update(int pid, string title, string body, string created)
        {
            sql = "update posts set title = '" + title + "', body = '" + body + "', created = '" + created + "' where pid = '" + pid + "'";
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}