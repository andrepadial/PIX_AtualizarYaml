using PIX_GI_AtualizacaoVersao.DAO.Interfaces;
using PIX_GI_AtualizacaoVersao.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PIX_GI_AtualizacaoVersao.DAO
{
    public class HistoricoVersaoAutbankAutbankDao : IHistoricoVersaoAutbankDao
    {
        public string Conexao { get; set; }


        private void SetarConexao()
        {
            this.Conexao = ConfigurationManager.ConnectionStrings["ConexaoDB"].ConnectionString;
        }

        public HistoricoVersaoAutbankAutbankDao()
        {
            SetarConexao();
        }

        public void Atualizar(HistoricoVersaoAutbank HistoricoVersaoAutbank)
        {
            throw new NotImplementedException();
        }

        public List<HistoricoVersaoAutbank> Consultar()
        {
            throw new NotImplementedException();
        }

        public List<HistoricoVersaoAutbank> Consultar(string versaoAutbank)
        {
            SqlConnection conn = new SqlConnection(this.Conexao);
            List<HistoricoVersaoAutbank> historicos = new List<HistoricoVersaoAutbank>();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                conn.Close();
            }

            return historicos;
        }

        public void Excluir(HistoricoVersaoAutbank HistoricoVersaoAutbank)
        {
            throw new NotImplementedException();
        }

        public void Incluir(HistoricoVersaoAutbank HistoricoVersaoAutbank)
        {
            throw new NotImplementedException();
        }

        public List<HistoricoVersaoAutbank> ConsultarAPI()
        {
            throw new NotImplementedException();
        }

        public List<HistoricoVersaoAutbank> ConsultarAPI(string versaoAutbank)
        {
            throw new NotImplementedException();
        }

        public void IncluirHistoricoAPI(List<HistoricoVersaoAutbank> HistoricoVersaoAutbank)
        {
            throw new NotImplementedException();
        }

        public void AtualizarHistoricoAPI(List<HistoricoVersaoAutbank> HistoricoVersaoAutbank)
        {
            throw new NotImplementedException();
        }

        public void ExcluirHistoricoAPI(List<HistoricoVersaoAutbank> HistoricoVersaoAutbank)
        {
            throw new NotImplementedException();
        }
    }
}
