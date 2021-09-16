
namespace Battleship.Views
{
    partial class PlacingControl
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
            this.header = new System.Windows.Forms.Panel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.footer = new System.Windows.Forms.Panel();
            this.endButton = new System.Windows.Forms.Button();
            this.fieldControl = new Battleship.Views.FieldControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.header.SuspendLayout();
            this.footer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.Controls.Add(this.headerLabel);
            this.header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.header.Location = new System.Drawing.Point(203, 3);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(394, 94);
            this.header.TabIndex = 0;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Location = new System.Drawing.Point(97, 41);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(167, 20);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Разместите корабли";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // footer
            // 
            this.footer.Controls.Add(this.endButton);
            this.footer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.footer.Location = new System.Drawing.Point(203, 503);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(394, 100);
            this.footer.TabIndex = 1;
            // 
            // endButton
            // 
            this.endButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.endButton.Location = new System.Drawing.Point(0, 0);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(394, 100);
            this.endButton.TabIndex = 0;
            this.endButton.Text = "Ок";
            this.endButton.UseVisualStyleBackColor = true;
            // 
            // fieldControl
            // 
            this.fieldControl.BackColor = System.Drawing.SystemColors.ControlDark;
            this.fieldControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldControl.Location = new System.Drawing.Point(203, 103);
            this.fieldControl.Name = "fieldControl";
            this.fieldControl.Size = new System.Drawing.Size(394, 394);
            this.fieldControl.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.header, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.footer, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.fieldControl, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // PlacingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "PlacingControl";
            this.Size = new System.Drawing.Size(800, 600);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.footer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Panel footer;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Label headerLabel;
        private FieldControl fieldControl;
    }
}
