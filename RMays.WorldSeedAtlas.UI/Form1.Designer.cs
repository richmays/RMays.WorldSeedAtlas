namespace RMays.WorldSeedAtlas.UI
{
    partial class Form1
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
            this.txtStartingPosition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.chkHideCheckedLocations = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtStartingPosition
            // 
            this.txtStartingPosition.Location = new System.Drawing.Point(104, 6);
            this.txtStartingPosition.Name = "txtStartingPosition";
            this.txtStartingPosition.Size = new System.Drawing.Size(130, 20);
            this.txtStartingPosition.TabIndex = 0;
            this.txtStartingPosition.TextChanged += new System.EventHandler(this.txtStartingPosition_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Position:";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(15, 62);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(219, 334);
            this.checkedListBox1.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(159, 32);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // chkHideCheckedLocations
            // 
            this.chkHideCheckedLocations.AutoSize = true;
            this.chkHideCheckedLocations.Location = new System.Drawing.Point(15, 36);
            this.chkHideCheckedLocations.Name = "chkHideCheckedLocations";
            this.chkHideCheckedLocations.Size = new System.Drawing.Size(138, 17);
            this.chkHideCheckedLocations.TabIndex = 4;
            this.chkHideCheckedLocations.Text = "Hide checked locations";
            this.chkHideCheckedLocations.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 407);
            this.Controls.Add(this.chkHideCheckedLocations);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStartingPosition);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStartingPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chkHideCheckedLocations;
    }
}

