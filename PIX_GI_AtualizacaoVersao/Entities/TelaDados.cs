using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIX_GI_AtualizacaoVersao.Entities
{
    public class TelaDados
    {
        public string caminhoArquivos { get; set; }
        public List<Historico> historicos { get; set; }
        public Historico listaAPIsPadrao { get; set; }

        public TelaDados()
        {
            listaAPIsPadrao = new Historico();
            historicos = new List<Historico>();
        }
    }
}
