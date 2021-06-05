using System;
using Fase3.DatabseAccess;
using Fase3.Models;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Fase3.DatabseAccess
{
    public class UtilizadorDAO
    {

        public bool insereNovoUtilizador (Utilizador novoUtilizador)
        {
            Utilizador u = findUserByEmail(novoUtilizador.Email);

            if (u == null)
            {
                Connection con = new Connection();

                using (SqlCommand command = con.Fetch().CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO [Utilizador] Values(1, @username, @password, @email, @telemovel)";

                    command.Parameters.Add("@username", SqlDbType.VarChar).Value = novoUtilizador.Nome;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = novoUtilizador.Password;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = novoUtilizador.Email;
                    command.Parameters.Add("@telemovel", SqlDbType.VarChar).Value = novoUtilizador.Telemovel;

                    command.ExecuteScalar();

                    con.close();
                    return true;
                }
            }

            return false;
        }



        public Utilizador findUserByEmail (string email)
        {
            Connection con = new Connection();

            using (SqlCommand command = con.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [Utilizador] WHERE Email=@Email";

                command.Parameters.Add("@Email", SqlDbType.VarChar);
                command.Parameters["@Email"].Value = email;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(command))
                {
                    DataTable resultado = new DataTable();
                    adaptador.Fill(resultado);

                    if (resultado.Rown.Count > 0)
                    {
                        DataRow linha = resultado.Rown[0];

                        Utilizador utilizador = new Utilizador(
                            int.Parse(linha["Id"].ToString()),
                            linha["Nome"].ToString(),
                            linha["Password"].ToString(),
                            linha["Email"].ToString(),
                            linha["Telemovel"].ToString());

                        return utilizador;
                    }

                    con.Close();
                }
            }

            return null;
        }


        public int Login (String email, String password)
        {
            int id = -1;

            Connection con = new Connection();

            using (SqlCommand command = con.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Id FROM [Utilizador] WHERE Email=@Email AND Password=@Password";

                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                command.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(command))
                {
                    DataTable resultado = new DataTable();
                    adaptador.Fill(resultado);

                    if (resultado.Rown.Count > 0)
                    {
                        DataRow linha = resultado.Rown[0];

                        id = int.Parse(linha["Id"].ToString());

                        return utilizador;
                    }
                    
                    con.Close();
                }
            }

        }
    }
}
