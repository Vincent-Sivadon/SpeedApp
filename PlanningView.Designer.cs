using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SpeedApp
{

    partial class PlanningView
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.FstJoueurPanel = new System.Windows.Forms.Panel();
            this.ScJoueurPanel = new System.Windows.Forms.Panel();
            this.matchListScrollbar = new System.Windows.Forms.VScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.FstJoueurPanel);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.ScJoueurPanel);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Size = new System.Drawing.Size(628, 449);
            this.splitContainer.SplitterDistance = 312;
            this.splitContainer.TabIndex = 10;
            // 
            // FstJoueurPanel
            // 
            this.FstJoueurPanel.AutoScroll = true;
            this.FstJoueurPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(140)))), ((int)(((byte)(163)))));
            this.FstJoueurPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FstJoueurPanel.Location = new System.Drawing.Point(0, 0);
            this.FstJoueurPanel.Name = "FstJoueurPanel";
            this.FstJoueurPanel.Size = new System.Drawing.Size(312, 449);
            this.FstJoueurPanel.TabIndex = 6;
            // 
            // ScJoueurPanel
            // 
            this.ScJoueurPanel.AutoScroll = true;
            this.ScJoueurPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(140)))), ((int)(((byte)(163)))));
            this.ScJoueurPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScJoueurPanel.Location = new System.Drawing.Point(0, 0);
            this.ScJoueurPanel.Name = "ScJoueurPanel";
            this.ScJoueurPanel.Size = new System.Drawing.Size(312, 449);
            this.ScJoueurPanel.TabIndex = 7;
            // 
            // matchListScrollbar
            // 
            this.matchListScrollbar.Dock = System.Windows.Forms.DockStyle.Right;
            this.matchListScrollbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.matchListScrollbar.LargeChange = 50;
            this.matchListScrollbar.Location = new System.Drawing.Point(628, 0);
            this.matchListScrollbar.Name = "matchListScrollbar";
            this.matchListScrollbar.Size = new System.Drawing.Size(27, 449);
            this.matchListScrollbar.SmallChange = 20;
            this.matchListScrollbar.TabIndex = 11;
            this.matchListScrollbar.Value = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer);
            this.panel1.Controls.Add(this.matchListScrollbar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 449);
            this.panel1.TabIndex = 0;
            // 
            // PlanningView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "PlanningView";
            this.Size = new System.Drawing.Size(655, 449);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

            // Scroll Event Handler
            matchListScrollbar.Scroll += new ScrollEventHandler(Scrolled);
        }

        #endregion

        public SplitContainer splitContainer;
        public Panel FstJoueurPanel;
        public Panel ScJoueurPanel;
        public VScrollBar matchListScrollbar;
        private Panel panel1;

        // Scroll Event
        public event ScrollEventHandler ScrollEvent;
        protected void Scrolled(object sender, ScrollEventArgs e)
        {
            if (this.ScrollEvent != null)
                this.ScrollEvent(this, e);
        }




    }
}
