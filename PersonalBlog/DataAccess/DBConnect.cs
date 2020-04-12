using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace PersonalBlog.DataAccess
{
    public class DBConnect
    {
        public readonly IDbConnection connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        public void AddParameter(IDbCommand command, string name, object value)
        {
            IDbDataParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@" + name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
    }
}