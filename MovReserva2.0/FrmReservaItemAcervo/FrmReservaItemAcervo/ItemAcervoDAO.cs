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
	public class ItemAcervoDAO
	{
		private SqlConnection Connection { get; }

		public ItemAcervoDAO(SqlConnection connection)
		{
			Connection = connection;
		}


		public List<ItemAcervoModel> GetItensAcervosDevolver()
		{
			List<ItemAcervoModel> itens = new List<ItemAcervoModel>();
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine("SELECT codItem, nome, numExemplar, tipoItem, localizacao, stts  FROM mvtBiibItemAcervo WHERE stts = 'Reservado' OR stts = 'Emprestado'  ORDER BY codItem");
				command.CommandText = sql.ToString();
				using (SqlDataReader dr = command.ExecuteReader())
				{
					while (dr.Read())
					{
						itens.Add(PopulateDr(dr));
					}
				}
			}
			return itens;
		}
		public List<ItemAcervoModel> GetItensAcervos()
		{
			List<ItemAcervoModel> itens = new List<ItemAcervoModel>();
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine("SELECT codItem, nome, numExemplar, tipoItem, localizacao, stts FROM mvtBiibItemAcervo WHERE stts = 'Disponível' ORDER BY codItem");
				command.CommandText = sql.ToString();
				using (SqlDataReader dr = command.ExecuteReader())
				{
					while (dr.Read())
					{
						itens.Add(PopulateDr(dr));
					}
				}
			}
			return itens;
		}

		public ItemAcervoModel PopulateDr(SqlDataReader dr)
		{
			string codItem = "";
			string nome = "";
			string numExemplar = "";
			string tipoItem = "";
			string localizacao = "";
			string stts = "";


			if (DBNull.Value != dr["codItem"])
			{
				codItem = dr["codItem"] + "";
			}
			if (DBNull.Value != dr["nome"])
			{
				nome = dr["nome"] + "";
			}
			if (DBNull.Value != dr["numExemplar"])
			{
				numExemplar = dr["numExemplar"] + "";
			}
			if (DBNull.Value != dr["tipoItem"])
			{
				tipoItem = dr["tipoItem"] + "";
			}
			if (DBNull.Value != dr["localizacao"])
			{
				localizacao = dr["localizacao"] + "";
			}
			if (DBNull.Value != dr["stts"])
			{
				stts = dr["stts"] + "";
			}


			return new ItemAcervoModel()
			{
				CodItem = codItem,
				NomeItem = nome,
				NumExemplar = numExemplar,
				TipoItem = tipoItem,
				Localizacao = localizacao,
				StatusItem = stts

			};
		}

	}
}