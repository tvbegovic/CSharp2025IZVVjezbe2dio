using System;
using System.Drawing;
using System.Windows.Forms;

namespace PredictionApp
{
  public partial class Prognoze
  {
    private Label lblUser;
    private TextBox txtUser;
    private Button btnDodaj;
    private Button btnUredi;
    private Button btnPretrazi;
    private DataGridView dgvPrognoze;

    // DataGridView columns
    private System.Windows.Forms.DataGridViewTextBoxColumn colMatch;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPredictionType;
    private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedAt;
    private System.Windows.Forms.DataGridViewTextBoxColumn colId;

    private void InitializeComponent()
    {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.lblUser = new System.Windows.Forms.Label();
      this.txtUser = new System.Windows.Forms.TextBox();
      this.btnDodaj = new System.Windows.Forms.Button();
      this.btnUredi = new System.Windows.Forms.Button();
      this.btnPretrazi = new System.Windows.Forms.Button();
      this.dgvPrognoze = new System.Windows.Forms.DataGridView();
      this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colMatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colPredictionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.colCreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btnObrisi = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.dgvPrognoze)).BeginInit();
      this.SuspendLayout();
      // 
      // lblUser
      // 
      this.lblUser.Location = new System.Drawing.Point(12, 15);
      this.lblUser.Name = "lblUser";
      this.lblUser.Size = new System.Drawing.Size(80, 20);
      this.lblUser.TabIndex = 0;
      this.lblUser.Text = "Korisnik:";
      this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtUser
      // 
      this.txtUser.Location = new System.Drawing.Point(100, 15);
      this.txtUser.Name = "txtUser";
      this.txtUser.Size = new System.Drawing.Size(200, 20);
      this.txtUser.TabIndex = 1;
      // 
      // btnDodaj
      // 
      this.btnDodaj.Location = new System.Drawing.Point(12, 50);
      this.btnDodaj.Name = "btnDodaj";
      this.btnDodaj.Size = new System.Drawing.Size(75, 23);
      this.btnDodaj.TabIndex = 2;
      this.btnDodaj.Text = "Dodaj novi";
      this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
      // 
      // btnUredi
      // 
      this.btnUredi.Location = new System.Drawing.Point(100, 50);
      this.btnUredi.Name = "btnUredi";
      this.btnUredi.Size = new System.Drawing.Size(75, 23);
      this.btnUredi.TabIndex = 3;
      this.btnUredi.Text = "Uredi";
      this.btnUredi.Click += new System.EventHandler(this.btnUredi_Click);
      // 
      // btnPretrazi
      // 
      this.btnPretrazi.Location = new System.Drawing.Point(317, 14);
      this.btnPretrazi.Name = "btnPretrazi";
      this.btnPretrazi.Size = new System.Drawing.Size(75, 23);
      this.btnPretrazi.TabIndex = 4;
      this.btnPretrazi.Text = "Pretraži";
      this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
      // 
      // dgvPrognoze
      // 
      this.dgvPrognoze.AllowUserToAddRows = false;
      this.dgvPrognoze.AllowUserToDeleteRows = false;
      this.dgvPrognoze.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgvPrognoze.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvPrognoze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPrognoze.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colMatch,
            this.colPredictionType,
            this.colUserName,
            this.colCreatedAt});
      this.dgvPrognoze.Location = new System.Drawing.Point(12, 90);
      this.dgvPrognoze.Name = "dgvPrognoze";
      this.dgvPrognoze.ReadOnly = true;
      this.dgvPrognoze.Size = new System.Drawing.Size(760, 360);
      this.dgvPrognoze.TabIndex = 5;
      // 
      // colId
      // 
      this.colId.DataPropertyName = "Id";
      this.colId.HeaderText = "ID";
      this.colId.Name = "colId";
      this.colId.ReadOnly = true;
      this.colId.Visible = false;
      // 
      // colMatch
      // 
      this.colMatch.DataPropertyName = "Match";
      this.colMatch.HeaderText = "Utakmica";
      this.colMatch.Name = "colMatch";
      this.colMatch.ReadOnly = true;
      // 
      // colPredictionType
      // 
      this.colPredictionType.DataPropertyName = "PredictionType";
      this.colPredictionType.HeaderText = "Tip prognoze";
      this.colPredictionType.Name = "colPredictionType";
      this.colPredictionType.ReadOnly = true;
      // 
      // colUserName
      // 
      this.colUserName.DataPropertyName = "UserName";
      this.colUserName.HeaderText = "Korisnik";
      this.colUserName.Name = "colUserName";
      this.colUserName.ReadOnly = true;
      // 
      // colCreatedAt
      // 
      this.colCreatedAt.DataPropertyName = "CreatedAt";
      dataGridViewCellStyle1.Format = "g";
      this.colCreatedAt.DefaultCellStyle = dataGridViewCellStyle1;
      this.colCreatedAt.HeaderText = "Kreirano";
      this.colCreatedAt.Name = "colCreatedAt";
      this.colCreatedAt.ReadOnly = true;
      // 
      // btnObrisi
      // 
      this.btnObrisi.Location = new System.Drawing.Point(197, 50);
      this.btnObrisi.Name = "btnObrisi";
      this.btnObrisi.Size = new System.Drawing.Size(75, 23);
      this.btnObrisi.TabIndex = 6;
      this.btnObrisi.Text = "Obriši";
      this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
      // 
      // Prognoze
      // 
      this.ClientSize = new System.Drawing.Size(784, 461);
      this.Controls.Add(this.btnObrisi);
      this.Controls.Add(this.lblUser);
      this.Controls.Add(this.txtUser);
      this.Controls.Add(this.btnDodaj);
      this.Controls.Add(this.btnUredi);
      this.Controls.Add(this.btnPretrazi);
      this.Controls.Add(this.dgvPrognoze);
      this.Name = "Prognoze";
      this.Text = "Prognoze";
      ((System.ComponentModel.ISupportInitialize)(this.dgvPrognoze)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    private Button btnObrisi;
  }
}
