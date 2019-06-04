using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Program_za_PIS_seminarski
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            toolTip2.OwnerDraw = true;
            toolTip2.BackColor = Color.BlanchedAlmond;
            toolTip2.SetToolTip(label6, "Pouzdanost za eksponencijalnu raspodelu vremena rada do otkaza");

            toolTip3.OwnerDraw = true;
            toolTip3.BackColor = Color.BlanchedAlmond;
            toolTip3.SetToolTip(label8, "Srednje vreme rada do otkaza za ekponencijalnu raspodelu vremena rada do otkaza");

            toolTip4.OwnerDraw = true;
            toolTip4.BackColor = Color.BlanchedAlmond;
            toolTip4.SetToolTip(label13, "Gustina raspodele vremena rada do otkaza za ekponencijalnu raspodelu vremena rada do otkaza");
        }

        private void cekiran(object sender, EventArgs e)
        {
            odluka = true;
            foreach (CheckBox cb in groupBox1.Controls)
            {
                if(cb.Checked)
                {
                    if (cb.Tag.ToString() == "I")
                    {
                        double lambda;
                        double resenje;
                        double lambdaxT;
                        if(!string.IsNullOrWhiteSpace(txtLambda.Text) && !string.IsNullOrWhiteSpace(txtEksponent.Text) && !string.IsNullOrWhiteSpace(txtVreme.Text))
                        {
                            lambda = Math.Pow(Convert.ToSingle(txtLambda.Text), Convert.ToInt32(txtEksponent.Text));
                            lambdaxT = lambda * Convert.ToInt32(txtVreme.Text);

                            resenje = Math.Round(Math.Pow(Math.E, lambdaxT * -1), 4);
                            lblR.Text = resenje.ToString();

                            panel1.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Polja za intenzitet otkaza i vreme moraju biti popunjena", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb.Checked = false;
                            return;
                        }
                    }

                   else if (cb.Tag.ToString() == "II")
                   {
                        double lambda;
                        double resenje;
                        
                        if (!string.IsNullOrWhiteSpace(txtLambda.Text) && !string.IsNullOrWhiteSpace(txtEksponent.Text) && !string.IsNullOrWhiteSpace(txtVreme.Text))
                        {
                            lambda = Math.Pow(Convert.ToSingle(txtLambda.Text), Convert.ToInt32(txtEksponent.Text));
                            
                            resenje = (1 / lambda);
                            lblT0.Text = resenje.ToString() + " [h]" ;

                            panel2.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Polja za intenzitet otkaza i vreme moraju biti popunjena", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb.Checked = false;
                            return;
                        }
                    }
                      
                    else if (cb.Tag.ToString() == "III")
                    {
                        double lambda;
                        double resenje;
                        double lambdaxT;
                        if (!string.IsNullOrWhiteSpace(txtLambda.Text) && !string.IsNullOrWhiteSpace(txtEksponent.Text) && !string.IsNullOrWhiteSpace(txtVreme.Text))
                        {
                            lambda = Math.Pow(Convert.ToSingle(txtLambda.Text), Convert.ToInt32(txtEksponent.Text));
                            lambdaxT = lambda * Convert.ToInt32(txtVreme.Text);

                            resenje = Math.Round(Math.Pow(Math.E, lambdaxT * -1), 4);
                            lblF.Text = (resenje*lambda).ToString();
                            int x = lblF.Left;
                            int y = lblF.Top;
                            int pom1 = (Convert.ToInt32(lblF.Text.Length) * 100) / 13;
                            label15.Location = new Point(x + pom1 , y);
                            int x1 = label15.Left;
                            int y1 = label15.Top;
                            int pom2 = (Convert.ToInt32(label15.Text.Length) * 100) / 13;
                            label10.Location = new Point(x1 + pom2, y);
                            int x2 = label10.Left;
                            int y2 = label10.Top;
                            int pom3 = (Convert.ToInt32(label10.Text.Length) * 100) / 20;
                            label18.Location = new Point(x2 + pom3, y);

                            panel3.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Polja za intenzitet otkaza i vreme moraju biti popunjena", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb.Checked = false;
                            return;
                        }
                        
                    }

                    else if (cb.Tag.ToString() == "IV")
                    {
                        double lambda;
                        double resenje;

                        if (!string.IsNullOrWhiteSpace(txtLambda.Text) && !string.IsNullOrWhiteSpace(txtEksponent.Text) && !string.IsNullOrWhiteSpace(txtVreme.Text))
                        {
                            lambda = Math.Pow(Convert.ToSingle(txtLambda.Text), Convert.ToInt32(txtEksponent.Text));

                            resenje = (24*365) / (1 / lambda);
                            lblGodOtk.Text = resenje.ToString();

                            panel4.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Polja za intenzitet otkaza i vreme moraju biti popunjena", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb.Checked = false;
                            return;
                        }
                        
                    }

                    else if (cb.Tag.ToString() == "V")
                    {
                        if (!string.IsNullOrWhiteSpace(txtLambda.Text) && !string.IsNullOrWhiteSpace(txtEksponent.Text) && !string.IsNullOrWhiteSpace(txtVreme.Text))
                        {
                            prikazGrafika();
                        }
                        else
                        {
                            MessageBox.Show("Polja za intenzitet otkaza i vreme moraju biti popunjena", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cb.Checked = false;
                            return;
                        }
                    }
                   

                }
                else
                {
                    if (cb.Tag.ToString() == "I")
                        panel1.Visible = false;
                    else if (cb.Tag.ToString() == "II")
                        panel2.Visible = false;
                    else if (cb.Tag.ToString() == "III")
                        panel3.Visible = false;
                    else if (cb.Tag.ToString() == "IV")
                        panel4.Visible = false;
                    else
                        chart1.Visible = false;
                }
            }
        }

        int interval;
        bool odluka;

        void prikazGrafika()
        {
            if (odluka)
                if (!string.IsNullOrWhiteSpace(txtVreme.Text))
                    interval = Convert.ToInt32(txtVreme.Text);
                else
                    return;
                
            else
                interval = Convert.ToInt32(textBox1.Text);

            var chart = chart1.ChartAreas[0];

            chart.AxisX.Minimum = 0;
            chart.AxisX.Maximum = interval;

            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 2;

            chart.AxisX.Interval = interval / 10;
            chart.AxisY.Interval = 0.5;

            chart1.Series["Intenzitet otkaza"].ChartType = SeriesChartType.Line;
            chart1.Series["Intenzitet otkaza"].BorderWidth = 2;
            chart1.Series["Intenzitet otkaza"].Color = Color.Red;

            for (int i = 0; i <= 10; i++)
            {
                chart1.Series["Intenzitet otkaza"].Points.AddXY((interval - (interval / 10) * i), 1);
            }

            chart1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            odluka = false;
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                prikazGrafika();
            }
            else
            {
                MessageBox.Show("Polje iznad dugmeta, odnosno polje za vreme mora biti popunjeno", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void novoVremeZaGrafickiPrikazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ovaj program rešava drugi zadatak sa prvog kolokvijuma. Na osnovu unetih vrednosti za itenzitet otkaza (λ) i vremena, program će izračunati i po želji prikazati:\n\n - Verovatnoću ispravnog rada za uneto vreme\n - Srednje vreme do otkaza\n - Gustinu raspodele vremena rada do otkaza za uneto vreme\n - Broj otkaza za godinu dana i\n - Grafički prikazatai itenzitet otkaza u odnosu na vreme.", "Informacije o programu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            odluka = true;
            prikazGrafika();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double lambda;
            double resenjeR;
            double resenjeT0;
            double resenjeGod;
            double lambdaxT;

            odluka = true;
            
            lambda = Math.Pow(Convert.ToSingle(txtLambda.Text), Convert.ToInt32(txtEksponent.Text));
            lambdaxT = lambda * Convert.ToInt32(txtVreme.Text);

            resenjeR = Math.Round(Math.Pow(Math.E, lambdaxT * -1), 4);
            lblR.Text = resenjeR.ToString();

            resenjeT0 = (1 / lambda);
            lblT0.Text = resenjeT0.ToString() + " [h]";

            resenjeR = Math.Round(Math.Pow(Math.E, lambdaxT * -1), 4);
            lblF.Text = (resenjeR * lambda).ToString();

            resenjeGod = (24 * 365) / (1 / lambda);
            lblGodOtk.Text = resenjeGod.ToString();

            prikazGrafika();

            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
        }

        private void unosNovogVremenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if(panel1.Visible || panel2.Visible || panel3.Visible || panel4.Visible || chart1.Visible)
            {
                screen(this);
                MessageBox.Show("Uspesno ste sačuvali izračunavanja", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Da bi ste mogli izvršiti čuvanje morate imati nešto izračunato!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        void screen (Form frm)
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            
            bool folderExists = Directory.Exists(currentPath + @"\Rezultati");
            if (!folderExists)
                Directory.CreateDirectory(currentPath + @"\Rezultati");

            string ImagePath = string.Format(currentPath + @"\Rezultati\Slika_{0}.png", DateTime.Now.Ticks);
            Bitmap Image = new Bitmap(frm.Width, frm.Height);
            frm.DrawToBitmap(Image, new Rectangle(0, 0, frm.Width, frm.Height));
            Image.Save(ImagePath, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void txtEksponent_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!char.IsDigit(ch) && ch != 8 && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {
            int sirinaSlike = 2 * 10 + Properties.Resources.PouzdanostVerovatnoca.Width;
            int visinaSlike = 2 * 10 + Properties.Resources.PouzdanostVerovatnoca.Height;

            int sirina = e.ToolTipSize.Width + 2 * 10 + sirinaSlike;
            int visina = e.ToolTipSize.Height;
            if (visina < visinaSlike)
                visina = visinaSlike;

            e.ToolTipSize = new Size(sirina, visina);
        }

        private void toolTip2_Draw(object sender, DrawToolTipEventArgs e)
        {
            // Draw the background and border
            e.DrawBackground();
            e.DrawBorder();

            // Prikaz slike
            e.Graphics.DrawImage(Properties.Resources.PouzdanostVerovatnoca, 10, 10);

            // Ispis teksta pored slike
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;

                int sirinaSlike = 2 * 10 + Properties.Resources.PouzdanostVerovatnoca.Width;

                Rectangle rect = new Rectangle(sirinaSlike, 0, e.Bounds.Width - sirinaSlike, e.Bounds.Height);
                e.Graphics.DrawString(e.ToolTipText, e.Font, Brushes.Black, rect, sf);
            }
        }

        private void toolTip3_Draw(object sender, DrawToolTipEventArgs e)
        {
            // Draw the background and border
            e.DrawBackground();
            e.DrawBorder();

            // Prikaz slike
            e.Graphics.DrawImage(Properties.Resources.T0Formula, 10, 10);

            // Ispis teksta pored slike
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;

                int sirinaSlike = 2 * 10 + Properties.Resources.T0Formula.Width;

                Rectangle rect = new Rectangle(sirinaSlike, 0, e.Bounds.Width - sirinaSlike, e.Bounds.Height);
                e.Graphics.DrawString(e.ToolTipText, e.Font, Brushes.Black, rect, sf);
            }
        }

        private void toolTip3_Popup(object sender, PopupEventArgs e)
        {
            int sirinaSlike = 2 * 10 + Properties.Resources.T0Formula.Width;
            int visinaSlike = 2 * 10 + Properties.Resources.T0Formula.Height;

            int sirina = e.ToolTipSize.Width + 2 * 10 + sirinaSlike;
            int visina = e.ToolTipSize.Height;
            if (visina < visinaSlike)
                visina = visinaSlike;

            e.ToolTipSize = new Size(sirina, visina);
        }

        private void toolTip4_Draw(object sender, DrawToolTipEventArgs e)
        {
            // Draw the background and border
            e.DrawBackground();
            e.DrawBorder();

            // Prikaz slike
            e.Graphics.DrawImage(Properties.Resources.GustinaRaspodeleFormula, 10, 10);

            // Ispis teksta pored slike
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Center;

                int sirinaSlike = 2 * 10 + Properties.Resources.GustinaRaspodeleFormula.Width;

                Rectangle rect = new Rectangle(sirinaSlike, 0, e.Bounds.Width - sirinaSlike, e.Bounds.Height);
                e.Graphics.DrawString(e.ToolTipText, e.Font, Brushes.Black, rect, sf);
            }
        }

        private void toolTip4_Popup(object sender, PopupEventArgs e)
        {
            int sirinaSlike = 2 * 10 + Properties.Resources.GustinaRaspodeleFormula.Width;
            int visinaSlike = 2 * 10 + Properties.Resources.GustinaRaspodeleFormula.Height;

            int sirina = e.ToolTipSize.Width + 2 * 10 + sirinaSlike;
            int visina = e.ToolTipSize.Height;
            if (visina < visinaSlike)
                visina = visinaSlike;

            e.ToolTipSize = new Size(sirina, visina);
        }
    }
}
