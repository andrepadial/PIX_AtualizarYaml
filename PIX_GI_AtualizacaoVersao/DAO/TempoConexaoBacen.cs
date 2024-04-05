using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIX_GI_AtualizacaoVersao.DAO
{
    public class TempoConexaoBacen
    {
        private ConexaoBD objBD = new ConexaoBD();
        public TempoConexaoBacen()
        {
            objBD.ServidorSQL = "SQLAUTBANK";
            objBD.NomeBancoDados = "AB_PAGAMENTO_INSTANTANEO";
        }

        public List<Entities.Registro> Pesquisar(DateTime dateDe, DateTime dateAte)
        {
            string select = DAO.Querys.ConexaoBACEN.SelectSaudeConexaoBACEN;

            try
            {
                objBD.AdicionarParametro("@datInicio", dateDe);
                objBD.AdicionarParametro("@datFim", dateAte);

                
                System.Data.DataTable dt = objBD.Execute(select);


                List<Entities.Registro> retorno = new List<Entities.Registro>();

                foreach(System.Data.DataRow dr in dt.Rows)
                {
                    Entities.Registro temp = new Entities.Registro();
                    temp.from = Convert.ToDateTime(dr["DATA_HORA_BACEN"]);
                    temp.to = Convert.ToDateTime(dr["DATA_HORA_REGISTRO"]);

                    retorno.Add(temp);
                }

                return retorno;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
    