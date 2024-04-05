using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIX_GI_AtualizacaoVersao
{
    public partial class frmDisponibilidade : Form
    {
        public frmDisponibilidade()
        {
            InitializeComponent();
        }

        private void frmDisponibilidade_Load(object sender, EventArgs e)
        {
            dtInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime datInicio = dtInicio.Value.Date;
            DateTime datFim = dtFim.Value.Date.AddDays(1).AddMilliseconds(-1);

            try
            {
                this.Cursor = Cursors.WaitCursor;
                Manager.SaudeConexaoBACEN saudeConexaoBACEN = new Manager.SaudeConexaoBACEN();
                List<Entities.Registro> registro = saudeConexaoBACEN.ProcessarSaudeConexaoBACEN(datInicio, datFim);

                foreach (var item in registro)
                {
                    textBox1.Text += item.from.ToString("dd/MM/yyyy HH:mm:ss.fff") + "\t" + item.to.ToString("dd/MM/yyyy HH:mm:ss.fff") + Environment.NewLine;
                }
            }
            catch (Exception)
            {

                throw;
            }

            finally
            {
                this.Cursor = Cursors.Default;
            }


        }

        private Entities.Registro[] Carregar()
        {
            List<Entities.Registro> ts = new List<Entities.Registro>();

            DateTime dt = System.DateTime.Now;
            DateTime dt1 = System.DateTime.Now;

            for (int i = 0; i < 2000000; i++)
            {
                dt1 = dt.AddSeconds(1);
                ts.Add(new Entities.Registro { from = dt, to = dt1 });
                dt = dt1.AddSeconds(1);
            }

            return ts.ToArray();
        }

        private void Teste()
        {

            var source = Carregar();

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

        }

    }


}
