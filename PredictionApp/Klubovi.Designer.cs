using System;
using System.Drawing;
using System.Windows.Forms;

namespace PredictionApp
{
  public partial class Klubovi
  {
    private DataGridView dgvKlubovi;

    private void InitializeComponent()
    {
      this.dgvKlubovi = new DataGridView();
      this.SuspendLayout();
      // 
      // dgv
      // 
      this.dgvKlubovi.Dock = DockStyle.Fill;
      this.dgvKlubovi.ReadOnly = true;
      this.dgvKlubovi.AllowUserToAddRows = false;
      this.dgvKlubovi.AllowUserToDeleteRows = false;
      this.dgvKlubovi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      // 
      // Klubovi
      // 
      this.ClientSize = new Size(800, 450);
      this.Controls.Add(this.dgvKlubovi);
      this.Text = "Klubovi";
      this.ResumeLayout(false);
    }
  }
}
