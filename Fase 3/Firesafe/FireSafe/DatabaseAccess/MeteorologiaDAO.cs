using FireSafe.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FireSafe.DatabaseAccess
{
    public class MeteorologiaDAO
    {
        public Meteorologia FindMeteoById(int id)
        {
            Meteorologia meteorologia = null;

            Connection con = new Connection();

            using (SqlCommand command = con.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [Meteorologia] WHERE Id=@Id";

                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(command))
                {
                    DataTable resultado = new DataTable();
                    adaptador.Fill(resultado);

                    if (resultado.Rows.Count > 0)
                    {
                        DataRow linha = resultado.Rows[0];

                        meteorologia = new Meteorologia(
                            int.Parse(linha["Id"].ToString()),
                            float.Parse(linha["Temp_atual"].ToString()),
                            float.Parse(linha["Temp_min"].ToString()),
                            float.Parse(linha["Temp_max"].ToString()),
                            float.Parse(linha["Vento_vel"].ToString()),
                            linha["Vento_dir"].ToString(),
                            int.Parse(linha["Humidade"].ToString()),
                            int.Parse(linha["Pressao_atm"].ToString()),
                            linha["Estado"].ToString());
                    }

                    con.Close();
                }
            }

            return meteorologia;
        }
    }
}
