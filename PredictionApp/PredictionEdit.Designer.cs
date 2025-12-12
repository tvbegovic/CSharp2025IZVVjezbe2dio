using System;
using System.Drawing;
using System.Windows.Forms;

namespace PredictionApp
{
  public partial class PredictionEdit
  {
    private Label lblId;
    private TextBox txtId;
    private Label lblMatch;
    private ComboBox cmbMatch;
    private Label lblPredictionType;
    private ComboBox cmbPredictionType;
    private Label lblUserName;
    private TextBox txtUserName;
    private Label lblCreatedAt;
    private TextBox txtCreatedAt;
    private Button btnSave;
    private Button btnCancel;

    private void InitializeComponent()
    {
      this.lblId = new Label();
      this.txtId = new TextBox();
      this.lblMatch = new Label();
      this.cmbMatch = new ComboBox();
      this.lblPredictionType = new Label();
      this.cmbPredictionType = new ComboBox();
      this.lblUserName = new Label();
      this.txtUserName = new TextBox();
      this.lblCreatedAt = new Label();
      this.txtCreatedAt = new TextBox();
      this.btnSave = new Button();
      this.btnCancel = new Button();

      this.SuspendLayout();
      // 
      // lblId
      // 
      this.lblId.Location = new Point(12, 15);
      this.lblId.Size = new Size(80, 20);
      this.lblId.Text = "ID:";
      this.lblId.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // txtId
      // 
      this.txtId.Location = new Point(100, 15);
      this.txtId.Size = new Size(200, 20);
      this.txtId.ReadOnly = true;
      // 
      // lblMatch
      // 
      this.lblMatch.Location = new Point(12, 45);
      this.lblMatch.Size = new Size(80, 20);
      this.lblMatch.Text = "Utakmica:";
      this.lblMatch.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // cmbMatch
      // 
      this.cmbMatch.Location = new Point(100, 45);
      this.cmbMatch.Size = new Size(400, 21);
      this.cmbMatch.DropDownStyle = ComboBoxStyle.DropDownList;
      // 
      // lblPredictionType
      // 
      this.lblPredictionType.Location = new Point(12, 75);
      this.lblPredictionType.Size = new Size(80, 20);
      this.lblPredictionType.Text = "Tip prognoze:";
      this.lblPredictionType.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // cmbPredictionType
      // 
      this.cmbPredictionType.Location = new Point(100, 75);
      this.cmbPredictionType.Size = new Size(200, 21);
      this.cmbPredictionType.DropDownStyle = ComboBoxStyle.DropDownList;
      // 
      // lblUserName
      // 
      this.lblUserName.Location = new Point(12, 105);
      this.lblUserName.Size = new Size(80, 20);
      this.lblUserName.Text = "Korisnik:";
      this.lblUserName.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // txtUserName
      // 
      this.txtUserName.Location = new Point(100, 105);
      this.txtUserName.Size = new Size(200, 20);
      // 
      // lblCreatedAt
      // 
      this.lblCreatedAt.Location = new Point(12, 135);
      this.lblCreatedAt.Size = new Size(80, 20);
      this.lblCreatedAt.Text = "Kreirano:";
      this.lblCreatedAt.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // txtCreatedAt
      // 
      this.txtCreatedAt.Location = new Point(100, 135);
      this.txtCreatedAt.Size = new Size(200, 20);
      // 
      // btnSave
      // 
      this.btnSave.Location = new Point(100, 175);
      this.btnSave.Size = new Size(75, 23);
      this.btnSave.Text = "Spremi";
      this.btnSave.Click += new EventHandler(this.btnSave_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new Point(190, 175);
      this.btnCancel.Size = new Size(75, 23);
      this.btnCancel.Text = "Odustani";
      this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
      // 
      // PredictionEdit
      // 
      this.ClientSize = new Size(600, 220);
      this.Controls.Add(this.lblId);
      this.Controls.Add(this.txtId);
      this.Controls.Add(this.lblMatch);
      this.Controls.Add(this.cmbMatch);
      this.Controls.Add(this.lblPredictionType);
      this.Controls.Add(this.cmbPredictionType);
      this.Controls.Add(this.lblUserName);
      this.Controls.Add(this.txtUserName);
      this.Controls.Add(this.lblCreatedAt);
      this.Controls.Add(this.txtCreatedAt);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.btnCancel);
      this.Text = "Unos / Uredi prognozu";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
