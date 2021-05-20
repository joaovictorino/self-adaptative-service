using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Raven.Client.Document;
using Raven.Client;
using Negocio.Util;

namespace ServicoBase.Monitoracao
{
    public class Contador : IContador
    {
        public void GravarEntrada(string id, DateTime dataInicio, string area)
        {
            string conexao = @"Data Source=JOAO-PC;Initial Catalog=Experimento;Persist Security Info=True;User ID=sa;Password=joao";

            string comandoInsertEntrada = @"INSERT INTO RequisicaoEntrada VALUES (@Id, @Container, @DataInicio, @Area);";

            using (SqlConnection conn = new SqlConnection(conexao)) 
            {
                SqlCommand cmd = new SqlCommand(comandoInsertEntrada, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Container", Application.obterValor());
                cmd.Parameters.AddWithValue("@DataInicio", dataInicio);
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

        public void GravarSaida(string id, DateTime dataFim, TimeSpan tempoRequisicao)
        {
            string conexao = @"Data Source=JOAO-PC;Initial Catalog=Experimento;Persist Security Info=True;User ID=sa;Password=joao";

            string comandoInsertEntrada = @"INSERT INTO RequisicaoSaida VALUES (@Id, @DataFim, @Duracao);";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand(comandoInsertEntrada, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@DataFim", dataFim);
                cmd.Parameters.AddWithValue("@Duracao", tempoRequisicao);

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

        public void GravarInfra(float cpu, float memoria, DateTime dataAtual)
        {
            string conexao = @"Data Source=JOAO-PC;Initial Catalog=Experimento;Persist Security Info=True;User ID=sa;Password=joao";

            string comandoInsertEntrada = @"INSERT INTO DadosMaquina VALUES (@cpu, @memoria, @data);";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                SqlCommand cmd = new SqlCommand(comandoInsertEntrada, conn);
                cmd.Parameters.AddWithValue("@cpu", cpu);
                cmd.Parameters.AddWithValue("@memoria", memoria);
                cmd.Parameters.AddWithValue("@data", dataAtual);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
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
