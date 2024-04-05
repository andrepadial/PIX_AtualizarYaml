using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIX_GI_AtualizacaoVersao.Model
{
    public class Versao
    {
        public string VersaoAutbank { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public List<ItemVersao> Itens { get; set; }

    }
}
