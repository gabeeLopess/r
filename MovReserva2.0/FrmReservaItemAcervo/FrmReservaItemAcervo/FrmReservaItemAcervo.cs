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
	public partial class FrmReservaItemAcervo : Form
	{
		public FrmReservaItemAcervo()
		{
			InitializeComponent();
		}

		public void SelecionarItens()
		{
			FrmSelecionarItemAcervo selecionar = new FrmSelecionarItemAcervo();
			selecionar.devolucao = cbxTipoMovimento.Text;
			selecionar.ShowDialog();
			txtCodigoItem.Text = selecionar.CodItem;
			txtNomeItem.Text = selecionar.NomeItem;
			txtLocalizacao.Text = selecionar.Localizacao;
			txtNumExemplar.Text = selecionar.NumExemplar;
			txtTipoItem.Text = selecionar.TipoItem;

		}
		public void SelecionarLeitor()
		{
			FrmSelecionarLeitor selecionar = new FrmSelecionarLeitor();
			selecionar.ShowDialog();
			txtCodLeitor.Text = selecionar.Codleitor;
			txtNomeLeitor.Text = selecionar.NomeLeitor;

		}

		private void CarregarReservasItensgrid()
		{
			gridLayout.Rows.Clear();
			using (SqlConnection connection = DaoConnection.GetConexao())
			{
				ReservaDAO dao = new ReservaDAO(connection);
				List<ReservaModel> reservas = dao.GetReservas();
				foreach (ReservaModel reserva in reservas)
				{
					DataGridViewRow row = gridLayout.Rows[gridLayout.Rows.Add()];
					row.Cells[colCodItem.Index].Value = reserva.ItemAcervoModel.CodItem;
					row.Cells[colNomeItem.Index].Value = reserva.ItemAcervoModel.NomeItem;
					row.Cells[colLeitor.Index].Value = reserva.LeitorModel.NomeLeitor;
					row.Cells[colSitucao.Index].Value = reserva.ItemAcervoModel.StatusItem;
					row.Cells[colLocalizacao.Index].Value = reserva.ItemAcervoModel.Localizacao;
					row.Cells[colTipoItem.Index].Value = reserva.ItemAcervoModel.TipoItem;
					row.Cells[colNumExemplar.Index].Value = reserva.ItemAcervoModel.NumExemplar;
					row.Cells[colTipoMovimento.Index].Value = reserva.TipoMovimento;
					row.Cells[colCodLeitor.Index].Value = reserva.LeitorModel.CodLeitor;
					row.Cells[colDataReserva.Index].Value = reserva.DataReserva.Substring(0, 10);
					row.Cells[colDataRetorno.Index].Value = reserva.PrazoReserva.Substring(0, 10);
				}
			}
		}
		private void lblSelecionarItemAcervo_Click(object sender, EventArgs e)
		{


		}

		private void FrmReservaItemAcervo_Load(object sender, EventArgs e)
		{
			CarregarReservasItensgrid();
		}

		private void cbxSituacao_SelectedIndexChanged(object sender, EventArgs e)
		{
		
		}
		public void Limpar()
		{
			txtCodigoItem.Text = "";
			txtNumExemplar.Text = "";
			txtLocalizacao.Text = "";
			txtNomeItem.Text = "";
			txtTipoItem.Text = "";
			txtCodLeitor.Text = "";
			txtNomeLeitor.Text = "";
			cbxSituacao.SelectedIndex = -1;
			cbxTipoMovimento.SelectedIndex = -1;
			dtpDataReserva.Text = null;
			dtpPrazoReserva.Text = null;
		}
		private void cbxTipoMovimento_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbxTipoMovimento.Text == "Empréstimo")
			{
				cbxSituacao.SelectedIndex = 1;
				dtpDataReserva.Enabled = true;
				dtpPrazoReserva.Enabled = true;
				txtCodigoItem.ReadOnly = false;
				txtCodLeitor.ReadOnly = false;
				btnSelecionarLeitor.Enabled = true;
			}
			else
			{
				cbxSituacao.SelectedIndex = 0;
				txtCodigoItem.ReadOnly = true;
				txtCodLeitor.ReadOnly = true;
				dtpDataReserva.Enabled = false;
			
			}
		}
		private void btnSelecionarItemAcervo_Click(object sender, EventArgs e)
		{
			SelecionarItens();
		}

		private void btnSelecionarLeitor_Click(object sender, EventArgs e)
		{
			SelecionarLeitor();
		}

		private void btnSalvar_Click(object sender, EventArgs e)
		{
			try
			{
				using (SqlConnection connection = DaoConnection.GetConexao())
				{
					ReservaDAO dao = new ReservaDAO(connection);

					bool verificaCampos = dao.Validacao(new ReservaModel()
					{
						DataReserva = dtpDataReserva.Value.Date.ToString(),
						PrazoReserva = dtpPrazoReserva.Value.Date.ToString()
					}, new ItemAcervoModel()
					{
						CodItem = txtCodigoItem.Text,
						NomeItem = txtNomeItem.Text,
						NumExemplar = txtNumExemplar.Text,
						TipoItem = txtTipoItem.Text,
						Localizacao = txtLocalizacao.Text
					}, new LeitorModel()
					{
						CodLeitor = txtCodLeitor.Text,
						NomeLeitor = txtNomeLeitor.Text
					});

					if (verificaCampos)
					{
						string movimento = cbxTipoMovimento.Text;
						bool verificaEmprestimo = dao.VerificaEmprestimo(new ItemAcervoModel()
						{
							CodItem = txtCodigoItem.Text
						}, new ReservaModel()
						{
							TipoMovimento = movimento
						});

						if (verificaEmprestimo)
						{
							int count = dao.Verificacao(new ItemAcervoModel()
							{
								CodItem = txtCodigoItem.Text
							}, new LeitorModel()
							{
								CodLeitor = txtCodLeitor.Text
							});

							if (count > 0)
							{
								dao.Editar(new ReservaModel()
								{
									TipoMovimento = cbxTipoMovimento.Text,
									PrazoReserva = dtpPrazoReserva.Value.Date.ToString()
								}, new ItemAcervoModel()
								{
									StatusItem = cbxSituacao.Text,
									CodItem = txtCodigoItem.Text
								}, new LeitorModel()
								{
									CodLeitor = txtCodLeitor.Text
								});
								if (movimento == "Devolver")
								{
									dao.AtualizaItemAcervo(new ItemAcervoModel()
									{
										StatusItem = "Disponível",
										CodItem = txtCodigoItem.Text
									});
								}
								else
								{
									dao.AtualizaItemAcervo(new ItemAcervoModel()
									{
										StatusItem = "Emprestado",
										CodItem = txtCodigoItem.Text
									});
								}
							}
							else
							{
								dao.Salvar(new ReservaModel()
								{
									DataReserva = dtpDataReserva.Value.Date.ToString(),
									PrazoReserva = dtpPrazoReserva.Value.Date.ToString(),
									TipoMovimento = cbxTipoMovimento.Text
								}, new ItemAcervoModel()
								{
									CodItem = txtCodigoItem.Text,
									NomeItem = txtNomeItem.Text,
									NumExemplar = txtNumExemplar.Text,
									TipoItem = txtTipoItem.Text,
									Localizacao = txtLocalizacao.Text,
									StatusItem = cbxSituacao.Text
								}, new LeitorModel()
								{
									CodLeitor = txtCodLeitor.Text,
									NomeLeitor = txtNomeLeitor.Text
								});

								if (movimento == "Devolver")
								{
									dao.AtualizaItemAcervo(new ItemAcervoModel()
									{
										StatusItem = "Disponível",
										CodItem = txtCodigoItem.Text
									});
								}
								else
								{
									dao.AtualizaItemAcervo(new ItemAcervoModel()
									{
										StatusItem = "Emprestado",
										CodItem = txtCodigoItem.Text
									});
								}
							}
							if (movimento == "Devolver")
							{
								MessageBox.Show("Item do acervo Devolvido!");
							}
							else if (movimento == "Empréstimo")
							{
								MessageBox.Show("Empréstimo realizado com sucesso!");
							}
							else
							{
								MessageBox.Show("Reserva realizada com sucesso!");
							}
							Limpar();
						}
					}
				}
				CarregarReservasItensgrid();
				dtpDataReserva.Enabled = true;
				dtpDataReserva.Enabled = true;
				txtCodigoItem.ReadOnly = false;
				txtCodLeitor.ReadOnly = false;
				btnSelecionarItemAcervo.Enabled = true;
				btnSelecionarLeitor.Enabled = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Houve um problema ao realizar a reserva!\n{ex.Message}");
			}
		}

	
		private void btnLimpar_Click(object sender, EventArgs e)
		{
			Limpar();
			btnLimpar.Enabled = false;
			btnSalvar.Enabled = true;
			cbxTipoMovimento.Enabled = true;
			dtpDataReserva.Enabled = true;
			dtpPrazoReserva.Enabled = true;
			txtCodigoItem.ReadOnly = false;
			txtCodLeitor.ReadOnly = false;
			btnSelecionarItemAcervo.Enabled = true;
			btnSelecionarLeitor.Enabled = true;
		}

		private void txtCodigoItem_TextChanged(object sender, EventArgs e)
		{

			if (cbxTipoMovimento.Text == "Devolver")
			{
				using (SqlConnection connection = DaoConnection.GetConexao())
				{
					ReservaDAO dao = new ReservaDAO(connection);
					txtNomeLeitor.Text = dao.GetLeitorAuto(new ItemAcervoModel()
					{
						CodItem = txtCodigoItem.Text
					});
					txtCodLeitor.Text = dao.GetCodLeitorAuto(new ItemAcervoModel()
					{
						CodItem = txtCodigoItem.Text
					});

				}
			}
		}

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

		private void gridLayout_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex > -1 && e.ColumnIndex > -1)
			{
				txtCodigoItem.Text = gridLayout.Rows[e.RowIndex].Cells[colCodItem.Index].Value + "";
				txtNomeItem.Text = gridLayout.Rows[e.RowIndex].Cells[colNomeItem.Index].Value + "";
				cbxSituacao.Text = gridLayout.Rows[e.RowIndex].Cells[colSitucao.Index].Value + "";
				txtLocalizacao.Text = gridLayout.Rows[e.RowIndex].Cells[colLocalizacao.Index].Value + "";
				txtTipoItem.Text = gridLayout.Rows[e.RowIndex].Cells[colTipoItem.Index].Value + "";
				txtNumExemplar.Text = gridLayout.Rows[e.RowIndex].Cells[colNumExemplar.Index].Value + "";
				txtCodLeitor.Text = gridLayout.Rows[e.RowIndex].Cells[colCodLeitor.Index].Value + "";
				txtNomeLeitor.Text = gridLayout.Rows[e.RowIndex].Cells[colLeitor.Index].Value + "";
				cbxTipoMovimento.Text = gridLayout.Rows[e.RowIndex].Cells[colTipoMovimento.Index].Value + "";
				dtpDataReserva.Text = gridLayout.Rows[e.RowIndex].Cells[colDataReserva.Index].Value + "";
				dtpPrazoReserva.Text = gridLayout.Rows[e.RowIndex].Cells[colDataRetorno.Index].Value + "";
				
			}
			btnLimpar.Enabled = true;
			btnSalvar.Enabled = false;
			cbxTipoMovimento.Enabled = false;
			dtpDataReserva.Enabled = false;
			dtpPrazoReserva.Enabled = false;
			txtCodigoItem.ReadOnly = true;
			txtCodLeitor.ReadOnly = true;
			btnSelecionarItemAcervo.Enabled = false;
			btnSelecionarLeitor.Enabled = false;
			
		}
	}
	
}