using MySql.Data.MySqlClient;
using PersonalBlog.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PersonalBlog.DataAccess
{
    public class Role
    {
        public DBConnect con = new DBConnect();
        public List<RoleModel> roleList = new List<RoleModel>();

        public List<RoleModel> GetAllData()
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM role";

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        RoleModel robj = new RoleModel
                        {
                            RoleID = reader["RoleID"].ToString(),
                            RoleName = reader["RoleName"].ToString()
                        };
                        roleList.Add(robj);
                    }

                    //close connection
                    con.connection.Close();

                    return roleList;
                }
            }
            catch (MySqlException)
            {
                return roleList;
            }
        }

        public RoleModel GetDataWithID(string id)
        {
            RoleModel robj = null;
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM role Where RoleID = @RoleID";
                    con.AddParameter(cmd, "RoleID", id);

                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        robj = new RoleModel
                        {
                            RoleID = reader["RoleID"].ToString(),
                            RoleName = reader["RoleName"].ToString()
                        };
                        roleList.Add(robj);
                    }

                    //close connection
                    con.connection.Close();

                    return robj;
                }
            }
            catch (MySqlException)
            {
                return robj;
            }
        }

        public void InsertRole(RoleModel role)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO role(RoleID, RoleName) VALUES(@RoleID, @RoleName)";

                    con.AddParameter(cmd, "RoleID", role.RoleID);
                    con.AddParameter(cmd, "RoleName", role.RoleName);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }

        public void UpdateRole(RoleModel role)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "UPDATE role SET RoleName = @RoleName WHERE RoleID = @RoleID ";

                    con.AddParameter(cmd, "RoleName", role.RoleName);
                    con.AddParameter(cmd, "RoleID", role.RoleID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }

        public void DeleteRole(string id)
        {
            try
            {
                using (con.connection)
                {
                    con.connection.Open();
                    IDbCommand cmd = con.connection.CreateCommand();
                    cmd.CommandText = "DELETE FROM role WHERE RoleID = @RoleID";
                    con.AddParameter(cmd, "RoleID", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException)
            {

            }
        }
    }
}