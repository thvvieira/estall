using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EStall.Querys
{
    public class ProfileQuerys
    {
        public static string GetProfileByName(string name = "")
        {
            StringBuilder commandSql = new StringBuilder();
            commandSql.AppendLine(" SELECT ");
            commandSql.AppendLine("    HANDLE, ");
            commandSql.AppendLine("    NOME, ");
            commandSql.AppendLine("    DATANASCIMENTO, ");
            commandSql.AppendLine("    DATAADMISSAO, ");
            commandSql.AppendLine("    TIPOSANGUE, ");
            commandSql.AppendLine("    VIAJA, ");
            commandSql.AppendLine("    TIPOCOLABORADOR, ");
            commandSql.AppendLine("    IMAGEM ");
            commandSql.AppendLine(" FROM ");
            commandSql.AppendLine("    DO_FUNCIONARIOS ");
            if (!string.IsNullOrEmpty(name))
            {
                commandSql.AppendLine(" WHERE ");
                commandSql.AppendLine("    HANDLE = ");
                commandSql.AppendLine("        (SELECT ");
                commandSql.AppendLine("                 FUNCIONARIO ");
                commandSql.AppendLine("           FROM ");
                commandSql.AppendLine("                 DO_FUNCIONARIOQUIOSQUE ");
                commandSql.AppendLine("           WHERE ");
                commandSql.AppendLine("                 GRUPOUSUARIO =");
                commandSql.AppendLine("                            (SELECT      ");
                commandSql.AppendLine("                                    HANDLE");
                commandSql.AppendLine("                             FROM");
                commandSql.AppendLine("                                    Z_GRUPOUSUARIOS");
                commandSql.AppendLine("                             WHERE");
                commandSql.AppendFormat("                                    APELIDO = '{0}'", name.Replace(" ", "."));
                commandSql.AppendLine();
                commandSql.AppendLine("                             )");
                commandSql.AppendLine("          )");
            }
            return commandSql.ToString();
        }

        public static string GetEmployeersByProfile(string name)
        {
            StringBuilder commandSql = new StringBuilder();
            commandSql.AppendLine(" SELECT HANDLE, NOME, DATANASCIMENTO, DATAADMISSAO, TIPOSANGUE, VIAJA, TIPOCOLABORADOR, IMAGEM      ");
            commandSql.AppendLine("  FROM DO_FUNCIONARIOS                                                                              ");
            commandSql.AppendLine(" WHERE HANDLE IN (SELECT FUNCIONARIO                                                                ");
            commandSql.AppendLine("                    FROM DO_FUNCIONARIOQUIOSQUE                                                     ");
            commandSql.AppendLine("                   WHERE GRUPOUSUARIO IN (SELECT RESPONSAVEL                                        ");
            commandSql.AppendLine("                                            FROM SUP_SUPERVISORES                                   ");
            commandSql.AppendLine("                                           WHERE TIPO = 1                                           ");
            commandSql.AppendLine("                                                 AND ESTRUTURA LIKE                                 ");
            commandSql.AppendLine("                                                 (                                                  ");
            commandSql.AppendLine("                                                     SELECT ESTRUTURA + '.%'                        ");
            commandSql.AppendLine("                                                            FROM SUP_SUPERVISORES                   ");
            commandSql.AppendLine("                                                           WHERE RESPONSAVEL =                      ");
            commandSql.AppendLine("                                                                 (                                  ");
            commandSql.AppendLine("                                                                     SELECT HANDLE                  ");
            commandSql.AppendLine("                                                                            FROM Z_GRUPOUSUARIOS    ");
            commandSql.AppendFormat("                                                                           WHERE APELIDO = '{0}' ", name.Replace(" ", "."));
            commandSql.AppendLine();
            commandSql.AppendLine("                                                                         )                          ");
            commandSql.AppendLine("                                                                     AND TIPO = 1                   ");
            commandSql.AppendLine("                                                                 )                                  ");
            commandSql.AppendLine("                                                         )                                          ");
            commandSql.AppendLine("                                                 )                       ");

            return commandSql.ToString();
        }


    }
}