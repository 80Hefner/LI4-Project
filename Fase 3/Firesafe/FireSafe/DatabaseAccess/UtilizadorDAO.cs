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
            Utilizador u = FindUserByEmail(novoUtilizador.Email);

            if (u == null)
            {
                Connection con = new Connection();

                using (SqlCommand command = con.Fetch().CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO [Utilizador] Values(@username, @password, @email, @telemovel)";

                    command.Parameters.Add("@username", SqlDbType.VarChar).Value = novoUtilizador.Username;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = novoUtilizador.Password;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = novoUtilizador.Email;
                    command.Parameters.Add("@telemovel", SqlDbType.VarChar).Value = novoUtilizador.Telemovel;

                    command.ExecuteScalar();

                    con.Close();
                    return true;
                }
            }

            return false;
        }



        public Utilizador FindUserByEmail (string email)
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

                    if (resultado.Rows.Count > 0)
                    {
                        DataRow linha = resultado.Rows[0];

                        Utilizador utilizador = new Utilizador(
                            int.Parse(linha["Id"].ToString()),
                            linha["Nome"].ToString(),
                            linha["Password"].ToString(),
                            linha["Email"].ToString(),
                            linha["Telemovel"].ToString());

                        List<Localizacao> locFavoritas = null;

                        using (SqlCommand commandFav = con.Fetch().CreateCommand())
                        {
                            commandFav.CommandType = CommandType.Text;
                            commandFav.CommandText = "SELECT * FROM [Favorito] WHERE Utilizador_Id=@Utilizador_Id";

                            commandFav.Parameters.Add("@Utilizador_Id", SqlDbType.Int).Value = utilizador.ID_Utilizador;

                            using (SqlDataAdapter adaptadorFav = new SqlDataAdapter(commandFav))
                            {
                                DataTable resultadoFav = new DataTable();
                                adaptadorFav.Fill(resultadoFav);

                                if (resultadoFav.Rows.Count > 0)
                                {
                                    for (int linhaFav = 0; linhaFav < resultadoFav.Rows.Count; linhaFav++)
                                    {
                                        Localizacao loc = utilizador.LocalizacaoDAO.FindLocById(int.Parse(resultado.Rows[linhaFav]["Id"].ToString()));
                                        locFavoritas.Add(loc);
                                    }
                                }
                            }
                        }

                        utilizador.localizacoesFavoritas = locFavoritas;

                        return utilizador;
                    }

                    con.Close();
                }
            }

            return null;
        }


        public int LoginDAO (String email, String password)
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

                    if (resultado.Rows.Count > 0)
                    {
                        DataRow linha = resultado.Rows[0];

                        id = int.Parse(linha["Id"].ToString());
                    }
                    
                    con.Close();
                }
            }

            return id;
        }
    }
}
