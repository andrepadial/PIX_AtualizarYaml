using PIX_GI_AtualizacaoVersao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIX_GI_AtualizacaoVersao.DAO.Interfaces
{
    public interface IHistoricoVersaoAutbankDao
    {
        List<HistoricoVersaoAutbank> Consultar();
        List<HistoricoVersaoAutbank> Consultar(string versaoAutbank);
        void Incluir(HistoricoVersaoAutbank HistoricoVersaoAutbank);
        void Atualizar(HistoricoVersaoAutbank HistoricoVersaoAutbank);
        void Excluir(HistoricoVersaoAutbank HistoricoVersaoAutbank);

        List<HistoricoVersaoAutbank> ConsultarAPI();
        List<HistoricoVersaoAutbank> ConsultarAPI(string versaoAutbank);
        void IncluirHistoricoAPI(List<HistoricoVersaoAutbank> HistoricoVersaoAutbank);
        void AtualizarHistoricoAPI(List<HistoricoVersaoAutbank> HistoricoVersaoAutbank);
        void ExcluirHistoricoAPI(List<HistoricoVersaoAutbank> HistoricoVersaoAutbank);


    }
}
