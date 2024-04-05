using System;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;


namespace PIX_GI_AtualizacaoVersao
{
    public partial class frmVersaoAPI : Form
    {
        Entities.TelaDados telaDados;
        string myExeDir = string.Empty;
        string arquivoDados = "historico.xml";
        


        public frmVersaoAPI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myExeDir = new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString();
            CarregarTela();
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SalvarTela();
        }

        private bool IsYAML(string arquivo)
        {
            return true;
            //TODO
        }


        private void btnGerarVersao_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                telaDados.caminhoArquivos = txtCaminho.Text;
                if (!telaDados.caminhoArquivos.EndsWith(@"\"))
                    telaDados.caminhoArquivos += @"\";

                GerarNovaVersao();
                CarregarDataGridHistorico();
            }
            catch (Exception ex)
            {

                throw;
            }

            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void SalvarTela()
        {
            SerializarObjetoTela();
        }

        private void GerarNovaVersao()
        {
            Entities.Historico novo = CapturarNovosValoresPreenchidos();
            telaDados.historicos.Add(novo);
            telaDados.listaAPIsPadrao = novo;
            CorrerTodasAPIs();
        }

        private void CorrerTodasAPIs()
        {

            foreach (var item in telaDados.listaAPIsPadrao.detalhesVersao)
            {
                EditarArquivo(telaDados.caminhoArquivos + @"DEV\app\" + item.NomeArquivo, item.Versao);
                EditarArquivo(telaDados.caminhoArquivos + @"HMG\app\" + item.NomeArquivo, item.Versao);
                EditarArquivo(telaDados.caminhoArquivos + @"PROD\app\" + item.NomeArquivo, item.Versao);
            }
        }

        private bool PosicaoLinhaDaImagem(string linha, out int posicao)
        {
            int posicaoImage = linha.IndexOf("image:");
            if (posicaoImage > 0)
            {
                posicao = posicaoImage + "image:".Length;
                return true;
            }

            posicao = 0;
            return false;

        }

        private void EditarArquivo(string arquivo, string versao)
        {
            if (!System.IO.File.Exists(arquivo))
                return;

            string[] linhas = System.IO.File.ReadAllLines(arquivo);
            List<string> final = new List<string>();

            int quantidadeLinhaEditada = 0; //não pode ter mais de 1.

            foreach (string linha in linhas)
            {
                string novaLinha = linha;
                int posicao = 0;
                if (PosicaoLinhaDaImagem(novaLinha, out posicao))
                {
                    novaLinha = linha.Substring(0, linha.IndexOf(":", posicao)) + ":" + versao;
                    quantidadeLinhaEditada++;
                }

                final.Add(novaLinha);
            }

            if (quantidadeLinhaEditada > 1)
                throw new Exception(string.Format("Só pode editar uma linha com a palavra 'image:'. Arquivo {0} tem {1}.", arquivo, quantidadeLinhaEditada));

            System.IO.File.Delete(arquivo);
            WriteAllLinesBetter(arquivo, final.ToArray());
        }

        public static void WriteAllLinesBetter(string path, params string[] lines)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            if (lines == null)
                throw new ArgumentNullException("lines");

            using (var stream = File.OpenWrite(path))
            {
                stream.SetLength(0);
                using (var writer = new StreamWriter(stream))
                {
                    if (lines.Length > 0)
                    {
                        for (var i = 0; i < lines.Length - 1; i++)
                        {
                            writer.WriteLine(lines[i]);
                        }
                        writer.Write(lines[lines.Length - 1]);
                    }
                }
            }
        }

        private Entities.Historico CapturarNovosValoresPreenchidos()
        {
            Entities.Historico novaVersao = new Entities.Historico();

            for (int i = 0; i < dgvNovaVersao.Rows.Count; i++)
            {
                if (dgvNovaVersao.Rows[i].IsNewRow)
                    break;

                novaVersao.detalhesVersao.Add(
                    new Entities.DetalheVersao
                    {
                        APIName = dgvNovaVersao.Rows[i].Cells[0].Value.ToString(),
                        Versao = dgvNovaVersao.Rows[i].Cells[1].Value.ToString(),
                        NomeArquivo = dgvNovaVersao.Rows[i].Cells[2].Value.ToString()
                    });
            }

            novaVersao.dataAtualizacao = System.DateTime.Now;
            novaVersao.NomeVersao = txtNovaVersao.Text;

            return novaVersao;
        }

        private void CarregarTela()
        {
            CarregarDataGridNovaVersaoColuna();
            CarregarDataGridHistoricoColuna();
            DeserealizarObjetoTela();
            
            if(telaDados != null && telaDados.listaAPIsPadrao != null && telaDados.listaAPIsPadrao.detalhesVersao != null)
                CarregarDataGridNovaVersao(telaDados.listaAPIsPadrao.detalhesVersao);
            
            CarregarDataGridHistorico();
            txtCaminho.Text = telaDados.caminhoArquivos;
        }

        private void CarregarDataGridHistorico()
        {
            dgvHistorico.Rows.Clear();
            foreach(var item in telaDados.historicos)
            {
                dgvHistorico.Rows.Add(item.NomeVersao, item.dataAtualizacao.ToString("dd/MM/yyyy"), item.dataAtualizacao);
            }
        }

        private void CarregarDataGridNovaVersao(List<Entities.DetalheVersao> detalhesVersao)
        {
            dgvNovaVersao.Rows.Clear();
            foreach(var item in detalhesVersao)
            {
                dgvNovaVersao.Rows.Add(item.APIName, item.Versao, item.NomeArquivo);
            }
        }

        private void CarregarDataGridNovaVersaoColuna()
        {
            dgvNovaVersao.Columns.Add("APINome", "API");
            dgvNovaVersao.Columns.Add("APIVersao", "Versão");
            dgvNovaVersao.Columns.Add("NomeArquivo", "Arquivo");
        }

        private void CarregarDataGridHistoricoColuna()
        {
            dgvHistorico.Columns.Add("APIVersao", "Versão");
            dgvHistorico.Columns.Add("DataAtualizacao", "dtAtualizacao");
            dgvHistorico.Columns.Add("dtReferencia", "dtRefrencia");

            dgvHistorico.Columns[2].Visible = false;
        }



        private void DeserealizarObjetoTela()
        {
            if (!System.IO.File.Exists(myExeDir + @"\" + arquivoDados))
            {
                CriarVersao0ArquivoTelaDados();
                return;
            }


            XmlSerializer xs = new XmlSerializer(typeof(Entities.TelaDados));

            using (FileStream fileStream = new FileStream(myExeDir + @"\" + arquivoDados, FileMode.Open))
            {
                telaDados = (Entities.TelaDados)xs.Deserialize(fileStream);
            }
        }

        private void SerializarObjetoTela()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Entities.TelaDados));
            TextWriter txtWriter = new StreamWriter(myExeDir + @"\" + arquivoDados);
            xs.Serialize(txtWriter, telaDados);
            txtWriter.Close();
        }

        private void CriarVersao0ArquivoTelaDados()
        {
            telaDados = new Entities.TelaDados();
            telaDados.caminhoArquivos = @"c:\temp\";

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao { 
                    APIName = "api-gerenciador-conta-pi", 
                    NomeArquivo = "api-gerenciador-conta-pi.yaml", 
                    Versao = "" });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-gerenciador-conta-pi-consulta",
                    NomeArquivo = "api-gerenciador-conta-pi-consulta.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo",
                    NomeArquivo = "api-pagamento-instantaneo.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-contabilidade",
                    NomeArquivo = "api-pagamento-instantaneo-contabilidade.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-ebank",
                    NomeArquivo = "api-pagamento-instantaneo-ebank.yaml",
                    Versao = ""
                });


            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-enderecamento",
                    NomeArquivo = "api-pagamento-instantaneo-enderecamento.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-envio-icom",
                    NomeArquivo = "api-pagamento-instantaneo-envio-icom.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-extracao",
                    NomeArquivo = "api-pagamento-instantaneo-extracao.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-infobank",
                    NomeArquivo = "api-pagamento-instantaneo-infobank.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-mensagens",
                    NomeArquivo = "api-pagamento-instantaneo-mensagens.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-metricas",
                    NomeArquivo = "api-pagamento-instantaneo-metricas.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-polling-dict",
                    NomeArquivo = "api-pagamento-instantaneo-polling-dict.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-polling-icom",
                    NomeArquivo = "api-pagamento-instantaneo-polling-icom.yaml",
                    Versao = ""
                });
            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-processos-automaticos",
                    NomeArquivo = "api-pagamento-instantaneo-processos-automaticos.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-qrcode",
                    NomeArquivo = "api-pagamento-instantaneo-qrcode.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-rendafixa",
                    NomeArquivo = "api-pagamento-instantaneo-rendafixa.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-spi",
                    NomeArquivo = "api-pagamento-instantaneo-spi.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-tratamento-falha",
                    NomeArquivo = "api-pagamento-instantaneo-tratamento-falha.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-processamento-icom",
                    NomeArquivo = "api-pagamento-processamento-icom.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "front-web-gerenciador-conta-pi",
                    NomeArquivo = "front-web-gerenciador-conta-pi.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-batch",
                    NomeArquivo = "api-pagamento-instantaneo-batch.yaml",
                    Versao = ""
                });

            telaDados.listaAPIsPadrao.detalhesVersao.Add(
                new Entities.DetalheVersao
                {
                    APIName = "api-pagamento-instantaneo-sincronismo",
                    NomeArquivo = "api-pagamento-instantaneo-sincronismo.yaml",
                    Versao = ""
                });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Teste();
            if (IsYAML(textBox1.Text))
                MessageBox.Show("sim");
            else
                MessageBox.Show("não");
        }

        private void Teste()
        {
            var source = new[]
                        {
                            new { from = new DateTime(2019, 1, 10), to = new DateTime(2019, 1, 12) },
                            new { from = new DateTime(2019, 3, 10), to = new DateTime(2019, 3, 14) },
                            new { from = new DateTime(2019, 1, 12), to = new DateTime(2019, 1, 13) },
                        };

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
                                a[a.Count - 1] = new { from = a.Last().from, to = x.to };
                            }
                            else
                            {
                                a.Add(x);
                            }
                            return a;
                        });
        }

        private void dgvHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            object selected = dgvHistorico.Rows[e.RowIndex].Cells[2].Value;
            DateTime dtReferencia = Convert.ToDateTime(selected);

            foreach(var item in telaDados.historicos)
            {
                if(item.dataAtualizacao == dtReferencia)
                {
                    CarregarDataGridNovaVersao(item.detalhesVersao);
                }
            }
        }
    }



}
