namespace FrmReservaItemAcervo
{
	partial class FrmSelecionarItemAcervo
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblNomeLeitor = new System.Windows.Forms.Label();
			this.txtNomeItem = new System.Windows.Forms.TextBox();
			this.txtCodigoItem = new System.Windows.Forms.TextBox();
			this.lblCodigoItem = new System.Windows.Forms.Label();
			this.gridLayout = new System.Windows.Forms.DataGridView();
			this.lblNumExemplar = new System.Windows.Forms.Label();
			this.txtNumExemplar = new System.Windows.Forms.TextBox();
			this.lblTipoItem = new System.Windows.Forms.Label();
			this.lblLocalizacao = new System.Windows.Forms.Label();
			this.txtLocalizacao = new System.Windows.Forms.TextBox();
			this.txtTipoItem = new System.Windows.Forms.TextBox();
			this.colCodLeitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNomeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNumExemplar = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTipoItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colLocalizacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridLayout)).BeginInit();
			this.SuspendLayout();
			// 
			// lblNomeLeitor
			// 
			this.lblNomeLeitor.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblNomeLeitor.AutoSize = true;
			this.lblNomeLeitor.Location = new System.Drawing.Point(5, 45);
			this.lblNomeLeitor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblNomeLeitor.Name = "lblNomeLeitor";
			this.lblNomeLeitor.Size = new System.Drawing.Size(72, 16);
			this.lblNomeLeitor.TabIndex = 29;
			this.lblNomeLeitor.Text = "Nome Item";
			// 
			// txtNomeItem
			// 
			this.txtNomeItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtNomeItem.Location = new System.Drawing.Point(130, 42);
			this.txtNomeItem.Margin = new System.Windows.Forms.Padding(4);
			this.txtNomeItem.Name = "txtNomeItem";
			this.txtNomeItem.ReadOnly = true;
			this.txtNomeItem.Size = new System.Drawing.Size(498, 22);
			this.txtNomeItem.TabIndex = 28;
			this.txtNomeItem.TextChanged += new System.EventHandler(this.txtNomeItem_TextChanged_1);
			// 
			// txtCodigoItem
			// 
			this.txtCodigoItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtCodigoItem.Location = new System.Drawing.Point(130, 6);
			this.txtCodigoItem.Margin = new System.Windows.Forms.Padding(4);
			this.txtCodigoItem.Name = "txtCodigoItem";
			this.txtCodigoItem.ReadOnly = true;
			this.txtCodigoItem.Size = new System.Drawing.Size(267, 22);
			this.txtCodigoItem.TabIndex = 27;
			this.txtCodigoItem.TextChanged += new System.EventHandler(this.txtCodigoItem_TextChanged);
			// 
			// lblCodigoItem
			// 
			this.lblCodigoItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblCodigoItem.AutoSize = true;
			this.lblCodigoItem.Location = new System.Drawing.Point(5, 12);
			this.lblCodigoItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCodigoItem.Name = "lblCodigoItem";
			this.lblCodigoItem.Size = new System.Drawing.Size(51, 16);
			this.lblCodigoItem.TabIndex = 26;
			this.lblCodigoItem.Text = "Código";
			// 
			// gridLayout
			// 
			this.gridLayout.AllowUserToAddRows = false;
			this.gridLayout.AllowUserToDeleteRows = false;
			this.gridLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridLayout.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gridLayout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gridLayout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCodLeitor,
            this.colNomeItem,
            this.colNumExemplar,
            this.colTipoItem,
            this.colLocalizacao});
			this.gridLayout.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.gridLayout.Location = new System.Drawing.Point(8, 197);
			this.gridLayout.Margin = new System.Windows.Forms.Padding(4);
			this.gridLayout.Name = "gridLayout";
			this.gridLayout.ReadOnly = true;
			this.gridLayout.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.gridLayout.RowHeadersWidth = 51;
			this.gridLayout.Size = new System.Drawing.Size(620, 312);
			this.gridLayout.TabIndex = 25;
			this.gridLayout.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLayout_CellContentClick);
			this.gridLayout.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLayout_CellDoubleClick);
			// 
			// lblNumExemplar
			// 
			this.lblNumExemplar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblNumExemplar.AutoSize = true;
			this.lblNumExemplar.Location = new System.Drawing.Point(5, 84);
			this.lblNumExemplar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblNumExemplar.Name = "lblNumExemplar";
			this.lblNumExemplar.Size = new System.Drawing.Size(95, 16);
			this.lblNumExemplar.TabIndex = 30;
			this.lblNumExemplar.Text = "Num Exemplar";
			// 
			// txtNumExemplar
			// 
			this.txtNumExemplar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtNumExemplar.Location = new System.Drawing.Point(130, 78);
			this.txtNumExemplar.Margin = new System.Windows.Forms.Padding(4);
			this.txtNumExemplar.Name = "txtNumExemplar";
			this.txtNumExemplar.ReadOnly = true;
			this.txtNumExemplar.Size = new System.Drawing.Size(498, 22);
			this.txtNumExemplar.TabIndex = 31;
			this.txtNumExemplar.TextChanged += new System.EventHandler(this.txtNumExemplar_TextChanged);
			// 
			// lblTipoItem
			// 
			this.lblTipoItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblTipoItem.AutoSize = true;
			this.lblTipoItem.Location = new System.Drawing.Point(5, 118);
			this.lblTipoItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTipoItem.Name = "lblTipoItem";
			this.lblTipoItem.Size = new System.Drawing.Size(63, 16);
			this.lblTipoItem.TabIndex = 32;
			this.lblTipoItem.Text = "Tipo Item";
			// 
			// lblLocalizacao
			// 
			this.lblLocalizacao.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblLocalizacao.AutoSize = true;
			this.lblLocalizacao.Location = new System.Drawing.Point(5, 157);
			this.lblLocalizacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblLocalizacao.Name = "lblLocalizacao";
			this.lblLocalizacao.Size = new System.Drawing.Size(80, 16);
			this.lblLocalizacao.TabIndex = 34;
			this.lblLocalizacao.Text = "Localização";
			// 
			// txtLocalizacao
			// 
			this.txtLocalizacao.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtLocalizacao.Location = new System.Drawing.Point(130, 154);
			this.txtLocalizacao.Margin = new System.Windows.Forms.Padding(4);
			this.txtLocalizacao.Name = "txtLocalizacao";
			this.txtLocalizacao.ReadOnly = true;
			this.txtLocalizacao.Size = new System.Drawing.Size(498, 22);
			this.txtLocalizacao.TabIndex = 35;
			this.txtLocalizacao.TextChanged += new System.EventHandler(this.txtLocalizacao_TextChanged_1);
			// 
			// txtTipoItem
			// 
			this.txtTipoItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtTipoItem.Location = new System.Drawing.Point(130, 115);
			this.txtTipoItem.Margin = new System.Windows.Forms.Padding(4);
			this.txtTipoItem.Name = "txtTipoItem";
			this.txtTipoItem.ReadOnly = true;
			this.txtTipoItem.Size = new System.Drawing.Size(498, 22);
			this.txtTipoItem.TabIndex = 33;
			this.txtTipoItem.TextChanged += new System.EventHandler(this.txtTipoItem_TextChanged);
			// 
			// colCodLeitor
			// 
			this.colCodLeitor.HeaderText = "Id";
			this.colCodLeitor.MinimumWidth = 6;
			this.colCodLeitor.Name = "colCodLeitor";
			this.colCodLeitor.ReadOnly = true;
			// 
			// colNomeItem
			// 
			this.colNomeItem.HeaderText = "Nome Item";
			this.colNomeItem.MinimumWidth = 6;
			this.colNomeItem.Name = "colNomeItem";
			this.colNomeItem.ReadOnly = true;
			// 
			// colNumExemplar
			// 
			this.colNumExemplar.HeaderText = "Num Exemplar";
			this.colNumExemplar.MinimumWidth = 6;
			this.colNumExemplar.Name = "colNumExemplar";
			this.colNumExemplar.ReadOnly = true;
			// 
			// colTipoItem
			// 
			this.colTipoItem.HeaderText = "Tipo Item";
			this.colTipoItem.MinimumWidth = 6;
			this.colTipoItem.Name = "colTipoItem";
			this.colTipoItem.ReadOnly = true;
			// 
			// colLocalizacao
			// 
			this.colLocalizacao.HeaderText = "Localização";
			this.colLocalizacao.MinimumWidth = 6;
			this.colLocalizacao.Name = "colLocalizacao";
			this.colLocalizacao.ReadOnly = true;
			// 
			// FrmSelecionarItemAcervo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(637, 513);
			this.Controls.Add(this.txtLocalizacao);
			this.Controls.Add(this.lblLocalizacao);
			this.Controls.Add(this.txtTipoItem);
			this.Controls.Add(this.lblTipoItem);
			this.Controls.Add(this.txtNumExemplar);
			this.Controls.Add(this.lblNumExemplar);
			this.Controls.Add(this.lblNomeLeitor);
			this.Controls.Add(this.txtNomeItem);
			this.Controls.Add(this.txtCodigoItem);
			this.Controls.Add(this.lblCodigoItem);
			this.Controls.Add(this.gridLayout);
			this.Name = "FrmSelecionarItemAcervo";
			this.Text = "Selecionar Autor";
			this.Load += new System.EventHandler(this.FrmSelecionarItemAcervo_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridLayout)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNomeLeitor;
		private System.Windows.Forms.TextBox txtNomeItem;
		private System.Windows.Forms.TextBox txtCodigoItem;
		private System.Windows.Forms.Label lblCodigoItem;
		private System.Windows.Forms.DataGridView gridLayout;
		private System.Windows.Forms.Label lblNumExemplar;
		private System.Windows.Forms.TextBox txtNumExemplar;
		private System.Windows.Forms.Label lblTipoItem;
		private System.Windows.Forms.Label lblLocalizacao;
		private System.Windows.Forms.TextBox txtLocalizacao;
		private System.Windows.Forms.TextBox txtTipoItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCodLeitor;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNomeItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNumExemplar;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTipoItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn colLocalizacao;
	}
}