using MySql.Data.MySqlClient;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PersonalBlog.DataAccess
{
    public class Category
    {
        public DBConnect con = new DBConnect();
        public List<CategoryModel> categoryList = new List<CategoryModel>();
        CategoryModel cobj = null;

        public List<CategoryModel> GetAllData()
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM categories";

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CategoryModel cobj = new CategoryModel
                        {
                            CategoryID = reader["CategoryID"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            UserCreate = reader["UserCreate"].ToString(),
                            UserUpdate = reader["UserUpdate"].ToString(),
                            DateCreate = Convert.ToDateTime(reader["DateCreate"].ToString()),
                            DateUpdate = Convert.ToDateTime(reader["DateUpdate"].ToString())
                        };
                        categoryList.Add(cobj);
                    }

                    //close connection
                    con.connection.Close();

                    return categoryList;
                }
            }
            catch (MySqlException)
            {
                return categoryList;
            }
        }

        public CategoryModel GetDataWithID(string id)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM categories WHERE CategoryID = @CategoryID";

                    con.AddParameter(cmd, "CategoryID", id);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cobj = new CategoryModel
                        {
                            CategoryID = reader["CategoryID"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            UserCreate = reader["UserCreate"].ToString(),
                            UserUpdate = reader["UserUpdate"].ToString(),
                            DateCreate = Convert.ToDateTime(reader["DateCreate"].ToString()),
                            DateUpdate = Convert.ToDateTime(reader["DateUpdate"].ToString())
                        };
                        categoryList.Add(cobj);
                    }
                    con.connection.Close();

                    return cobj;
                }
            }
            catch (MySqlException)
            {
                return cobj;
            }
        }

        public void InsertCategory(CategoryModel cate)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO categories(CategoryID, CategoryName, UserCreate, UserUpdate, DateCreate, DateUpdate) VALUES(@CategoryID, @CategoryName, @UserCreate, @UserUpdate, @DateCreate, @DateUpdate)";

                    con.AddParameter(cmd, "CategoryID", cate.CategoryID);
                    con.AddParameter(cmd, "CategoryName", cate.CategoryName);
                    con.AddParameter(cmd, "UserCreate", cate.UserCreate);
                    con.AddParameter(cmd, "UserUpdate", cate.UserUpdate);
                    con.AddParameter(cmd, "DateCreate", cate.DateCreate);
                    con.AddParameter(cmd, "DateUpdate", cate.DateUpdate);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }

        public void UpdateCategory(CategoryModel cate)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "UPDATE categories SET CategoryName = @CategoryName, UserCreate = @UserCreate, UserUpdate = @UserUpdate, DateCreate = @DateCreate, DateUpdate = @DateUpdate WHERE CategoryID = @CategoryID ";

                    con.AddParameter(cmd, "CategoryID", cate.CategoryID);
                    con.AddParameter(cmd, "CategoryName", cate.CategoryName);
                    con.AddParameter(cmd, "UserCreate", cate.UserCreate);
                    con.AddParameter(cmd, "UserUpdate", cate.UserUpdate);
                    con.AddParameter(cmd, "DateCreate", cate.DateCreate);
                    con.AddParameter(cmd, "DateUpdate", cate.DateUpdate);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }

        public void DeleteCategory(string id)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM categories WHERE CategoryID = @CategoryID";

                    con.AddParameter(cmd, "CategoryID", id);
                    //IDbDataParameter CategoryID = cmd.CreateParameter();
                    //CategoryID.ParameterName = "@CategoryID";
                    //CategoryID.Value = id;
                    //cmd.Parameters.Add(CategoryID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }
    }
}