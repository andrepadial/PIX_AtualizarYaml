using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIX_GI_AtualizacaoVersao.DAO
{
    public class ConexaoBD
    {
        public string UsuarioSQL { get; set; }
        public string SenhaSQL { get; set; }
        public string ServidorSQL { get; set; }
        public string NomeBancoDados { get; set; }
        public bool IntegratedSecurity { get; set; }

        private List<Entities.ParametroSQL> parametros = new List<Entities.ParametroSQL>();
        private SqlCommand command = new SqlCommand();
        private SqlConnection conexao = new SqlConnection();

        public ConexaoBD()
        {
            this.IntegratedSecurity = true;
        }
        private string StringConexao()
        {
            string ServerName = ServidorSQL;
            string Database = NomeBancoDados;
            string Usuario = UsuarioSQL;
            string Senha = SenhaSQL;

            string connetionString = string.Empty;

            if (!this.IntegratedSecurity)
            {
                connetionString = @"Data Source={0};Initial Catalog={1};User ID={2};Password={3}";
                connetionString = string.Format(connetionString, ServerName, Database, Usuario, Senha);
            }
            else
            {
                connetionString = @"Data Source={0};Initial Catalog={1};Integrated Security=true;";
                connetionString = string.Format(connetionString, ServerName, Database);
            }

            return connetionString;
        }

        private void ParseParametros()
        {
            foreach(var item in parametros)
            {
                SqlParameter sqlParam = new SqlParameter();
                sqlParam.ParameterName = item.Nome;
                sqlParam.Value = item.Valor;

                command.Parameters.Add(sqlParam);
            }

            parametros.Clear();
        }

        public void AdicionarParametro(string nome, object valor)
        {
            Entities.ParametroSQL t = new Entities.ParametroSQL();
            t.Nome = nome;
            t.Valor = valor;

            parametros.Add(t);
        }

        public System.Data.DataTable Execute(string str)
        {
            string strConexao = StringConexao();
            conexao = new SqlConnection(strConexao);

            command = conexao.CreateCommand();

            System.Data.DataTable dt = new System.Data.DataTable();

            dt.PrimaryKey = null;

            try
            {
                conexao.Open();

                command.CommandText = str;
                command.CommandTimeout = 0;
                ParseParametros();
                dt.Load(command.ExecuteReader());

                return dt;

            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                if (conexao.State == System.Data.ConnectionState.Open)
                    conexao.Close();
            }
        }
    }
}
