using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmReservaItemAcervo
{

	internal class LeitorDAO
	{
		private SqlConnection Connection { get; }

		public LeitorDAO(SqlConnection connection)
		{
			Connection = connection;
		}

		public List<LeitorModel> GetLeitores()
		{
			List<LeitorModel> leitores = new List<LeitorModel>();
			using (SqlCommand command = Connection.CreateCommand())
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendLine("SELECT codLeitor, leitor FROM MvtBIBLeitor");
				command.CommandText = sql.ToString();
				using (SqlDataReader dr = command.ExecuteReader())
				{
					while (dr.Read())
					{
						leitores.Add(populateDr(dr));
					}
				}
			}
			return leitores;

		}


		private LeitorModel populateDr(SqlDataReader dr)
		{
			string codLeitor = "";
			string nomeLeitor = "";

			if (DBNull.Value != dr["codLeitor"])
			{
				codLeitor = dr["codLeitor"] + "";
			}
			if (DBNull.Value != dr["leitor"])
			{
				nomeLeitor = dr["leitor"] + "";
			}

			return new LeitorModel()
			{

				CodLeitor = codLeitor,
				NomeLeitor = nomeLeitor,


			};
		}
	}
}
