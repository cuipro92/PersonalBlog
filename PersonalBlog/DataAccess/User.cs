using MySql.Data.MySqlClient;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PersonalBlog.DataAccess
{
    public class User
    {
        public DBConnect con = new DBConnect();
        public List<UserModel> userList = new List<UserModel>();

        public List<UserModel> GetAllData()
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM user";

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UserModel uobj = new UserModel
                        {
                            UserID = reader["UserID"].ToString(),
                            UserName = reader["UserName"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Password = reader["Password"].ToString(),
                            Email = reader["Email"].ToString(),
                            UserCreate = reader["UserCreate"].ToString(),
                            UserUpdate = reader["UserUpdate"].ToString(),
                            DateCreate = Convert.ToDateTime(reader["DateCreate"].ToString()),
                            DateUpdate = Convert.ToDateTime(reader["DateUpdate"].ToString()),
                            RoleID = reader["RoleID"].ToString()
                        };
                        userList.Add(uobj);
                    }

                    //close connection
                    con.connection.Close();

                    return userList;
                }
            }
            catch (MySqlException)
            {
                return userList;
            }
        }

        public UserModel GetDataWithID(string id)
        {
            UserModel uobj = null;
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM user Where UserID = @UserID";
                    con.AddParameter(cmd, "UserID", id);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        uobj = new UserModel
                        {
                            UserID = reader["UserID"].ToString(),
                            UserName = reader["UserName"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            Password = reader["Password"].ToString(),
                            Email = reader["Email"].ToString(),
                            UserCreate = reader["UserCreate"].ToString(),
                            UserUpdate = reader["UserUpdate"].ToString(),
                            DateCreate = Convert.ToDateTime(reader["DateCreate"].ToString()),
                            DateUpdate = Convert.ToDateTime(reader["DateUpdate"].ToString()),
                            RoleID = reader["RoleID"].ToString()
                        };
                        userList.Add(uobj);
                    }

                    //close connection
                    con.connection.Close();

                    return uobj;
                }
            }
            catch (MySqlException)
            {
                return uobj;
            }
        }

        public void InsertUser(UserModel user)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO user(UserID, UserName, FullName, Password, Email, UserCreate, UserUpdate, DateCreate, DateUpdate, RoleID) VALUES(@UserID, @UserName, @FullName, @Password, @Email, @UserCreate, @UserUpdate, @DateCreate, @DateUpdate, @RoleID)";

                    con.AddParameter(cmd, "UserID", user.UserID);
                    con.AddParameter(cmd, "UserName", user.UserName);
                    con.AddParameter(cmd, "FullName", user.FullName);
                    con.AddParameter(cmd, "Password", user.Password);
                    con.AddParameter(cmd, "Email", user.Email);
                    con.AddParameter(cmd, "UserCreate", user.UserCreate);
                    con.AddParameter(cmd, "UserUpdate", user.UserUpdate);
                    con.AddParameter(cmd, "DateCreate", user.DateCreate);
                    con.AddParameter(cmd, "DateUpdate", user.DateUpdate);
                    con.AddParameter(cmd, "RoleID", user.RoleID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }

        public void UpdateUser(UserModel user)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "UPDATE user SET UserName = @UserName, FullName = @FullName, Password = @Password,  Email = @Email, UserCreate = @UserCreate, UserUpdate = @UserUpdate, DateCreate = @DateCreate, DateUpdate = @DateUpdate, RoleID = @RoleID WHERE UserID = @UserID ";

                    con.AddParameter(cmd, "UserName", user.UserName);
                    con.AddParameter(cmd, "FullName", user.FullName);
                    con.AddParameter(cmd, "Password", user.Password);
                    con.AddParameter(cmd, "Email", user.Email);
                    con.AddParameter(cmd, "UserCreate", user.UserCreate);
                    con.AddParameter(cmd, "UserUpdate", user.UserUpdate);
                    con.AddParameter(cmd, "DateCreate", user.DateCreate);
                    con.AddParameter(cmd, "DateUpdate", user.DateUpdate);
                    con.AddParameter(cmd, "RoleID", user.RoleID);
                    con.AddParameter(cmd, "UserID", user.UserID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }

        public void DeleteUser(string id)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM user WHERE UserID = @UserID";
                    con.AddParameter(cmd, "UserID", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }

        public bool IsLogin(string user, string pass)
        {
            bool isLogin = false;
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM user WHERE UserName = @UserName and Password = @Password";
                    con.AddParameter(cmd, "UserName", user);
                    con.AddParameter(cmd, "Password", pass);

                    IDataReader reader = cmd.ExecuteReader();
                    int temp = 0;
                    while (reader.Read()) { temp++; }
                    if (temp > 0)
                    {
                        isLogin = true;
                    }
                }
            }
            catch (MySqlException)
            {

            }
            return isLogin;
        }
    }
}