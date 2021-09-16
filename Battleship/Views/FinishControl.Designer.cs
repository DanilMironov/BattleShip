
namespace Battleship.Views
{
    partial class FinishControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.winLabel = new System.Windows.Forms.Label();
            this.humanFieldControl = new Battleship.Views.FieldControl();
            this.opponentFieldControl = new Battleship.Views.FieldControl();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel.Controls.Add(this.winLabel, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.humanFieldControl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.opponentFieldControl, 2, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.winLabel.Location = new System.Drawing.Point(303, 0);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(194, 100);
            this.winLabel.TabIndex = 0;
            this.winLabel.Text = "Победа";
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // humanFieldControl
            // 
            this.humanFieldControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.humanFieldControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.humanFieldControl.Location = new System.Drawing.Point(303, 103);
            this.humanFieldControl.Name = "humanFieldControl";
            this.humanFieldControl.Size = new System.Drawing.Size(194, 294);
            this.humanFieldControl.TabIndex = 1;
            // 
            // opponentFieldControl
            // 
            this.opponentFieldControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.opponentFieldControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opponentFieldControl.Location = new System.Drawing.Point(503, 103);
            this.opponentFieldControl.Name = "opponentFieldControl";
            this.opponentFieldControl.Size = new System.Drawing.Size(294, 294);
            this.opponentFieldControl.TabIndex = 2;
            // 
            // FinishControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FinishControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label winLabel;
        private FieldControl humanFieldControl;
        private FieldControl opponentFieldControl;
    }
}
