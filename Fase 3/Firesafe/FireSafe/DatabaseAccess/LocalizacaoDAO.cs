using FireSafe.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FireSafe.DatabaseAccess
{
    public class LocalizacaoDAO
    {

        public Localizacao FindLocById(int id)
        {
            Localizacao loc = null;

            Connection con = new Connection();

            using (SqlCommand command = con.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [Localizacao] WHERE Id=@Id";

                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(command))
                {
                    DataTable resultado = new DataTable();
                    adaptador.Fill(resultado);

                    if (resultado.Rows.Count > 0)
                    {
                        DataRow linha = resultado.Rows[0];

                        loc = new Localizacao(
                            int.Parse(linha["Id"].ToString()),
                            linha["Freguesia"].ToString(),
                            linha["Concelho"].ToString(),
                            linha["Distrito"].ToString());
                    }

                    con.Close();
                }
            }

            return loc;
        }
        public Localizacao FindLocByStrings (string freguesia, string concelho, string distrito)
        {
            Localizacao loc = null;

            Connection con = new Connection();

            using (SqlCommand command = con.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [Localizacao] WHERE Freguesia=@Freguesia AND Concelho=@Concelho AND Distrito=@Distrito";

                command.Parameters.Add("@Freguesia", SqlDbType.VarChar).Value = freguesia;
                command.Parameters.Add("@Concelho", SqlDbType.VarChar).Value = concelho;
                command.Parameters.Add("@Distrito", SqlDbType.VarChar).Value = distrito;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(command))
                {
                    DataTable resultado = new DataTable();
                    adaptador.Fill(resultado);

                    if (resultado.Rows.Count > 0)
                    {
                        DataRow linha = resultado.Rows[0];

                        loc = new Localizacao(
                            int.Parse(linha["Id"].ToString()),
                            linha["Freguesia"].ToString(),
                            linha["Concelho"].ToString(),
                            linha["Distrito"].ToString());
                    }

                    con.Close();
                }
            }

            return loc;
        }
    }
}
