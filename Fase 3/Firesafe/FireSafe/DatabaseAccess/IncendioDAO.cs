using Fase3.DatabseAccess;
using Fase3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FireSafe.DatabaseAccess
{
    public class IncendioDAO
    {
        public Incendio FindIncendioByCoordenadas(float latitude, float longitude)
        {
            Incendio incendio = null;

            Connection con = new Connection();

            using (SqlCommand command = con.Fetch().CreateCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM [Localizacao] WHERE Latitude=@Latitude AND Longitude=@Longitude";

                command.Parameters.Add("@Latitude", SqlDbType.Float).Value = latitude;
                command.Parameters.Add("@Longitude", SqlDbType.Float).Value = longitude;

                using (SqlDataAdapter adaptador = new SqlDataAdapter(command))
                {
                    DataTable resultado = new DataTable();
                    adaptador.Fill(resultado);

                    if (resultado.Rows.Count > 0)
                    {
                        DataRow linha = resultado.Rows[0];

                        incendio = new Incendio(
                            int.Parse(linha["Id"].ToString()),
                            int.Parse(linha["Meios_humanos"].ToString()),
                            int.Parse(linha["Meios_terrestres"].ToString()),
                            int.Parse(linha["Meios_aereos"].ToString()),
                            float.Parse(linha["Latitude"].ToString()),
                            float.Parse(linha["Longitude"].ToString()),
                            int.Parse(linha["Estado"].ToString()),
                            DateTime.Parse(linha["Inicio"].ToString()),
                            DateTime.Parse(linha["Fim"].ToString()));

                        incendio.localizacao = incendio.LocalizacaoDAO.FindLocById(int.Parse(linha["Localizacao_Id"].ToString()));
                        incendio.meteorologia = incendio.MeteorologiaDAO.FindMeteoById(int.Parse(linha["Meteorologia_Id"].ToString()));
                    }

                    con.Close();
                }
            }

            return incendio;
        }

    }
}
