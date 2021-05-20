using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicoBase.Monitoracao
{
    public interface IContador
    {
        void GravarEntrada(string id, DateTime dataInicio, string area);
        void GravarSaida(string id, DateTime dataFim, TimeSpan tempoRequisicao);
        void GravarInfra(float cpu, float memoria, DateTime dataAtual);
    }
}
