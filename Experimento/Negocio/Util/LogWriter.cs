using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Util
{
    public static class LogWriter
    {
        public static void Escrever(string mensagem)
        {
            LogEntry logEntry = new LogEntry();

            try
            {
                Logger.SetLogWriter(new LogWriterFactory().Create());
            }
            catch
            {
            }

            logEntry.EventId = 100;
            logEntry.Priority = 2;
            logEntry.Categories.Add("General");
            logEntry.Message = mensagem;
            Logger.Write(logEntry);

        }
    }
}
