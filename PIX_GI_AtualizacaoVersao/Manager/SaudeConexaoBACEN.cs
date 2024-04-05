using PIX_GI_AtualizacaoVersao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIX_GI_AtualizacaoVersao.Manager
{
    public class SaudeConexaoBACEN
    {
        const int _ERRO_DTINICIO_MAIOR_DTFIM = -1;

        private DateTime dtInicio;
        private DateTime dtFim;

        DAO.TempoConexaoBacen bacen = new DAO.TempoConexaoBacen();

        public int ToleranciaTempo { get; set; }

        public List<Entities.MensagemRetorno> MensagemRetorno { get; set; }

        public SaudeConexaoBACEN()
        {
            MensagemRetorno = new List<Entities.MensagemRetorno>();
            ToleranciaTempo = 10000;
        }

        public List<Entities.Registro> ProcessarSaudeConexaoBACEN(DateTime dtDe, DateTime dtAte)
        {
            dtInicio = dtDe;
            dtFim = dtAte;

            //Faz as validações dos parametros informado
            if (ValidarFalha())
                return null;



            List<Entities.Registro> registro = bacen.Pesquisar(dtDe, dtAte);

            List<Entities.Registro> registrosOk = new List<Entities.Registro>();
            List<Entities.Registro> registrosFalha = new List<Entities.Registro>();

            SepararRegistrosOK_Falhas(registro, out registrosOk, out registrosFalha);

            List<Entities.Registro> retorno = AgruparRegistrosIntervalo(registrosFalha);

            return retorno;
        }

        private List<Entities.Registro> AgruparRegistrosIntervalo(List<Entities.Registro> registroFalha)
        {
            var source = registroFalha.ToArray();

            var data =
                source
                    .OrderBy(x => x.from)
                    .ThenBy(x => x.to)
                    .ToArray();

            var results =
                data
                    .Skip(1)
                    .Aggregate(
                        data.Take(1).ToList(),
                        (a, x) =>
                        {
                            if (a.Last().to >= x.from)
                            {
                                a[a.Count - 1] = new Entities.Registro { from = a.Last().from, to = new DateTime(Math.Max(x.to.Ticks, a.Last().to.Ticks)) };
                            }
                            else
                            {
                                a.Add(x);
                            }

                            return a;
                        });

            List<Entities.Registro> retorno = results.OfType<Entities.Registro>().ToList();

            return retorno;
        }

        private void SepararRegistrosOK_Falhas(List<Registro> registro, out List<Registro> OKs, out List<Registro> Falhas)
        {
            List<Entities.Registro> registrosOk = new List<Entities.Registro>();
            List<Entities.Registro> registrosFalha = new List<Entities.Registro>();

            foreach (var item in registro)
            {
                ///Horario do bacen é em GMT.
                item.from = item.from.ToLocalTime();
                TimeSpan ts = item.to - item.from;

                if (ts.TotalMilliseconds > ToleranciaTempo)
                    registrosFalha.Add(item);
                else
                    registrosOk.Add(item);
            }

            OKs = registrosOk;
            Falhas = registrosFalha;
        }

        private bool ValidarFalha()
        {
            bool existeErro = false;

            if(dtInicio > dtFim)
            {
                MensagemRetorno.Add(new Entities.MensagemRetorno
                {
                    Codigo = _ERRO_DTINICIO_MAIOR_DTFIM,
                    Descricao = string.Format("A data de Inicio informada ({0}) é maior que a data final ({1}).",
                    dtInicio.ToString("dd/MM/yyyy HH:mm:ss.fff"), dtFim.ToString("dd/MM/yyyy HH:mm:ss.fff"))
                });
                existeErro = true;
            }

            return existeErro;
        }
    }
}
