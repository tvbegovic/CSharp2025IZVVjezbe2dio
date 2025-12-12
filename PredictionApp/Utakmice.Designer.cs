using System;
using System.Drawing;
using System.Windows.Forms;

namespace PredictionApp
{
  public partial class Utakmice
  {
    private ComboBox cmbKlubovi;
    private TextBox txtDatumOd;
    private TextBox txtDatumDo;
    private TextBox txtTekst;
    private Button btnPretrazi;
    private DataGridView dgvUtakmice;

    private Label lblKlubovi;
    private Label lblSearch;
    private Label lblDatumOd;
    private Label lblDatumDo;
    private System.Windows.Forms.DataGridViewTextBoxColumn colHome;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAway;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colProbHome;
    private System.Windows.Forms.DataGridViewTextBoxColumn colProbAway;

    private void InitializeComponent()
    {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.cmbKlubovi = new System.Windows.Forms.ComboBox();
      this.txtDatumOd = new System.Windows.Forms.TextBox();
      this.txtDatumDo = new System.Windows.Forms.TextBox();
      this.txtTekst = new System.Windows.Forms.TextBox();
      this.btnPretrazi = new System.Windows.Forms.Button();
      this.dgvUtakmice = new System.Windows.Forms.DataGridView();
      this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colHomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colAwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colMatchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colProbHomeWin = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colProbAwayWin = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colDraw = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.lblKlubovi = new System.Windows.Forms.Label();
      this.lblSearch = new System.Windows.Forms.Label();
      this.lblDatumOd = new System.Windows.Forms.Label();
      this.lblDatumDo = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.dgvUtakmice)).BeginInit();
      this.SuspendLayout();
      // 
      // cmbKlubovi
      // 
      this.cmbKlubovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbKlubovi.Location = new System.Drawing.Point(70, 12);
      this.cmbKlubovi.Name = "cmbKlubovi";
      this.cmbKlubovi.Size = new System.Drawing.Size(180, 21);
      this.cmbKlubovi.TabIndex = 1;
      // 
      // txtDatumOd
      // 
      this.txtDatumOd.Location = new System.Drawing.Point(80, 42);
      this.txtDatumOd.Name = "txtDatumOd";
      this.txtDatumOd.Size = new System.Drawing.Size(120, 20);
      this.txtDatumOd.TabIndex = 5;
      // 
      // txtDatumDo
      // 
      this.txtDatumDo.Location = new System.Drawing.Point(280, 42);
      this.txtDatumDo.Name = "txtDatumDo";
      this.txtDatumDo.Size = new System.Drawing.Size(120, 20);
      this.txtDatumDo.TabIndex = 7;
      // 
      // txtTekst
      // 
      this.txtTekst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTekst.Location = new System.Drawing.Point(330, 12);
      this.txtTekst.Name = "txtTekst";
      this.txtTekst.Size = new System.Drawing.Size(250, 20);
      this.txtTekst.TabIndex = 3;
      // 
      // btnPretrazi
      // 
      this.btnPretrazi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPretrazi.Location = new System.Drawing.Point(660, 12);
      this.btnPretrazi.Name = "btnPretrazi";
      this.btnPretrazi.Size = new System.Drawing.Size(75, 23);
      this.btnPretrazi.TabIndex = 8;
      this.btnPretrazi.Text = "Pretraži";
      this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
      // 
      // dgvUtakmice
      // 
      this.dgvUtakmice.AllowUserToAddRows = false;
      this.dgvUtakmice.AllowUserToDeleteRows = false;
      this.dgvUtakmice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvUtakmice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvUtakmice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvUtakmice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colHomeTeam,
            this.colAwayTeam,
            this.colMatchDate,
            this.colProbHomeWin,
            this.colProbAwayWin,
            this.colDraw});
      this.dgvUtakmice.Location = new System.Drawing.Point(12, 80);
      this.dgvUtakmice.Name = "dgvUtakmice";
      this.dgvUtakmice.ReadOnly = true;
      this.dgvUtakmice.Size = new System.Drawing.Size(760, 360);
      this.dgvUtakmice.TabIndex = 9;
      // 
      // colId
      // 
      this.colId.DataPropertyName = "id";
      this.colId.HeaderText = "ID";
      this.colId.Name = "colId";
      this.colId.ReadOnly = true;
      // 
      // colHomeTeam
      // 
      this.colHomeTeam.DataPropertyName = "HomeTeam";
      this.colHomeTeam.HeaderText = "Domaćin";
      this.colHomeTeam.Name = "colHomeTeam";
      this.colHomeTeam.ReadOnly = true;
      // 
      // colAwayTeam
      // 
      this.colAwayTeam.DataPropertyName = "AwayTeam";
      this.colAwayTeam.HeaderText = "Gost";
      this.colAwayTeam.Name = "colAwayTeam";
      this.colAwayTeam.ReadOnly = true;
      // 
      // colMatchDate
      // 
      this.colMatchDate.DataPropertyName = "MatchDate";
      dataGridViewCellStyle1.Format = "g";
      this.colMatchDate.DefaultCellStyle = dataGridViewCellStyle1;
      this.colMatchDate.HeaderText = "Datum";
      this.colMatchDate.Name = "colMatchDate";
      this.colMatchDate.ReadOnly = true;
      // 
      // colProbHomeWin
      // 
      this.colProbHomeWin.DataPropertyName = "ProbHomeWin";
      this.colProbHomeWin.HeaderText = "Domaćin %";
      this.colProbHomeWin.Name = "colProbHomeWin";
      this.colProbHomeWin.ReadOnly = true;
      // 
      // colProbAwayWin
      // 
      this.colProbAwayWin.DataPropertyName = "ProbAwayWin";
      this.colProbAwayWin.HeaderText = "Gost %";
      this.colProbAwayWin.Name = "colProbAwayWin";
      this.colProbAwayWin.ReadOnly = true;
      // 
      // colDraw
      // 
      this.colDraw.DataPropertyName = "ProbDraw";
      this.colDraw.HeaderText = "X %";
      this.colDraw.Name = "colDraw";
      this.colDraw.ReadOnly = true;
      // 
      // lblKlubovi
      // 
      this.lblKlubovi.Location = new System.Drawing.Point(12, 15);
      this.lblKlubovi.Name = "lblKlubovi";
      this.lblKlubovi.Size = new System.Drawing.Size(50, 20);
      this.lblKlubovi.TabIndex = 0;
      this.lblKlubovi.Text = "Klub:";
      this.lblKlubovi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblSearch
      // 
      this.lblSearch.Location = new System.Drawing.Point(270, 15);
      this.lblSearch.Name = "lblSearch";
      this.lblSearch.Size = new System.Drawing.Size(50, 20);
      this.lblSearch.TabIndex = 2;
      this.lblSearch.Text = "Pretraga:";
      this.lblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblDatumOd
      // 
      this.lblDatumOd.Location = new System.Drawing.Point(12, 45);
      this.lblDatumOd.Name = "lblDatumOd";
      this.lblDatumOd.Size = new System.Drawing.Size(60, 20);
      this.lblDatumOd.TabIndex = 4;
      this.lblDatumOd.Text = "Datum od:";
      this.lblDatumOd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblDatumDo
      // 
      this.lblDatumDo.Location = new System.Drawing.Point(220, 45);
      this.lblDatumDo.Name = "lblDatumDo";
      this.lblDatumDo.Size = new System.Drawing.Size(60, 20);
      this.lblDatumDo.TabIndex = 6;
      this.lblDatumDo.Text = "Datum do:";
      this.lblDatumDo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // Utakmice
      // 
      this.ClientSize = new System.Drawing.Size(784, 461);
      this.Controls.Add(this.lblKlubovi);
      this.Controls.Add(this.cmbKlubovi);
      this.Controls.Add(this.lblSearch);
      this.Controls.Add(this.txtTekst);
      this.Controls.Add(this.lblDatumOd);
      this.Controls.Add(this.txtDatumOd);
      this.Controls.Add(this.lblDatumDo);
      this.Controls.Add(this.txtDatumDo);
      this.Controls.Add(this.btnPretrazi);
      this.Controls.Add(this.dgvUtakmice);
      this.Name = "Utakmice";
      this.Text = "Utakmice";
      ((System.ComponentModel.ISupportInitialize)(this.dgvUtakmice)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colHomeTeam;
    private DataGridViewTextBoxColumn colAwayTeam;
    private DataGridViewTextBoxColumn colMatchDate;
    private DataGridViewTextBoxColumn colProbHomeWin;
    private DataGridViewTextBoxColumn colProbAwayWin;
    private DataGridViewTextBoxColumn colDraw;
  }
}
