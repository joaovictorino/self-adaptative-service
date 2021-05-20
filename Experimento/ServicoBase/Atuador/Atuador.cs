using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicoBase
{
    public class Atuador : IAtuador
    {
        public void setarContainer(DadosAtuacao dados)
        {
            if (dados.Usuario == "Joao")
            {
                Application.setarValor(dados.NomeContainer);
            }
        }
    }
}
