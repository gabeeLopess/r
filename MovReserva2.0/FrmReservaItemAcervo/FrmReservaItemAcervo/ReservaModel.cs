using FrmReservaItemAcervo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmReservaItemAcervo
{
	[Table("mvtBibReserva")]
	public class ReservaModel
	{
		
		public string TipoMovimento { get; set; }
		public string DataReserva { get; set; }
		public string PrazoReserva { get; set; }
		public string Situacao { get; set; }

		[ForeignKey("mvtBiibItemAcervo")]
		[Column("codItem")]
		public string IdItem { get; set; }
		public virtual ItemAcervoModel ItemAcervoModel { get; set; }

		[ForeignKey("MvtBIBLeitor")]
		[Column("codLeitor")]
		public string IdLeitor { get; set; }
		public virtual LeitorModel LeitorModel { get; set; }

	}
}

