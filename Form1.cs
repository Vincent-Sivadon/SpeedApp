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
using Microsoft.VisualBasic;

namespace SpeedApp
{
    public partial class Form1 : Form
    {
        Planning planning;
        private int nbTerrains;
        private Color color1 = Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(140)))), ((int)(((byte)(163)))));
        private Color color2 = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));
        private Color color3 = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(115)))), ((int)(((byte)(163)))));


        private void MakePlanning()
        {
            // Open "poules.txt"
            string filepath = OpenFile();
            if (filepath == String.Empty)
                return;

            // Create planning
            planningView.FstJoueurPanel.Controls.Clear();
            planningView.ScJoueurPanel.Controls.Clear();
            planning = new Planning(this, filepath, nbTerrains);
        }

        public string OpenFile()
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                }
            }

            return filePath;
        }

        public Form1()
        {
            InitializeComponent();

            // Init Scrollbar
            planningView.matchListScrollbar.Value = planningView.FstJoueurPanel.VerticalScroll.Value;
            planningView.matchListScrollbar.Minimum = planningView.FstJoueurPanel.VerticalScroll.Minimum;
            planningView.matchListScrollbar.Maximum = planningView.FstJoueurPanel.VerticalScroll.Maximum;
            planningView.FstJoueurPanel.ControlAdded += FstJoueurPanel_ControlAdded;

            //
            planningView.ScrollEvent += new ScrollEventHandler(matchListScrollbar_Scroll);

            // Init filepathButton
            filepathButton.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\poules.txt";
            nbTerrains = int.Parse(nbTerTextBox.Text);
            if (File.Exists(filepathButton.Text)) { planning = new Planning(this, filepathButton.Text, nbTerrains); }

            this.ActiveControl = planningView;

        }

        private void FstJoueurPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            planningView.matchListScrollbar.Maximum = planningView.FstJoueurPanel.VerticalScroll.Maximum;
            planningView.matchListScrollbar.LargeChange = planningView.FstJoueurPanel.VerticalScroll.LargeChange;
        }

        private async void planningButton_Click(object sender, EventArgs e)
        {
            Button planningButton = sender as Button;

            if (brackets != null)
            {
                brackets.Hide();
                rightPanel.Controls.Remove(brackets);
            }

            rightPanel.Controls.Add(planningView);
            planningView.Show();
        }


        private void nbTer_TextChanged(object sender, EventArgs e)
        {
            if (nbTerTextBox.Text != "") nbTerrains = int.Parse(nbTerTextBox.Text);
        }

        private void playerLabel_Click(object sender, EventArgs e)
        {
            Color colorPoule;
            Color colorPlayer;

            // Get this label name
            Label label = sender as Label;
            string playerName = label.Text;

            // Find all labels of the same name (construct allSameLabels)
            Control[] allSameLabelsFst = planningView.FstJoueurPanel.Controls.Find(playerName, true);
            Control[] allSameLabelsSc = planningView.ScJoueurPanel.Controls.Find(playerName, true);
            int nbOfSameLabelsFst = allSameLabelsFst.Length;
            int nbOfSameLabelsSc = allSameLabelsSc.Length;
            Control[] allSameLabels = new Control[nbOfSameLabelsFst + nbOfSameLabelsSc];
            for (int i=0 ; i < nbOfSameLabelsFst; i++)
                allSameLabels[i] = allSameLabelsFst[i];
            for (int i = 0; i < nbOfSameLabelsSc; i++)
                allSameLabels[i + nbOfSameLabelsFst] = allSameLabelsSc[i];

            if (allSameLabels[0].BackColor == color2 || allSameLabels[0].BackColor == color3)
            {
                colorPoule = color1;
                colorPlayer = color1;
            }
            else
            {
                colorPoule = color2;
                colorPlayer = color3;
            }

            // find Player corresponding
            Player player = planning.players.Find(r=> r.name == playerName);
            int pouleID = player.poule;

            // Search for players in the same poule
            IEnumerable<Player> samePoulePlayers = planning.players.FindAll(r => r.poule == pouleID);

            // For all players in this poule
            foreach(Player p in samePoulePlayers)
            {
                // Find all corresponding labels
                Control[] labelsFst = planningView.FstJoueurPanel.Controls.Find(p.name, true);
                Control[] labelsSc = planningView.ScJoueurPanel.Controls.Find(p.name, true);

                // For all of these labels in fstPanel, change backColor
                foreach (Control c in labelsFst)
                    c.BackColor = colorPoule;

                // For all of these labels in ScPanel, change backColor
                foreach (Control c in labelsSc)
                    c.BackColor = colorPoule;
            }

            foreach (Control c in allSameLabelsFst)
                c.BackColor = colorPlayer;
            foreach (Control c in allSameLabelsSc)
                c.BackColor = colorPlayer;
        }

        private void finalesButton_Click(object sender, EventArgs e)
        {
            if (brackets == null)
            {
                brackets = new Brackets();
                brackets.Dock = DockStyle.Fill;
            }

            planningView.Hide();
            rightPanel.Controls.Remove(planningView);
            rightPanel.Controls.Add(brackets);
            brackets.Resize();
            brackets.Show();
        }

        public void matchListScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            planningView.FstJoueurPanel.VerticalScroll.Value = planningView.matchListScrollbar.Value;
            planningView.ScJoueurPanel.VerticalScroll.Value = planningView.matchListScrollbar.Value;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (brackets != null) brackets.Resize();
        }

        private void filepathButton_Click(object sender, EventArgs e)
        {
            MakePlanning();
        }
    }
}
