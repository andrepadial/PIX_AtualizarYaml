using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIX_GI_AtualizacaoVersao.Entities
{
    public class Historico
    {
        public string NomeVersao { get; set; }
        public DateTime dataAtualizacao { get; set; }

        public List<Entities.DetalheVersao> detalhesVersao { get; set; }

        public Historico()
        {
            this.detalhesVersao = new List<DetalheVersao>();
        }
    }
}
