using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Data.SqlClient;
using System.Data;

namespace CustomActivity
{
    public class RunSQLStmt : CodeActivity
    {
        [RequiredArgument]
        public InArgument<string> connectionString { get; set; }
        [RequiredArgument]
        public InArgument<string> SQLStatement { get; set; }
        public OutArgument<DataRow[]> data { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString.Get<string>(context)))
            {
                SqlCommand command = new SqlCommand(SQLStatement.Get<string>(context), connection);
                SqlDataAdapter da = new SqlDataAdapter(command);

                try
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataRow[] linhas = new DataRow[ds.Tables[0].Rows.Count];
                    ds.Tables[0].Rows.CopyTo(linhas, 0);
                    data.Set(context, linhas);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
