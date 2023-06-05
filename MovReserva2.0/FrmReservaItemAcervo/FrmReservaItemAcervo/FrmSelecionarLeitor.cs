using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmReservaItemAcervo
{
	public partial class FrmSelecionarLeitor : Form
	{
		public string Codleitor { get; private set; }
		public string NomeLeitor { get; private set; }

		public FrmSelecionarLeitor()
		{
			InitializeComponent();
		}

		private void CarregarLeitoresgrid()
		{
			gridLayout.Rows.Clear();
			using (SqlConnection connection = DaoConnection.GetConexao())
			{
				LeitorDAO dao = new LeitorDAO(connection);
				List<LeitorModel> leitores = dao.GetLeitores();
				foreach (LeitorModel leitor in leitores)
				{
					DataGridViewRow row = gridLayout.Rows[gridLayout.Rows.Add()];
					row.Cells[colCodLeitor.Index].Value = leitor.CodLeitor;
					row.Cells[colNomeLeitor.Index].Value = leitor.NomeLeitor;
				}
			}
		}

		private void FrmSelecionarLeitor_Load(object sender, EventArgs e)
		{
			CarregarLeitoresgrid();
		}

		public void Fechar()
		{
			Codleitor = txtCodigoLeitor.Text;
			NomeLeitor = txtNomeLeitor.Text;

			this.Close();
		}

		private void gridLayout_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			

		}



		private void txtCodigoLeitor_TextChanged(object sender, EventArgs e)
		{
			string filtro = txtCodigoLeitor.Text.Trim();

			foreach (DataGridViewRow row in gridLayout.Rows)
			{
				string codLeitor = row.Cells[colCodLeitor.Index].Value.ToString().Trim();
				bool exibir = codLeitor.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0;
				row.Visible = exibir;
			}

		}

		private void txtNomeLeitor_TextChanged(object sender, EventArgs e)
		{
			string filtro = txtNomeLeitor.Text.Trim();

			foreach (DataGridViewRow row in gridLayout.Rows)
			{
				string nomeLeitor = row.Cells[colNomeLeitor.Index].Value.ToString().Trim();
				bool exibir = nomeLeitor.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0;
				row.Visible = exibir;
			}
		}

        private void gridLayout_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                txtCodigoLeitor.Text = gridLayout.Rows[e.RowIndex].Cells[colCodLeitor.Index].Value + "";
                txtNomeLeitor.Text = gridLayout.Rows[e.RowIndex].Cells[colNomeLeitor.Index].Value + "";
                Fechar();
            }
        }
    }
}
