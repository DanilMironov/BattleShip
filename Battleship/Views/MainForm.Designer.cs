using System.Drawing;
using System.Windows.Forms;

namespace Battleship.Views
{
    partial class MainForm
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
            this.placingControl = new PlacingControl();
            this.startControl = new StartControl();
            this.battleControl = new BattleControl();
            this.finishControl = new FinishControl();
            this.SuspendLayout();
            //
            // FinishControl
            //
            this.finishControl.Dock = DockStyle.Fill;
            this.finishControl.Location = new Point(0, 0);
            this.finishControl.Name = "finishControl";
            this.finishControl.Size = new Size(800, 600);
            this.finishControl.TabIndex = 3;
            //
            // PlacingControl
            //
            this.placingControl.Dock = DockStyle.Fill;
            this.placingControl.Location = new Point(0, 0);
            this.placingControl.Name = "placingControl";
            this.placingControl.Size = new Size(800, 600);
            this.placingControl.TabIndex = 1;

            //
            // BattleControl
            //
            this.battleControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.battleControl.Location = new Point(0, 0);
            this.battleControl.Name = "battleControl";
            this.battleControl.Size = new Size(800, 600);
            this.battleControl.TabIndex = 0;
            //
            // StartControl
            //
            this.startControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startControl.Location = new Point(0, 0);
            this.startControl.Name = "startControl";
            this.startControl.Size = new Size(800, 600);  // должна вернуть размер текущего активного окна
            this.startControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.startControl);
            this.Controls.Add(this.battleControl);
            this.Controls.Add(this.placingControl);
            this.Controls.Add(this.finishControl);
            this.Name = "MainForm";
            this.Text = "BattleShip";
            this.ResumeLayout(false);

        }

        #endregion

        private StartControl startControl;
        private BattleControl battleControl;
        private PlacingControl placingControl;
        private FinishControl finishControl;
    }
}

