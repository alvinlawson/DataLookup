namespace DataLookup
{
    partial class nameSearchUC
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
            this.firstNameLBox = new System.Windows.Forms.ListBox();
            this.surnameLBox = new System.Windows.Forms.ListBox();
            this.firstNamesLB = new System.Windows.Forms.Label();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // firstNameLBox
            // 
            this.firstNameLBox.FormattingEnabled = true;
            this.firstNameLBox.Location = new System.Drawing.Point(14, 92);
            this.firstNameLBox.Name = "firstNameLBox";
            this.firstNameLBox.Size = new System.Drawing.Size(231, 160);
            this.firstNameLBox.TabIndex = 0;
            this.firstNameLBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // surnameLBox
            // 
            this.surnameLBox.FormattingEnabled = true;
            this.surnameLBox.Location = new System.Drawing.Point(14, 286);
            this.surnameLBox.Name = "surnameLBox";
            this.surnameLBox.Size = new System.Drawing.Size(231, 160);
            this.surnameLBox.TabIndex = 1;
            // 
            // firstNamesLB
            // 
            this.firstNamesLB.AutoSize = true;
            this.firstNamesLB.Location = new System.Drawing.Point(11, 76);
            this.firstNamesLB.Name = "firstNamesLB";
            this.firstNamesLB.Size = new System.Drawing.Size(71, 13);
            this.firstNamesLB.TabIndex = 2;
            this.firstNamesLB.Text = "First Names 1";
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(11, 270);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(54, 13);
            this.surnameLabel.TabIndex = 3;
            this.surnameLabel.Text = "Surnames";
            // 
            // nameSearchUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.surnameLabel);
            this.Controls.Add(this.firstNamesLB);
            this.Controls.Add(this.surnameLBox);
            this.Controls.Add(this.firstNameLBox);
            this.Name = "nameSearchUC";
            this.Size = new System.Drawing.Size(262, 496);
            this.Load += new System.EventHandler(this.nameSearchUC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox firstNameLBox;
        private System.Windows.Forms.ListBox surnameLBox;
        private System.Windows.Forms.Label firstNamesLB;
        private System.Windows.Forms.Label surnameLabel;
    }
}
