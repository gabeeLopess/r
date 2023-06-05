using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmReservaItemAcervo
{
	public partial class FrmSelecionarItemAcervo : Form
	{
		public string CodItem { get; private set; }
		public string NomeItem { get; private set; }
		public string NumExemplar { get; private set; }
		public string Localizacao { get; private set; }
		public string TipoItem { get; private set; }
		public string devolucao { get; set; }
		public FrmSelecionarItemAcervo()
		{
			InitializeComponent();
		}

		private void CarregarItensgrid()
		{
			gridLayout.Rows.Clear();
			if (devolucao == "Devolver")
			{
				using (SqlConnection connection = DaoConnection.GetConexao())
				{
					ItemAcervoDAO dao = new ItemAcervoDAO(connection);
					List<ItemAcervoModel> itens = dao.GetItensAcervosDevolver();
					foreach (ItemAcervoModel item in itens)
					{
						DataGridViewRow row = gridLayout.Rows[gridLayout.Rows.Add()];
						row.Cells[colCodLeitor.Index].Value = item.CodItem;
						row.Cells[colNomeItem.Index].Value = item.NomeItem;
						row.Cells[colLocalizacao.Index].Value = item.Localizacao;
						row.Cells[colNumExemplar.Index].Value = item.NumExemplar;
						row.Cells[colTipoItem.Index].Value = item.TipoItem;
					}
				}
			}


			else
			{
				using (SqlConnection connection = DaoConnection.GetConexao())
				{
					ItemAcervoDAO dao = new ItemAcervoDAO(connection);
					List<ItemAcervoModel> itens = dao.GetItensAcervos();
					foreach (ItemAcervoModel item in itens)
					{
						DataGridViewRow row = gridLayout.Rows[gridLayout.Rows.Add()];
						row.Cells[colCodLeitor.Index].Value = item.CodItem;
						row.Cells[colNomeItem.Index].Value = item.NomeItem;
						row.Cells[colLocalizacao.Index].Value = item.Localizacao;
						row.Cells[colNumExemplar.Index].Value = item.NumExemplar;
						row.Cells[colTipoItem.Index].Value = item.TipoItem;
					}
				}
			}
		}

		private void gridLayout_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}



		private void FrmSelecionarItemAcervo_Load(object sender, EventArgs e)
		{
			CarregarItensgrid();

        }

		public void Fechar()
		{
			CodItem = txtCodigoItem.Text;
			NomeItem = txtNomeItem.Text;
			Localizacao = txtLocalizacao.Text;
			NumExemplar = txtNumExemplar.Text;
			TipoItem = txtTipoItem.Text;


			this.Close();
		}

		private void gridLayout_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1 && e.ColumnIndex > -1)
			{
				txtCodigoItem.Text = gridLayout.Rows[e.RowIndex].Cells[colCodLeitor.Index].Value + "";
				txtNomeItem.Text = gridLayout.Rows[e.RowIndex].Cells[colNomeItem.Index].Value + "";
				txtLocalizacao.Text = gridLayout.Rows[e.RowIndex].Cells[colLocalizacao.Index].Value + "";
				txtNumExemplar.Text = gridLayout.Rows[e.RowIndex].Cells[colNumExemplar.Index].Value + "";
				txtTipoItem.Text = gridLayout.Rows[e.RowIndex].Cells[colTipoItem.Index].Value + "";


				Fechar();
			}
		}

		private void txtCodigoItem_TextChanged(object sender, EventArgs e)
		{
			string filtro = txtCodigoItem.Text.Trim();

			foreach (DataGridViewRow row in gridLayout.Rows)
			{
				string nome = row.Cells[colCodLeitor.Index].Value.ToString().Trim();
				bool exibir = nome.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0;
				row.Visible = exibir;
			}
		}

		private void txtNomeItem_TextChanged_1(object sender, EventArgs e)
		{
			string filtro = txtNomeItem.Text.Trim();

			foreach (DataGridViewRow row in gridLayout.Rows)
			{
				string nome = row.Cells[colNomeItem.Index].Value.ToString().Trim();
				bool exibir = nome.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0;
				row.Visible = exibir;
			}

		}

		private void txtLocalizacao_TextChanged_1(object sender, EventArgs e)
		{
			string filtro = txtLocalizacao.Text.Trim();

			foreach (DataGridViewRow row in gridLayout.Rows)
			{
				string nome = row.Cells[colLocalizacao.Index].Value.ToString().Trim();
				bool exibir = nome.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0;
				row.Visible = exibir;
			}
		}
		private void txtNumExemplar_TextChanged(object sender, EventArgs e)
		{
			string filtro = txtNumExemplar.Text.Trim();

			foreach (DataGridViewRow row in gridLayout.Rows)
			{
				string nome = row.Cells[colNumExemplar.Index].Value.ToString().Trim();
				bool exibir = nome.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0;
				row.Visible = exibir;
			}
		}

		private void txtTipoItem_TextChanged(object sender, EventArgs e)
		{
			string filtro = txtTipoItem.Text.Trim();

			foreach (DataGridViewRow row in gridLayout.Rows)
			{
				string nome = row.Cells[colTipoItem.Index].Value.ToString().Trim();
				bool exibir = nome.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0;
				row.Visible = exibir;
			}

		}
	}

		
}
