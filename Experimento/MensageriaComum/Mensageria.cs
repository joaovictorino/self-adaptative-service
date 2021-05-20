using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Messaging;

namespace MensageriaComum
{
    public static class Mensageria
    {
        public static void Enviar(string nomeFila, object valor) 
        {
            DecisaoServico.AnalisarDadosClient analisar = new DecisaoServico.AnalisarDadosClient();
            analisar.Analisar((int)valor);

        }

        public static object Receber(string nomeFila) 
        {
            MessageQueue MQueue = new MessageQueue(nomeFila);

            ((XmlMessageFormatter)MQueue.Formatter).TargetTypes = new Type[] { typeof(string) };

            try
            {
                Message mensagem = MQueue.Receive(new TimeSpan(0, 0, 1));

                return mensagem.Body;
            }
            catch
            {
                return null;
            }
        }
    }
}
