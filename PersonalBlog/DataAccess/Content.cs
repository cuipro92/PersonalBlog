using MySql.Data.MySqlClient;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PersonalBlog.DataAccess
{
    public class Content
    {
        public DBConnect con = new DBConnect();
        public List<ContentModel> contentList = new List<ContentModel>();

        public List<ContentModel> GetAllData()
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM content";

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ContentModel cobj = new ContentModel
                        {
                            ContentID = reader["ContentID"].ToString(),
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString(),
                            UserCreate = reader["UserCreate"].ToString(),
                            UserUpdate = reader["UserUpdate"].ToString(),
                            DateCreate = Convert.ToDateTime(reader["DateCreate"].ToString()),
                            DateUpdate = Convert.ToDateTime(reader["DateUpdate"].ToString()),
                            CategoryID = reader["CategoryID"].ToString()
                        };
                        contentList.Add(cobj);
                    }

                    //close connection
                    con.connection.Close();

                    return contentList;
                }
            }
            catch (MySqlException)
            {
                return contentList;
            }
        }

        public ContentModel GetDataWithID(string id)
        {
            ContentModel cobj = null;
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM content Where ContentID = @ContentID";
                    con.AddParameter(cmd, "ContentID", id);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cobj = new ContentModel
                        {
                            ContentID = reader["ContentID"].ToString(),
                            Title = reader["Title"].ToString(),
                            Content = reader["Content"].ToString(),
                            UserCreate = reader["UserCreate"].ToString(),
                            UserUpdate = reader["UserUpdate"].ToString(),
                            DateCreate = Convert.ToDateTime(reader["DateCreate"].ToString()),
                            DateUpdate = Convert.ToDateTime(reader["DateUpdate"].ToString()),
                            CategoryID = reader["CategoryID"].ToString()
                        };
                        contentList.Add(cobj);
                    }

                    //close connection
                    con.connection.Close();

                    return cobj;
                }
            }
            catch (MySqlException)
            {
                return cobj;
            }
        }

        public void InsertContent(ContentModel content)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO content(ContentID, Title, Content, UserCreate, UserUpdate, DateCreate, DateUpdate, CategoryID) VALUES(@ContentID, @Title, @Content, @UserCreate, @UserUpdate, @DateCreate, @DateUpdate, @CategoryID)";

                    con.AddParameter(cmd, "ContentID", content.ContentID);
                    con.AddParameter(cmd, "Title", content.Title);
                    con.AddParameter(cmd, "Content", content.Content);
                    con.AddParameter(cmd, "UserCreate", content.UserCreate);
                    con.AddParameter(cmd, "UserUpdate", content.UserUpdate);
                    con.AddParameter(cmd, "DateCreate", content.DateCreate);
                    con.AddParameter(cmd, "DateUpdate", content.DateUpdate);
                    con.AddParameter(cmd, "CategoryID", content.CategoryID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }

        public void UpdateContent(ContentModel content)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "UPDATE content SET Title = @Title, Content = @Content, UserCreate = @UserCreate, UserUpdate = @UserUpdate, DateCreate = @DateCreate, DateUpdate = @DateUpdate, CategoryID = @CategoryID WHERE ContentID = @ContentID ";

                    con.AddParameter(cmd, "Title", content.Title);
                    con.AddParameter(cmd, "Content", content.Content);
                    con.AddParameter(cmd, "UserCreate", content.UserCreate);
                    con.AddParameter(cmd, "UserUpdate", content.UserUpdate);
                    con.AddParameter(cmd, "DateCreate", content.DateCreate);
                    con.AddParameter(cmd, "DateUpdate", content.DateUpdate);
                    con.AddParameter(cmd, "CategoryID", content.CategoryID);
                    con.AddParameter(cmd, "ContentID", content.ContentID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }

        public void DeleteContent(string id)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM content WHERE ContentID = @ContentID";
                    con.AddParameter(cmd, "ContentID", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }
    }
}