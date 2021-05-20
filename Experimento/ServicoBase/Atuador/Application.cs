using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicoBase
{
    public static class Application
    {
        private static string _valor = string.Empty;

        public static void setarValor(string valor)
        {
            _valor = valor;
        }

        public static string obterValor()
        {
            if (string.IsNullOrEmpty(_valor))
            {
                _valor = System.Configuration.ConfigurationManager.AppSettings["containerDefault"];
            }

            return _valor;
        }
    }
}
