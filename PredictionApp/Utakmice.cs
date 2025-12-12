
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace PredictionApp
{
  public partial class Utakmice : Form
  {
    List<Match> utakmice = new List<Match>();
    List<Team> klubovi = new List<Team>();
    public Utakmice()
    {
      InitializeComponent();
      dgvUtakmice.AutoGenerateColumns = false;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      UcitajKlubove();
      UcitajUtakmice();
    }

    // Placeholder: user will implement SQL loading later
    private void UcitajKlubove()
    {
      // e.g. populate cmbKlubovi here
      try
      {
        cmbKlubovi.ValueMember = "Id";
        cmbKlubovi.DisplayMember = "Name";
        
        string sql = "SELECT * FROM Team";
				using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
        {
          klubovi = conn.Query<Team>(sql).ToList();
          Team sviKlubovi = new Team();
          sviKlubovi.Id = 0;
          sviKlubovi.Name = "Svi klubovi";
          klubovi.Insert(0, sviKlubovi);
          cmbKlubovi.DataSource = klubovi;
        }

			}
      catch (Exception ex)
      {
        MessageBox.Show("Greška pri učitavanju klubova: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnPretrazi_Click(object sender, EventArgs e)
    {
      UcitajUtakmice();
    }

    private void UcitajUtakmice()
    {
      
      string text = txtTekst.Text.Trim();
      int? klubId = (cmbKlubovi.SelectedItem as Team)?.Id;
      DateTime? dateFrom = null;
      DateTime? dateTo = null;
      if (klubId == 0)
        klubId = null;
      bool ok = DateTime.TryParse(txtDatumOd.Text.Trim(), out DateTime dtFrom);
      if (ok)
        dateFrom = dtFrom;
      ok = DateTime.TryParse(txtDatumDo.Text.Trim(), out DateTime dtTo);
      if (ok)
        dateTo = dtTo;
      try
      {
        //TODO: Pozvati sql upit za učitavanje utakmica iz baze podataka sa zadatim filterima (ne zaboraviti osvježiti grid)
        string sql = @"SELECT m.Id, m.MatchDate, m.ProbHomeWin * 100 ProbHomeWin, m.ProbAwayWin * 100 ProbAwayWin, t1.Name HomeTeam, t2.Name AwayTeam, (1 - m.ProbHomeWin - m.ProbAwayWin) * 100 ProbDraw
        FROM Match m
        LEFT OUTER JOIN Team t1 ON m.HomeTeamId = t1.Id
        LEFT OUTER JOIN Team t2 ON m.AwayTeamId = t2.Id
        WHERE (m.HomeTeamId = @klubId OR m.AwayTeamId = @klubId OR @klubId IS NULL)
        AND (m.MatchDate >= @dateFrom OR @dateFrom IS NULL)
        AND (m.MatchDate <= @dateTo OR @dateTo IS NULL)";
        using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString)) 
        { 
          utakmice = conn.Query<Match>(sql, new { klubId, dateFrom, dateTo }).ToList();
          AzurirajGrid();
        }
			}
      catch (Exception ex)
      {
        MessageBox.Show("Greška pri učitavanju utakmica: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

      }
    }

    void AzurirajGrid() 
    {
      dgvUtakmice.DataSource = null;
      dgvUtakmice.DataSource = utakmice;
    }
  }
}
