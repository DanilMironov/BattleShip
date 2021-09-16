
namespace Battleship.Views
{
    partial class BattleControl
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
            this.battleLableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.aIFieldControl = new Battleship.Views.FieldControl();
            this.hFieldControl = new Battleship.Views.FieldControl();
            this.battleLableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // battleLableLayoutPanel
            // 
            this.battleLableLayoutPanel.ColumnCount = 3;
            this.battleLableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.battleLableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.battleLableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.battleLableLayoutPanel.Controls.Add(this.aIFieldControl, 1, 1);
            this.battleLableLayoutPanel.Controls.Add(this.hFieldControl, 0, 0);
            this.battleLableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.battleLableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.battleLableLayoutPanel.Name = "battleLableLayoutPanel";
            this.battleLableLayoutPanel.RowCount = 3;
            this.battleLableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.battleLableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.battleLableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.battleLableLayoutPanel.Size = new System.Drawing.Size(800, 600);
            this.battleLableLayoutPanel.TabIndex = 0;
            // 
            // aIFieldControl
            // 
            this.aIFieldControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.aIFieldControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aIFieldControl.Location = new System.Drawing.Point(5, 5);
            this.aIFieldControl.Margin = new System.Windows.Forms.Padding(5);
            this.aIFieldControl.Name = "aIFieldControl";
            this.aIFieldControl.Size = new System.Drawing.Size(190, 190);
            this.aIFieldControl.TabIndex = 0;
            // 
            // hFieldControl
            // 
            this.hFieldControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.hFieldControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hFieldControl.Location = new System.Drawing.Point(210, 210);
            this.hFieldControl.Margin = new System.Windows.Forms.Padding(10);
            this.hFieldControl.Name = "hFieldControl";
            this.hFieldControl.Size = new System.Drawing.Size(380, 380);
            this.hFieldControl.TabIndex = 1;
            // 
            // BattleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.battleLableLayoutPanel);
            this.Name = "BattleControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.battleLableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel battleLableLayoutPanel;
        private FieldControl hFieldControl;
        private FieldControl aIFieldControl;
    }
}
