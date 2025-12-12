namespace PredictionApp
{
  partial class Glavna
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
      this.btnUtakmice = new System.Windows.Forms.Button();
      this.btnKlubovi = new System.Windows.Forms.Button();
      this.btnPrognoze = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnUtakmice
      // 
      this.btnUtakmice.BackgroundImage = global::PredictionApp.Properties.Resources.lopta;
      this.btnUtakmice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnUtakmice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnUtakmice.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnUtakmice.Location = new System.Drawing.Point(550, 50);
      this.btnUtakmice.Name = "btnUtakmice";
      this.btnUtakmice.Size = new System.Drawing.Size(200, 177);
      this.btnUtakmice.TabIndex = 2;
      this.btnUtakmice.Text = "Utakmice";
      this.btnUtakmice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.btnUtakmice.UseVisualStyleBackColor = true;
      this.btnUtakmice.Click += new System.EventHandler(this.btnUtakmice_Click);
      // 
      // btnKlubovi
      // 
      this.btnKlubovi.BackgroundImage = global::PredictionApp.Properties.Resources.hnl;
      this.btnKlubovi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnKlubovi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnKlubovi.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnKlubovi.Location = new System.Drawing.Point(50, 50);
      this.btnKlubovi.Name = "btnKlubovi";
      this.btnKlubovi.Size = new System.Drawing.Size(205, 177);
      this.btnKlubovi.TabIndex = 0;
      this.btnKlubovi.Text = "Klubovi";
      this.btnKlubovi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.btnKlubovi.UseVisualStyleBackColor = true;
      this.btnKlubovi.Click += new System.EventHandler(this.btnKlubovi_Click);
      // 
      // btnPrognoze
      // 
      this.btnPrognoze.BackgroundImage = global::PredictionApp.Properties.Resources.prognosis;
      this.btnPrognoze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnPrognoze.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnPrognoze.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
      this.btnPrognoze.Location = new System.Drawing.Point(300, 50);
      this.btnPrognoze.Name = "btnPrognoze";
      this.btnPrognoze.Size = new System.Drawing.Size(200, 177);
      this.btnPrognoze.TabIndex = 1;
      this.btnPrognoze.Text = "Prognoze";
      this.btnPrognoze.TextAlign = System.Drawing.ContentAlignment.BottomRight;
      this.btnPrognoze.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnPrognoze.UseVisualStyleBackColor = true;
      this.btnPrognoze.Click += new System.EventHandler(this.btnPrognoze_Click);
      // 
      // Glavna
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(792, 290);
      this.Controls.Add(this.btnKlubovi);
      this.Controls.Add(this.btnPrognoze);
      this.Controls.Add(this.btnUtakmice);
      this.Name = "Glavna";
      this.Text = "Prognoze (ali ne vremenske)";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnKlubovi;
    private System.Windows.Forms.Button btnPrognoze;
    private System.Windows.Forms.Button btnUtakmice;
  }
}

