using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;


namespace PredictionApp
{
  public partial class PredictionEdit : Form
  {
    private Prediction editing;

    public Prediction Result { get; private set; }

    public PredictionEdit()
    {
      InitializeComponent();
    }

    public PredictionEdit(Prediction toEdit) : this()
    {
      editing = toEdit;
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      UcitajUtakmice();
      UcitajTipovePrognoza();

      if (editing != null)
      {
        txtId.Text = editing.Id.ToString();
        // select match in combo
        if (cmbMatch.DataSource is List<Match> matches)
        {
          var sel = matches.FirstOrDefault(m => m.Id == editing.MatchId);
          if (sel != null) cmbMatch.SelectedItem = sel;
        }

        if (cmbPredictionType.DataSource is List<PredictionType> pt)
        {
          var sel = pt.FirstOrDefault(p => p.Id == editing.PredictionTypeId);
          if (sel != null) cmbPredictionType.SelectedItem = sel;
        }

        txtUserName.Text = editing.UserName;
        txtCreatedAt.Text = editing.CreatedAt.ToString("g");
      }
      else
      {
        txtId.Text = "0";
        txtCreatedAt.Text = DateTime.Now.ToString("g");
      }
    }

    private void UcitajUtakmice()
    {
      try
      {
       
          List<Match> items = new List<Match>();
          //TODO: Učitati utakmice, pazi da se dohvate i imena timova iz pripadajuće tablice Team

          var displayList = items.Select(m => new MatchItem { Match = m, Display = $"{m.MatchDate:g} - {m.HomeTeam} vs {m.AwayTeam}" }).ToList();
          cmbMatch.DataSource = displayList;
          cmbMatch.DisplayMember = "Display";
          cmbMatch.ValueMember = "Match"; // ValueMember won't map to object, we'll get SelectedItem as MatchItem
        
      }
      catch
      {
        // ignore - user can populate later
      }
    }

    private void UcitajTipovePrognoza()
    {
      try
      {
        
          List<PredictionType> types = new List<PredictionType>();
          //TODO: Učitati tipove prognoza iz tablice PredictionType
          cmbPredictionType.DataSource = types;
          cmbPredictionType.DisplayMember = "Name";
          cmbPredictionType.ValueMember = "Id";
        
      }
      catch
      {
        // ignore
      }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      // Basic validation
      if (cmbMatch.SelectedItem == null)
      {
        MessageBox.Show("Odaberite utakmicu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (cmbPredictionType.SelectedItem == null)
      {
        MessageBox.Show("Odaberite tip prognoze.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      if (string.IsNullOrWhiteSpace(txtUserName.Text))
      {
        MessageBox.Show("Unesite korisničko ime.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      DateTime createdAt = DateTime.Now;
      DateTime.TryParse(txtCreatedAt.Text.Trim(), out createdAt);

      var matchItem = cmbMatch.SelectedItem as MatchItem;
      Match selectedMatch = matchItem?.Match;
      if (selectedMatch == null)
      {
        MessageBox.Show("Neispravan odabir utakmice.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      var predType = cmbPredictionType.SelectedItem as PredictionType;

      var p = editing ?? new Prediction();
      p.MatchId = selectedMatch.Id;
      p.PredictionTypeId = predType.Id;
      p.UserName = txtUserName.Text.Trim();
      p.CreatedAt = createdAt;

      Result = p;
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    // small wrapper for display in combo
    private class MatchItem
    {
      public Match Match { get; set; }
      public string Display { get; set; }
      public override string ToString() => Display;
    }
  }
}
