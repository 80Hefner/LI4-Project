using System;
using Fase3.DatabseAccess;
using Fase3.Models;
using System.Data.SqlClient;

namespace Fase3.DatabseAccess
{
    public class Connection
    {
        private SqlConnection _connection;

        public Connection()
        {
            // tourette
            //_connection = new SqlConnection("Server=DESKTOP-EQMTRE4;Database=Firesafe;Trusted_Connection=True;");
            
            // hefner
            _connection = new SqlConnection("Server=DESKTOP-EH1Q2CR;Database=Firesafe;Trusted_Connection=True;");  
        }

        public void Close()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlConnection Fetch()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                return _connection;
            }
            else
            {
                return this.Open();
            }
        }

        public SqlConnection Open()
        {
            _connection.Open();
            return _connection;
        }

    }

}