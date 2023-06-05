namespace FrmReservaItemAcervo
{
	partial class FrmSelecionarLeitor
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
			this.txtNomeLeitor = new System.Windows.Forms.TextBox();
			this.txtCodigoLeitor = new System.Windows.Forms.TextBox();
			this.lblCodigo = new System.Windows.Forms.Label();
			this.gridLayout = new System.Windows.Forms.DataGridView();
			this.colCodLeitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNomeLeitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.gridLayout)).BeginInit();
			this.SuspendLayout();
			// 
			// lblNomeLeitor
			// 
			this.lblNomeLeitor.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblNomeLeitor.AutoSize = true;
			this.lblNomeLeitor.Location = new System.Drawing.Point(11, 48);
			this.lblNomeLeitor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblNomeLeitor.Name = "lblNomeLeitor";
			this.lblNomeLeitor.Size = new System.Drawing.Size(40, 16);
			this.lblNomeLeitor.TabIndex = 24;
			this.lblNomeLeitor.Text = "Leitor";
			// 
			// txtNomeLeitor
			// 
			this.txtNomeLeitor.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtNomeLeitor.Location = new System.Drawing.Point(105, 42);
			this.txtNomeLeitor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtNomeLeitor.Name = "txtNomeLeitor";
			this.txtNomeLeitor.ReadOnly = true;
			this.txtNomeLeitor.Size = new System.Drawing.Size(419, 22);
			this.txtNomeLeitor.TabIndex = 23;
			this.txtNomeLeitor.TextChanged += new System.EventHandler(this.txtNomeLeitor_TextChanged);
			// 
			// txtCodigoLeitor
			// 
			this.txtCodigoLeitor.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.txtCodigoLeitor.Location = new System.Drawing.Point(105, 7);
			this.txtCodigoLeitor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txtCodigoLeitor.Name = "txtCodigoLeitor";
			this.txtCodigoLeitor.ReadOnly = true;
			this.txtCodigoLeitor.Size = new System.Drawing.Size(281, 22);
			this.txtCodigoLeitor.TabIndex = 22;
			this.txtCodigoLeitor.TextChanged += new System.EventHandler(this.txtCodigoLeitor_TextChanged);
			// 
			// lblCodigo
			// 
			this.lblCodigo.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lblCodigo.AutoSize = true;
			this.lblCodigo.Location = new System.Drawing.Point(11, 14);
			this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCodigo.Name = "lblCodigo";
			this.lblCodigo.Size = new System.Drawing.Size(51, 16);
			this.lblCodigo.TabIndex = 21;
			this.lblCodigo.Text = "Código";
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
            this.colNomeLeitor});
			this.gridLayout.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.gridLayout.Location = new System.Drawing.Point(13, 96);
			this.gridLayout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.gridLayout.Name = "gridLayout";
			this.gridLayout.ReadOnly = true;
			this.gridLayout.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			this.gridLayout.RowHeadersWidth = 51;
			this.gridLayout.Size = new System.Drawing.Size(531, 359);
			this.gridLayout.TabIndex = 20;
			this.gridLayout.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLayout_CellContentClick);
			this.gridLayout.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridLayout_CellMouseDoubleClick);
			// 
			// colCodLeitor
			// 
			this.colCodLeitor.HeaderText = "Id";
			this.colCodLeitor.MinimumWidth = 6;
			this.colCodLeitor.Name = "colCodLeitor";
			this.colCodLeitor.ReadOnly = true;
			// 
			// colNomeLeitor
			// 
			this.colNomeLeitor.HeaderText = "Leitor";
			this.colNomeLeitor.MinimumWidth = 6;
			this.colNomeLeitor.Name = "colNomeLeitor";
			this.colNomeLeitor.ReadOnly = true;
			// 
			// FrmSelecionarLeitor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(557, 463);
			this.Controls.Add(this.lblNomeLeitor);
			this.Controls.Add(this.txtNomeLeitor);
			this.Controls.Add(this.txtCodigoLeitor);
			this.Controls.Add(this.lblCodigo);
			this.Controls.Add(this.gridLayout);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FrmSelecionarLeitor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Selecionar Leitor";
			this.Load += new System.EventHandler(this.FrmSelecionarLeitor_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridLayout)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblNomeLeitor;
		private System.Windows.Forms.TextBox txtNomeLeitor;
		private System.Windows.Forms.TextBox txtCodigoLeitor;
		private System.Windows.Forms.Label lblCodigo;
		private System.Windows.Forms.DataGridView gridLayout;
		private System.Windows.Forms.DataGridViewTextBoxColumn colCodLeitor;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNomeLeitor;
	}
}