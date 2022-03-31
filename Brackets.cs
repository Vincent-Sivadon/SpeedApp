using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SpeedApp
{
    public partial class Brackets : UserControl
    {
        private Point[] labelPositions;
        private int widthUnit, heightUnit;
        private Color color1 = Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(140)))), ((int)(((byte)(163)))));
        private Color color2 = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(115)))), ((int)(((byte)(138)))));

        private void GetPositions()
        {
            // Allocation
            labelPositions = new Point[16];

            // Initialize Label positions
            for (int i = 0; i < 8; i++)
                labelPositions[i] = new Point(0, i * heightUnit);
            for (int i = 8; i < 12; i++)
                labelPositions[i] = new Point(widthUnit, (i - 8) * 2 * heightUnit);
            for (int i = 12; i < 14; i++)
                labelPositions[i] = new Point(2 * widthUnit, (i - 12) * 4 * heightUnit);
            for (int i = 14; i < 16; i++)
                labelPositions[i] = new Point(3 * widthUnit, (i - 14) * 8 * heightUnit);
        }

        private Label NewLabel(int i)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Visible = true;
            label.Dock = DockStyle.None;
            label.Text = "...";
            label.Name = i.ToString();
            label.BackColor = Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(140)))), ((int)(((byte)(163)))));
            label.BorderStyle = BorderStyle.FixedSingle;
            label.FlatStyle = FlatStyle.Flat;
            label.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label.ForeColor = Color.Black;
            label.Margin = new Padding(0);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.DoubleClick += Label_DoubleClick;
            label.MouseClick += Label_Click;

            return label;
        }

        private void Label_Click(object sender, MouseEventArgs e)
        {
            // We want only Right Clicks
            if (e.Button == MouseButtons.Left) return;

            Label label = sender as Label;

            if (label.BackColor == color1) label.BackColor = color2;
            else if (label.BackColor == color2) label.BackColor = color1;
        }

        private TextBox NewTextBox(int i)
        {
            TextBox textBox = new TextBox();
            textBox.Size = playersLabels[i].Size;
            textBox.Location = playersLabels[i].Location;
            textBox.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
            textBox.Text = "nom";
            textBox.Name = i.ToString();
            textBox.BackColor = Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(100)))), ((int)(((byte)(120)))));
            textBox.ForeColor = Color.Gainsboro;
            textBox.BorderStyle = BorderStyle.None;
            textBox.KeyDown += TextBox_KeyDown;

            return textBox;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            TextBox textBox = sender as TextBox;

            // Get textBox text informations
            string newName = textBox.Text;
            if (newName == String.Empty) newName = "...";

            // Remove textbox
            Controls.Remove(textBox);

            // Add corresponding Label, changing it's text
            int index = int.Parse(textBox.Name);
            playersLabels[index].Text = newName;
            Controls.Add(playersLabels[index]);

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        // Give the possibility to change the name
        private void Label_DoubleClick(object sender, EventArgs e)
        {
            // Get label and index
            Label label = sender as Label;
            int index = Array.IndexOf(playersLabels, label);

            // Create new TextBox
            TextBox textBox = NewTextBox(index);
            Controls.Add(textBox);
            textBox.BringToFront();
            textBox.Focus();
        }

        public void Resize()
        {
            // Unit
            heightUnit = Height / 8;
            widthUnit = Width / 4;

            //
            GetPositions();

            // Locations
            for (int i=0; i<16; i++)
                playersLabels[i].Location = labelPositions[i];

            // Sizes
            for (int i = 0; i < 8; i++)
                playersLabels[i].Size = new Size(widthUnit, heightUnit);
            for (int i = 8; i < 12; i++)
                playersLabels[i].Size = new Size(widthUnit, 2 * heightUnit);
            for (int i = 12; i < 14; i++)
                playersLabels[i].Size = new Size(widthUnit, 4 * heightUnit);
            for (int i = 14; i < 16; i++)
                playersLabels[i].Size = new Size(widthUnit, 8 * heightUnit);

        }


        public Brackets()
        {
            InitializeComponent();

            //
            playersLabels = new Label[16];

            // Create Labels
            GetPositions();
            for (int i = 0; i < 16; i++)
                playersLabels[i] = NewLabel(i);
            Controls.AddRange(playersLabels);

            Resize();
        }
    }
}
