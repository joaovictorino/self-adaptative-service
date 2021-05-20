using Negocio.Aspectos;
using Negocio.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.DAO
{
    public class FilaDAO
    {

        public void Gravar(String mensagem, String area) 
        {
            string conexao = @"Data Source=JOAO-PC;Initial Catalog=Experimento;Persist Security Info=True;User ID=sa;Password=joao";

            string comandoInsertEntrada = @"INSERT INTO FilaRequisicao(Conteudo, Situacao, Area) VALUES (@Conteudo, @Situacao, @Area);";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand(comandoInsertEntrada, conn);
                cmd.Parameters.AddWithValue("@Conteudo", mensagem);
                cmd.Parameters.AddWithValue("@Situacao", 1);
                cmd.Parameters.AddWithValue("@Area", area);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch(Exception ex) 
                {
                    LogWriter.Escrever(ex.Message);
                    LogWriter.Escrever(ex.StackTrace);

                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                        LogWriter.Escrever(ex.Message);
                        LogWriter.Escrever(ex.StackTrace);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        
        }

    }
}
