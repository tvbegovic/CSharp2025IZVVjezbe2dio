
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace PredictionApp
{
  public partial class Prognoze : Form
  {
    List<Prediction> prognoze = new List<Prediction>();
    public Prognoze()
    {
      InitializeComponent();
      dgvPrognoze.AutoGenerateColumns = false;
      dgvPrognoze.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      UcitajPrognoze();
    }

    void UcitajPrognoze()
    {
      try
      {
				//TODO: Pozvati sql upit za učitavanje prognoza iz baze podataka. Upit treba uključivati i filter po korisničkom imenu ako je uneseno u txtUser. Također, dohvatiti imena utakmica i tipova prognoza iz pripadajućih tablica
				string sql = @"SELECT TOP 100 p.*, CONCAT(t1.Name, ' - ', t2.Name, ' ', CONVERT(varchar(30),m.MatchDate,104)) AS Match, pt.Name AS PredictionType
            FROM Prediction p
            LEFT OUTER JOIN Match m ON p.MatchId = m.Id
            LEFT OUTER JOIN Team t1 ON m.HomeTeamId = t1.Id
            LEFT OUTER JOIN Team t2 ON m.AwayTeamId = t2.Id
            LEFT OUTER JOIN PredictionType pt ON p.PredictionTypeId = pt.Id
            WHERE (@userName IS NULL OR p.UserName LIKE CONCAT('%',@userName,'%'))
            ORDER BY p.CreatedAt DESC";
        using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString)) 
        {
          string userName = txtUser.Text;
          prognoze = conn.Query<Prediction>(sql, new { userName }).ToList();
          AzurirajGrid();
        }
			}
      catch (Exception ex)
      {
        MessageBox.Show("Greška pri učitavanju prognoza: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    void AzurirajGrid()
    {
      dgvPrognoze.DataSource = null;
      dgvPrognoze.DataSource = prognoze;
    }

    private void btnDodaj_Click(object sender, EventArgs e)
    {
      using (var dlg = new PredictionEdit())
      {
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
          var p = dlg.Result;
          try
          {


						//TODO: Pozvati sql upit za umetanje nove prognoze u bazu podataka i dohvatiti novi Id
						string sql = "INSERT INTO Prediction (MatchId, UserName, PredictionTypeId, CreatedAt) OUTPUT INSERTED.Id VALUES (@MatchId, @UserName, @PredictionTypeId, @CreatedAt)";
						using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
              conn.Execute(sql, p);
            }
							//Zbog jednostavnosti, ponovno učitavamo sve prognoze iz baze nakon dodavanja nove (umjesto da samo dodajemo novi objekt u lokalnu listu) - zbog veza s drugim tablicama
							UcitajPrognoze();
            AzurirajGrid();
            
          }
          catch (Exception ex)
          {
            MessageBox.Show("Greška pri spremanju prognoze: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
    }

    private void btnUredi_Click(object sender, EventArgs e)
    {
      if (dgvPrognoze.SelectedRows.Count == 0)
      {
        MessageBox.Show("Odaberite prognozu za uređivanje.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      var selected = dgvPrognoze.SelectedRows[0].DataBoundItem as Prediction;
      if (selected == null)
      {
        MessageBox.Show("Neispravan odabir.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      // Radimo kopiju odabranog objekta kako bismo izbjegli izmjene originalnog dok ne potvrdimo izmjene
      var kopija = new Prediction
      {
        Id = selected.Id,
        MatchId = selected.MatchId,
        PredictionTypeId = selected.PredictionTypeId,
        UserName = selected.UserName,
        CreatedAt = selected.CreatedAt
      };

      using (var dlg = new PredictionEdit(kopija))
      {
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
          var p = dlg.Result;
          try
          {

						//TODO: Pozvati sql upit za ažuriranje postojeće prognoze u bazi podataka
						string sql = "UPDATE Prediction SET MatchId = @MatchId, UserName = @UserName, PredictionTypeId = @PredictionTypeId, CreatedAt = @CreatedAt WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString)) 
            {
              conn.Execute(sql, p);
            }

							// Ažuriraj lokalnu listu i grid
							var item = prognoze.FirstOrDefault(x => x.Id == p.Id);
              if (item != null)
              {
                item.MatchId = p.MatchId;
                item.PredictionTypeId = p.PredictionTypeId;
                item.UserName = p.UserName;
                item.PredictionType = p.PredictionTypeId == 1 ? "1" : p.PredictionTypeId == 2 ? "2" : "X"; // Simplified for example
                AzurirajGrid();
              }
            
          }
          catch (Exception ex)
          {
            MessageBox.Show("Greška pri ažuriranju prognoze: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
    }

    private void btnPretrazi_Click(object sender, EventArgs e)
    {

    }

    private void btnObrisi_Click(object sender, EventArgs e)
    {
      if (dgvPrognoze.SelectedRows.Count == 0)
      {
        MessageBox.Show("Odaberite prognozu za brisanje.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }

      int selectedId = (int)dgvPrognoze.SelectedRows[0].Cells["colId"].Value;
      DialogResult dr = MessageBox.Show("Jeste li sigurni da želite obrisati odabranu prognozu?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (dr != DialogResult.Yes)
        return;
      try
      {
        //TODO: Pozvati sql upit za brisanje prognoze iz baze podataka. Učitati ponovo listu prognoza nakon brisanja i osvježiti grid
        string sql = "DELETE FROM Prediction WHERE id = @id";
        using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString)) 
        {
          conn.Execute(sql, new { id = selectedId });
        }
        UcitajPrognoze();
        AzurirajGrid();

			}
      catch (Exception ex)
      {
        MessageBox.Show("Greška pri brisanju prognoze: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
