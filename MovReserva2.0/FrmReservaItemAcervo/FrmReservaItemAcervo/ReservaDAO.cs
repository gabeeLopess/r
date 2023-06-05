using FrmReservaItemAcervo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmReservaItemAcervo
{
	public class ReservaDAO
	{
		private SqlConnection Connection { get; }
		public ReservaDAO(SqlConnection connection)
		{
			Connection = connection;
		}
		public void Editar(ReservaModel reserva, ItemAcervoModel itemAcervo, LeitorModel leitor)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{
				SqlTransaction t = Connection.BeginTransaction();
				try
				{
					StringBuilder sql = new StringBuilder();
					sql.AppendLine($"UPDATE MvTbiibReservaa SET situacao = @situacao, tipoMovimento = @tipoMovimento, prazoReservs = @prazoReservs" +
						$" WHERE codItem = @codItem AND codLeitor = @codLeitor");
					command.CommandText = sql.ToString();
					command.Parameters.Add(new SqlParameter("@situacao", itemAcervo.StatusItem));
					command.Parameters.Add(new SqlParameter("@tipoMovimento", reserva.TipoMovimento));
					command.Parameters.Add(new SqlParameter("@prazoReservs", reserva.PrazoReserva));
					command.Parameters.Add(new SqlParameter("@codItem", itemAcervo.CodItem));
					command.Parameters.Add(new SqlParameter("@codLeitor", leitor.CodLeitor));
					command.Transaction = t;
					command.ExecuteNonQuery();
					t.Commit();
				}
				catch (Exception ex)
				{
					t.Rollback();
					throw ex;
				}
			}
		}
			public void Salvar(ReservaModel reserva, ItemAcervoModel Item, LeitorModel Leitor)
			{	
			using (SqlCommand command = Connection.CreateCommand())
			{
				SqlTransaction t = Connection.BeginTransaction();
				try
				{
					StringBuilder sql = new StringBuilder();
					sql.AppendLine($"INSERT INTO MvTbiibReservaa(codItem, situacao, nomeItem, numExemplar, tipoItem, localizacao, codLeitor, nomeLeitor, dataReserva, prazoReservs, tipoMovimento) VALUES(@codItem, @situacao, @nomeItem, @numExemplar, @tipoItem, @localizacao, @codLeitor, @nomeLeitor, @dataReserva, @prazoReservs, @tipoMovimento)");
					command.CommandText = sql.ToString();
					command.Parameters.Add(new SqlParameter("@codItem", Item.CodItem));
					command.Parameters.Add(new SqlParameter("@situacao", Item.StatusItem));
					command.Parameters.Add(new SqlParameter("@nomeItem", Item.NomeItem));
					command.Parameters.Add(new SqlParameter("@numExemplar", Item.NumExemplar));
					command.Parameters.Add(new SqlParameter("@tipoItem", Item.TipoItem));
					command.Parameters.Add(new SqlParameter("@localizacao", Item.Localizacao));
					command.Parameters.Add(new SqlParameter("@codLeitor", Leitor.CodLeitor));
					command.Parameters.Add(new SqlParameter("@nomeLeitor", Leitor.NomeLeitor));
					command.Parameters.Add(new SqlParameter("@dataReserva", reserva.DataReserva));
					command.Parameters.Add(new SqlParameter("@prazoReservs", reserva.PrazoReserva));
					command.Parameters.Add(new SqlParameter("@tipoMovimento", reserva.TipoMovimento));
					command.Transaction = t;
					command.ExecuteNonQuery();
					t.Commit();
				}

				catch (Exception ex)
				{
					t.Rollback();
					throw ex;
				}
			}
		}
		public void AtualizaItemAcervo(ItemAcervoModel itemAcervo)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{
				SqlTransaction t = Connection.BeginTransaction();
				try
				{
					StringBuilder sql = new StringBuilder();
					sql.AppendLine($"UPDATE mvtBiibItemAcervo SET stts = @situacao WHERE codItem = @codItem");
					command.CommandText = sql.ToString();
					command.Parameters.Add(new SqlParameter("@situacao", itemAcervo.StatusItem));
					command.Parameters.Add(new SqlParameter("@codItem", itemAcervo.CodItem));
					command.Transaction = t;
					command.ExecuteNonQuery();
					t.Commit();
				}
				catch (Exception ex)
				{
					t.Rollback();
					throw ex;
				}
			}
		}
		public bool Validacao(ReservaModel reserva, ItemAcervoModel itemAcervo, LeitorModel leitor)
		{
			
			if (string.IsNullOrEmpty(itemAcervo.CodItem) || string.IsNullOrWhiteSpace(itemAcervo.CodItem))
			{
				MessageBox.Show("Informe o campo Codigo Item", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (string.IsNullOrEmpty(leitor.CodLeitor) || string.IsNullOrWhiteSpace(leitor.CodLeitor))
			{
				MessageBox.Show("Informe o campo Codigo Leitor", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (string.IsNullOrEmpty(reserva.DataReserva) || string.IsNullOrWhiteSpace(reserva.DataReserva))
			{
				MessageBox.Show("Informe o campo Data reserva", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (string.IsNullOrEmpty(reserva.PrazoReserva) || string.IsNullOrWhiteSpace(reserva.PrazoReserva))
			{
				MessageBox.Show("Informe o campo Prazo Reserva", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			DateTime dataReserva = Convert.ToDateTime(reserva.DataReserva);
			DateTime prazoReserva = Convert.ToDateTime(reserva.PrazoReserva);

			if (prazoReserva < dataReserva)
			{
				MessageBox.Show("O prazo de devolução é anterior ao de retirada.");
				return false;
			}

			return true;
		}
	
		public bool VerificaEmprestimo(ItemAcervoModel itemAcervo, ReservaModel reserva)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{

				StringBuilder sql = new StringBuilder();
				sql.AppendLine($"select stts from mvtBiibItemAcervo where codItem = @codItem");
				command.CommandText = sql.ToString();
				command.Parameters.AddWithValue("@codItem", itemAcervo.CodItem);
				string result = Convert.ToString(command.ExecuteScalar());

				if (result == "Reservado")
				{
					if (result == "Reservado" && reserva.TipoMovimento == "Devolver")
					{
						return true;
					}
					else
					{
						MessageBox.Show("O item do acervo já está reservado!");
						return false;
					}
				}
				else if (result == "Emprestado")
				{
					if (result == "Emprestado" && reserva.TipoMovimento == "Devolver")
					{
						return true;
					}
					else
					{
						MessageBox.Show("O item do acervo já está emprestado!");
						return false;
					}
				}
				else
				{
					return true;
				}
			}
		}
		public int Verificacao(ItemAcervoModel Item, LeitorModel leitor)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine($"SELECT COUNT(codItem) FROM MvTbiibReservaa WHERE codItem = @codItem");
				command.CommandText = sql.ToString();
				command.Parameters.AddWithValue("@codItem", Item.CodItem);
				int count = Convert.ToInt32(command.ExecuteScalar());
				return count;
			}
		}
		public string GetLeitorAuto(ItemAcervoModel Item)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine($"SELECT nomeLeitor FROM MvTbiibReservaa WHERE  situacao = 'Reservado' OR situacao  = 'Emprestado'  and codItem = @codItem");
				command.CommandText = sql.ToString();
				command.Parameters.AddWithValue("@codItem", Item.CodItem);
				string result = Convert.ToString(command.ExecuteScalar());

				if (result != null)
				{
					return result.ToString();
				}
			}
			return string.Empty;
		}
		public string GetCodLeitorAuto(ItemAcervoModel Item)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine($"SELECT codLeitor FROM MvTbiibReservaa WHERE  situacao = 'Reservado' OR situacao  = 'Emprestado'  and codItem = @codItem");
				command.CommandText = sql.ToString();
				command.Parameters.AddWithValue("@codItem", Item.CodItem);
				string result = Convert.ToString(command.ExecuteScalar());

				if (result != null)
				{
					return result.ToString();
				}
			}
			return string.Empty;
		}
		public string GetNomeLeitor(LeitorModel leitor)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine($"SELECT nomeLeitor FROM MvTbiibReservaa WHERE  codLeitor = @codLeitor");
				command.CommandText = sql.ToString();
				command.Parameters.AddWithValue("@codLeitor", leitor.CodLeitor);
				string result = Convert.ToString(command.ExecuteScalar());

				if (result != null)
				{
					return result.ToString();
				}
			}
			return string.Empty;
		}
		public string GetNomeItem(ItemAcervoModel item)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine($"SELECT nomeItem FROM MvTbiibReservaa WHERE codItem = @codItem");
				command.CommandText = sql.ToString();
				command.Parameters.AddWithValue("@codItem", item.CodItem);
				string result = Convert.ToString(command.ExecuteScalar());

				if (result != null)
				{
					return result.ToString();
				}
			}
			return string.Empty;
		}
		public string GetNumExemplar(ItemAcervoModel item)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine($"SELECT numExemplar FROM mvtBiibItemAcervo WHERE codItem = @codItem");
				command.CommandText = sql.ToString();
				command.Parameters.AddWithValue("@codItem", item.CodItem);
				string result = Convert.ToString(command.ExecuteScalar());

				if (result != null)
				{
					return result.ToString();
				}
			}
			return string.Empty;
		}
		public string GetTipoItem(ItemAcervoModel item)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine($"SELECT tipoItem FROM mvtBiibItemAcervo WHERE codItem = @codItem");
				command.CommandText = sql.ToString();
				command.Parameters.AddWithValue("@codItem", item.CodItem);
				string result = Convert.ToString(command.ExecuteScalar());

				if (result != null)
				{
					return result.ToString();
				}
			}
			return string.Empty;
		}
		public string GetLocalizacao(ItemAcervoModel item)
		{
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine($"SELECT nomeLocal FROM mvtBiibItemAcervo WHERE codItem = @codItem");
				command.CommandText = sql.ToString();
				command.Parameters.AddWithValue("@codItem", item.CodItem);
				string result = Convert.ToString(command.ExecuteScalar());

				if (result != null)
				{
					return result.ToString();
				}
			}
			return string.Empty;
		}
		public List<ReservaModel> GetReservas()
		{
			List<ReservaModel> reservas = new List<ReservaModel>();
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine("SELECT codItem, situacao, nomeItem, numExemplar, tipoItem, localizacao, codLeitor,");
				sql.AppendLine("nomeLeitor, dataReserva, prazoReservs, tipoMovimento FROM MvTbiibReservaa ORDER BY codItem");
				command.CommandText = sql.ToString();
				using (SqlDataReader dr = command.ExecuteReader())
				{
					while (dr.Read())
					{
						reservas.Add(PopulateDrReserva(dr));
					}
				}
			}
			return reservas;
		}
	
		public ReservaModel PopulateDrReserva(SqlDataReader dr)
		{
			string dataReserva = "";
			string prazoReserva = "";
			string tipoMovimento = "";
			string stts = "";
			LeitorModel codLeitor = null;
			ItemAcervoModel codItem = null;

			if (DBNull.Value != dr["dataReserva"])
			{
				dataReserva = dr["dataReserva"] + "";
			}
			if (DBNull.Value != dr["prazoReservs"])
			{
				prazoReserva = dr["prazoReservs"] + "";
			}
			if (DBNull.Value != dr["tipoMovimento"])
			{
				tipoMovimento = dr["tipoMovimento"] + "";
			}
			
			if (DBNull.Value != dr["codLeitor"])
			{
				string leitorCod = dr["codLeitor"] + "";
				string nomeLeitor = dr["nomeLeitor"] + "";
				codLeitor = new LeitorModel()
				{
					CodLeitor = leitorCod,
					NomeLeitor = nomeLeitor
				};
			}
			if (DBNull.Value != dr["codItem"])
			{
				string itemCod = dr["codItem"] + "";
				string sttsItem = dr["situacao"] + "";
				string nomeItem = dr["nomeItem"] + "";
				string numExemplar = dr["numExemplar"] + "";
				string tipoItem = dr["tipoItem"] + "";
				string localizacao = dr["localizacao"] + "";
				codItem = new ItemAcervoModel()
				{
					CodItem = itemCod,
					NomeItem = nomeItem,
					NumExemplar = numExemplar,
					TipoItem = tipoItem,
					Localizacao = localizacao,
					StatusItem = sttsItem
				};
			}

			return new ReservaModel()
			{
				DataReserva = dataReserva,
				PrazoReserva = prazoReserva,
				TipoMovimento = tipoMovimento,

				LeitorModel = codLeitor,
				ItemAcervoModel = codItem,
			
			};
		}

	}
}


