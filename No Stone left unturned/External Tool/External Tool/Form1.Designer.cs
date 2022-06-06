namespace External_Tool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CharacterSelectionLabel = new System.Windows.Forms.Label();
            this.godNamePickerLabel = new System.Windows.Forms.Label();
            this.godsNameTextbox = new System.Windows.Forms.TextBox();
            this.godsHealthandAttackLabel = new System.Windows.Forms.Label();
            this.GodAbilityLabel = new System.Windows.Forms.Label();
            this.AbilitySelectorComboBox = new System.Windows.Forms.ComboBox();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.HealthDisplayLabel = new System.Windows.Forms.Label();
            this.GodHealthSlider = new System.Windows.Forms.TrackBar();
            this.DoneButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.healthLabel = new System.Windows.Forms.Label();
            this.attackSlider = new System.Windows.Forms.TrackBar();
            this.attackLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totalPointLabel = new System.Windows.Forms.Label();
            this.pointsLeftLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.godToReplaceLabel = new System.Windows.Forms.Label();
            this.godToReplaceComboBox = new System.Windows.Forms.ComboBox();
            this.GodSelcterPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GodHealthSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GodSelcterPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CharacterSelectionLabel
            // 
            this.CharacterSelectionLabel.AutoSize = true;
            this.CharacterSelectionLabel.Font = new System.Drawing.Font("Rage Italic", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharacterSelectionLabel.Location = new System.Drawing.Point(321, 15);
            this.CharacterSelectionLabel.Name = "CharacterSelectionLabel";
            this.CharacterSelectionLabel.Size = new System.Drawing.Size(1110, 105);
            this.CharacterSelectionLabel.TabIndex = 0;
            this.CharacterSelectionLabel.Text = "Select what your God will look like!";
            // 
            // godNamePickerLabel
            // 
            this.godNamePickerLabel.AutoSize = true;
            this.godNamePickerLabel.Font = new System.Drawing.Font("Rage Italic", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.godNamePickerLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.godNamePickerLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.godNamePickerLabel.Location = new System.Drawing.Point(1279, 145);
            this.godNamePickerLabel.Name = "godNamePickerLabel";
            this.godNamePickerLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.godNamePickerLabel.Size = new System.Drawing.Size(445, 84);
            this.godNamePickerLabel.TabIndex = 2;
            this.godNamePickerLabel.Text = "Your Gods Name";
            // 
            // godsNameTextbox
            // 
            this.godsNameTextbox.Font = new System.Drawing.Font("Rage Italic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.godsNameTextbox.Location = new System.Drawing.Point(1356, 252);
            this.godsNameTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.godsNameTextbox.Name = "godsNameTextbox";
            this.godsNameTextbox.Size = new System.Drawing.Size(259, 49);
            this.godsNameTextbox.TabIndex = 3;
            // 
            // godsHealthandAttackLabel
            // 
            this.godsHealthandAttackLabel.Font = new System.Drawing.Font("Rage Italic", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.godsHealthandAttackLabel.Location = new System.Drawing.Point(27, 210);
            this.godsHealthandAttackLabel.Name = "godsHealthandAttackLabel";
            this.godsHealthandAttackLabel.Size = new System.Drawing.Size(603, 84);
            this.godsHealthandAttackLabel.TabIndex = 4;
            this.godsHealthandAttackLabel.Text = "Your Gods Health and Attack";
            // 
            // GodAbilityLabel
            // 
            this.GodAbilityLabel.AutoSize = true;
            this.GodAbilityLabel.Font = new System.Drawing.Font("Rage Italic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GodAbilityLabel.Location = new System.Drawing.Point(1294, 350);
            this.GodAbilityLabel.Name = "GodAbilityLabel";
            this.GodAbilityLabel.Size = new System.Drawing.Size(431, 76);
            this.GodAbilityLabel.TabIndex = 6;
            this.GodAbilityLabel.Text = "Your God\'s ability";
            // 
            // AbilitySelectorComboBox
            // 
            this.AbilitySelectorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AbilitySelectorComboBox.Font = new System.Drawing.Font("Rage Italic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AbilitySelectorComboBox.FormattingEnabled = true;
            this.AbilitySelectorComboBox.Items.AddRange(new object[] {
            "Taunt - 50",
            "Heal - 20",
            "Lightning - 25",
            "Water - 30",
            "Burn - 35",
            "SelfDamage - 50"});
            this.AbilitySelectorComboBox.Location = new System.Drawing.Point(1299, 467);
            this.AbilitySelectorComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AbilitySelectorComboBox.Name = "AbilitySelectorComboBox";
            this.AbilitySelectorComboBox.Size = new System.Drawing.Size(393, 42);
            this.AbilitySelectorComboBox.TabIndex = 7;
            this.AbilitySelectorComboBox.SelectedIndexChanged += new System.EventHandler(this.AbilitySelectorComboBox_SelectedIndexChanged);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Font = new System.Drawing.Font("Rage Italic", 24F, System.Drawing.FontStyle.Bold);
            this.PreviousButton.Location = new System.Drawing.Point(687, 846);
            this.PreviousButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(187, 119);
            this.PreviousButton.TabIndex = 8;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Font = new System.Drawing.Font("Rage Italic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(993, 846);
            this.NextButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(187, 119);
            this.NextButton.TabIndex = 9;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // HealthDisplayLabel
            // 
            this.HealthDisplayLabel.AutoSize = true;
            this.HealthDisplayLabel.Font = new System.Drawing.Font("Rage Italic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealthDisplayLabel.Location = new System.Drawing.Point(268, 343);
            this.HealthDisplayLabel.Name = "HealthDisplayLabel";
            this.HealthDisplayLabel.Size = new System.Drawing.Size(37, 43);
            this.HealthDisplayLabel.TabIndex = 11;
            this.HealthDisplayLabel.Text = "0";
            // 
            // GodHealthSlider
            // 
            this.GodHealthSlider.LargeChange = 1;
            this.GodHealthSlider.Location = new System.Drawing.Point(37, 408);
            this.GodHealthSlider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GodHealthSlider.Maximum = 200;
            this.GodHealthSlider.Name = "GodHealthSlider";
            this.GodHealthSlider.RightToLeftLayout = true;
            this.GodHealthSlider.Size = new System.Drawing.Size(496, 56);
            this.GodHealthSlider.TabIndex = 1;
            this.GodHealthSlider.TickFrequency = 20;
            this.GodHealthSlider.Scroll += new System.EventHandler(this.GodHealthSlider_Scroll);
            // 
            // DoneButton
            // 
            this.DoneButton.Font = new System.Drawing.Font("Rage Italic", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneButton.Location = new System.Drawing.Point(1364, 829);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(286, 150);
            this.DoneButton.TabIndex = 13;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.SynchronizingObject = this;
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Font = new System.Drawing.Font("Rage Italic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthLabel.Location = new System.Drawing.Point(51, 343);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(104, 42);
            this.healthLabel.TabIndex = 15;
            this.healthLabel.Text = "Health";
            // 
            // attackSlider
            // 
            this.attackSlider.LargeChange = 50;
            this.attackSlider.Location = new System.Drawing.Point(37, 598);
            this.attackSlider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.attackSlider.Maximum = 200;
            this.attackSlider.Name = "attackSlider";
            this.attackSlider.Size = new System.Drawing.Size(496, 56);
            this.attackSlider.TabIndex = 16;
            this.attackSlider.TickFrequency = 20;
            this.attackSlider.Scroll += new System.EventHandler(this.attackSlider_Scroll);
            // 
            // attackLabel
            // 
            this.attackLabel.AutoSize = true;
            this.attackLabel.Font = new System.Drawing.Font("Rage Italic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackLabel.Location = new System.Drawing.Point(51, 527);
            this.attackLabel.Name = "attackLabel";
            this.attackLabel.Size = new System.Drawing.Size(101, 42);
            this.attackLabel.TabIndex = 17;
            this.attackLabel.Text = "Attack";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rage Italic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(268, 527);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 43);
            this.label4.TabIndex = 18;
            this.label4.Text = "0";
            // 
            // totalPointLabel
            // 
            this.totalPointLabel.AutoSize = true;
            this.totalPointLabel.Font = new System.Drawing.Font("Rage Italic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPointLabel.Location = new System.Drawing.Point(30, 706);
            this.totalPointLabel.Name = "totalPointLabel";
            this.totalPointLabel.Size = new System.Drawing.Size(236, 37);
            this.totalPointLabel.TabIndex = 19;
            this.totalPointLabel.Text = "Total Points Used:";
            // 
            // pointsLeftLabel
            // 
            this.pointsLeftLabel.AutoSize = true;
            this.pointsLeftLabel.Font = new System.Drawing.Font("Rage Italic", 18F, System.Drawing.FontStyle.Bold);
            this.pointsLeftLabel.Location = new System.Drawing.Point(284, 706);
            this.pointsLeftLabel.Name = "pointsLeftLabel";
            this.pointsLeftLabel.Size = new System.Drawing.Size(0, 37);
            this.pointsLeftLabel.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rage Italic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 829);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(539, 37);
            this.label2.TabIndex = 21;
            this.label2.Text = "You Have a Maximum of 200 Points to Use";
            // 
            // godToReplaceLabel
            // 
            this.godToReplaceLabel.AutoSize = true;
            this.godToReplaceLabel.Font = new System.Drawing.Font("Rage Italic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.godToReplaceLabel.Location = new System.Drawing.Point(1301, 565);
            this.godToReplaceLabel.Name = "godToReplaceLabel";
            this.godToReplaceLabel.Size = new System.Drawing.Size(382, 37);
            this.godToReplaceLabel.TabIndex = 22;
            this.godToReplaceLabel.Text = "Which God Will You Replace?";
            // 
            // godToReplaceComboBox
            // 
            this.godToReplaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.godToReplaceComboBox.Font = new System.Drawing.Font("Rage Italic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.godToReplaceComboBox.FormattingEnabled = true;
            this.godToReplaceComboBox.Items.AddRange(new object[] {
            "Thor",
            "Tyr",
            "Freya",
            "Poseidon",
            "Hades",
            "Athena"});
            this.godToReplaceComboBox.Location = new System.Drawing.Point(1348, 630);
            this.godToReplaceComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.godToReplaceComboBox.Name = "godToReplaceComboBox";
            this.godToReplaceComboBox.Size = new System.Drawing.Size(304, 45);
            this.godToReplaceComboBox.TabIndex = 23;
            // 
            // GodSelcterPictureBox
            // 
            this.GodSelcterPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("GodSelcterPictureBox.Image")));
            this.GodSelcterPictureBox.Location = new System.Drawing.Point(679, 186);
            this.GodSelcterPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GodSelcterPictureBox.Name = "GodSelcterPictureBox";
            this.GodSelcterPictureBox.Size = new System.Drawing.Size(520, 614);
            this.GodSelcterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GodSelcterPictureBox.TabIndex = 24;
            this.GodSelcterPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.GodSelcterPictureBox);
            this.Controls.Add(this.godToReplaceComboBox);
            this.Controls.Add(this.godToReplaceLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pointsLeftLabel);
            this.Controls.Add(this.totalPointLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.attackLabel);
            this.Controls.Add(this.attackSlider);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.GodHealthSlider);
            this.Controls.Add(this.HealthDisplayLabel);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.AbilitySelectorComboBox);
            this.Controls.Add(this.GodAbilityLabel);
            this.Controls.Add(this.godsHealthandAttackLabel);
            this.Controls.Add(this.godsNameTextbox);
            this.Controls.Add(this.godNamePickerLabel);
            this.Controls.Add(this.CharacterSelectionLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Create a God!";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.GodHealthSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attackSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GodSelcterPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CharacterSelectionLabel;
        private System.Windows.Forms.Label godNamePickerLabel;
        private System.Windows.Forms.TextBox godsNameTextbox;
        private System.Windows.Forms.Label godsHealthandAttackLabel;
        private System.Windows.Forms.Label GodAbilityLabel;
        private System.Windows.Forms.ComboBox AbilitySelectorComboBox;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label HealthDisplayLabel;
        private System.Windows.Forms.TrackBar GodHealthSlider;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
        private System.Windows.Forms.TrackBar attackSlider;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label attackLabel;
        private System.Windows.Forms.Label totalPointLabel;
        private System.Windows.Forms.Label pointsLeftLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox godToReplaceComboBox;
        private System.Windows.Forms.Label godToReplaceLabel;
        private System.Windows.Forms.PictureBox GodSelcterPictureBox;
    }
}

