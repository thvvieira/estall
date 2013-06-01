using PCLEStall.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EStall.Helpers
{
    public class QueryHelper
    {
        public static Func<SqlDataReader, IEnumerable<Profile>> ReaderToObject
        {
            get
            {
                return (reader) =>
                {
                    List<Profile> returnValue = new List<Profile>();
                    while (reader.Read())
                    {
                        returnValue.Add(new Profile()
                        {
                            Handle = ConvertHelper.To<Int32>(reader["HANDLE"]),
                            DataAdmissao = ConvertHelper.To<DateTime>(reader["DATAADMISSAO"]),
                            DataNascimento = ConvertHelper.To<DateTime>(reader["DATANASCIMENTO"]),
                            Nome = ConvertHelper.To<string>(reader["NOME"]),
                            TipoColaborador = ConvertHelper.To<Int32>(reader["TIPOCOLABORADOR"]),
                            Viaja = ConvertHelper.To<bool>(reader["VIAJA"].ToString()),
                            Imagem = ConvertHelper.To<byte[]>(reader["IMAGEM"])
                        });
                    }
                    return returnValue;
                };
            }

        }
    }
}