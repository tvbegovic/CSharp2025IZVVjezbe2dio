using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PredictionApp
{
  public partial class Glavna : Form
  {
    public Glavna()
    {
      InitializeComponent();
    }

    private void btnKlubovi_Click(object sender, EventArgs e)
    {
      Klubovi frm = new Klubovi();
      frm.ShowDialog();
    }

    private void btnPrognoze_Click(object sender, EventArgs e)
    {
      Prognoze frm = new Prognoze();
      frm.ShowDialog();
    }

    private void btnUtakmice_Click(object sender, EventArgs e)
    {
      Utakmice frm = new Utakmice();
      frm.ShowDialog();
    }
  }
}
