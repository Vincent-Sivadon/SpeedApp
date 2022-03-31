using System;
using System.Drawing;

namespace SpeedApp
{
    partial class Form1
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

        public void newPlayerLabel(string name, int pos)
        {
            // Create Label
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(140)))), ((int)(((byte)(163)))));
            label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label.Dock = System.Windows.Forms.DockStyle.Top;
            label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = System.Drawing.Color.Black;
            label.Location = new System.Drawing.Point(0, 0);
            label.Margin = new System.Windows.Forms.Padding(0);
            label.Size = new System.Drawing.Size(263, 31);
            label.TabIndex = 5;
            label.Text = name;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label.Click += new System.EventHandler(this.playerLabel_Click);
            label.Name = name;

            // Add it to panel
            if (pos == 0)
            {
                this.planningView.FstJoueurPanel.Controls.Add(label);
                this.planningView.FstJoueurPanel.Controls.SetChildIndex(label, 0);
            }
            else
            {
                this.planningView.ScJoueurPanel.Controls.Add(label);
                this.planningView.ScJoueurPanel.Controls.SetChildIndex(label, 0);
            }
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.filepathButton = new System.Windows.Forms.Button();
            this.windowsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.planningButton = new System.Windows.Forms.Button();
            this.finalesButton = new System.Windows.Forms.Button();
            this.nbTerTextBox = new System.Windows.Forms.TextBox();
            this.nbTerLabel = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.rightPanel = new System.Windows.Forms.Panel();
            this.planningView = new SpeedApp.PlanningView();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.windowsSplitContainer)).BeginInit();
            this.windowsSplitContainer.Panel1.SuspendLayout();
            this.windowsSplitContainer.Panel2.SuspendLayout();
            this.windowsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.rightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.leftPanel.Controls.Add(this.filepathButton);
            this.leftPanel.Controls.Add(this.windowsSplitContainer);
            this.leftPanel.Controls.Add(this.nbTerTextBox);
            this.leftPanel.Controls.Add(this.nbTerLabel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(296, 607);
            this.leftPanel.TabIndex = 4;
            // 
            // filepathButton
            // 
            this.filepathButton.AutoSize = true;
            this.filepathButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(25)))));
            this.filepathButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.filepathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filepathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filepathButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.filepathButton.Location = new System.Drawing.Point(0, 135);
            this.filepathButton.Name = "filepathButton";
            this.filepathButton.Size = new System.Drawing.Size(296, 24);
            this.filepathButton.TabIndex = 10;
            this.filepathButton.UseVisualStyleBackColor = false;
            this.filepathButton.Click += new System.EventHandler(this.filepathButton_Click);
            // 
            // windowsSplitContainer
            // 
            this.windowsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowsSplitContainer.Location = new System.Drawing.Point(0, 135);
            this.windowsSplitContainer.Name = "windowsSplitContainer";
            this.windowsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // windowsSplitContainer.Panel1
            // 
            this.windowsSplitContainer.Panel1.Controls.Add(this.planningButton);
            // 
            // windowsSplitContainer.Panel2
            // 
            this.windowsSplitContainer.Panel2.Controls.Add(this.finalesButton);
            this.windowsSplitContainer.Size = new System.Drawing.Size(296, 472);
            this.windowsSplitContainer.SplitterDistance = 236;
            this.windowsSplitContainer.TabIndex = 2;
            // 
            // planningButton
            // 
            this.planningButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(29)))), ((int)(((byte)(50)))));
            this.planningButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.planningButton.FlatAppearance.BorderSize = 0;
            this.planningButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.planningButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.planningButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.planningButton.Location = new System.Drawing.Point(0, 0);
            this.planningButton.Margin = new System.Windows.Forms.Padding(0);
            this.planningButton.Name = "planningButton";
            this.planningButton.Size = new System.Drawing.Size(296, 236);
            this.planningButton.TabIndex = 1;
            this.planningButton.Text = "Planning";
            this.planningButton.UseVisualStyleBackColor = false;
            this.planningButton.Click += new System.EventHandler(this.planningButton_Click);
            // 
            // finalesButton
            // 
            this.finalesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(29)))), ((int)(((byte)(50)))));
            this.finalesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finalesButton.FlatAppearance.BorderSize = 0;
            this.finalesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finalesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.finalesButton.ForeColor = System.Drawing.Color.Gainsboro;
            this.finalesButton.Location = new System.Drawing.Point(0, 0);
            this.finalesButton.Margin = new System.Windows.Forms.Padding(0);
            this.finalesButton.Name = "finalesButton";
            this.finalesButton.Size = new System.Drawing.Size(296, 232);
            this.finalesButton.TabIndex = 2;
            this.finalesButton.Text = "Brackets";
            this.finalesButton.UseVisualStyleBackColor = false;
            this.finalesButton.Click += new System.EventHandler(this.finalesButton_Click);
            // 
            // nbTerTextBox
            // 
            this.nbTerTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(25)))));
            this.nbTerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nbTerTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.nbTerTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.nbTerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbTerTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.nbTerTextBox.Location = new System.Drawing.Point(0, 113);
            this.nbTerTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.nbTerTextBox.Name = "nbTerTextBox";
            this.nbTerTextBox.Size = new System.Drawing.Size(296, 22);
            this.nbTerTextBox.TabIndex = 1;
            this.nbTerTextBox.Text = "3";
            this.nbTerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nbTerTextBox.TextChanged += new System.EventHandler(this.nbTer_TextChanged);
            // 
            // nbTerLabel
            // 
            this.nbTerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(29)))), ((int)(((byte)(50)))));
            this.nbTerLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nbTerLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nbTerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nbTerLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.nbTerLabel.Location = new System.Drawing.Point(0, 0);
            this.nbTerLabel.Name = "nbTerLabel";
            this.nbTerLabel.Size = new System.Drawing.Size(296, 113);
            this.nbTerLabel.TabIndex = 0;
            this.nbTerLabel.Text = "Nombre\r\nde\r\nTerrains";
            this.nbTerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.planningView);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(296, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(780, 607);
            this.rightPanel.TabIndex = 11;
            // 
            // planningView
            // 
            this.planningView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.planningView.Location = new System.Drawing.Point(0, 0);
            this.planningView.Name = "planningView";
            this.planningView.Size = new System.Drawing.Size(780, 607);
            this.planningView.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 607);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Text = "Planning Speed";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.windowsSplitContainer.Panel1.ResumeLayout(false);
            this.windowsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.windowsSplitContainer)).EndInit();
            this.windowsSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Label nbTerLabel;
        private System.Windows.Forms.TextBox nbTerTextBox;
        private System.Windows.Forms.Button planningButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.SplitContainer windowsSplitContainer;
        private System.Windows.Forms.Button finalesButton;
        private PlanningView planningView;
        private System.Windows.Forms.Panel rightPanel;
        private Brackets brackets;
        private System.Windows.Forms.Button filepathButton;
    }
}

