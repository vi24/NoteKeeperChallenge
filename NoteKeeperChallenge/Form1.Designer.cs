namespace NoteKeeperChallenge
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
            this.NoteTitleTextBox = new System.Windows.Forms.TextBox();
            this.NoteTextBox = new System.Windows.Forms.TextBox();
            this.NoteLabel = new System.Windows.Forms.Label();
            this.NoteTitleLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CreatedLabel = new System.Windows.Forms.Label();
            this.LastEditedLabel = new System.Windows.Forms.Label();
            this.LastEditedDateLabel = new System.Windows.Forms.Label();
            this.CreatedDateLabel = new System.Windows.Forms.Label();
            this.NoteFormat = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NoteTitleTextBox
            // 
            this.NoteTitleTextBox.Location = new System.Drawing.Point(33, 64);
            this.NoteTitleTextBox.Name = "NoteTitleTextBox";
            this.NoteTitleTextBox.Size = new System.Drawing.Size(247, 20);
            this.NoteTitleTextBox.TabIndex = 0;
            // 
            // NoteTextBox
            // 
            this.NoteTextBox.Location = new System.Drawing.Point(33, 144);
            this.NoteTextBox.Multiline = true;
            this.NoteTextBox.Name = "NoteTextBox";
            this.NoteTextBox.Size = new System.Drawing.Size(247, 244);
            this.NoteTextBox.TabIndex = 1;
            // 
            // NoteLabel
            // 
            this.NoteLabel.AutoSize = true;
            this.NoteLabel.Location = new System.Drawing.Point(30, 115);
            this.NoteLabel.Name = "NoteLabel";
            this.NoteLabel.Size = new System.Drawing.Size(30, 13);
            this.NoteLabel.TabIndex = 2;
            this.NoteLabel.Text = "Note";
            // 
            // NoteTitleLabel
            // 
            this.NoteTitleLabel.AutoSize = true;
            this.NoteTitleLabel.Location = new System.Drawing.Point(30, 35);
            this.NoteTitleLabel.Name = "NoteTitleLabel";
            this.NoteTitleLabel.Size = new System.Drawing.Size(27, 13);
            this.NoteTitleLabel.TabIndex = 3;
            this.NoteTitleLabel.Text = "Title";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(332, 64);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 20);
            this.SaveButton.TabIndex = 4;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CreatedLabel
            // 
            this.CreatedLabel.AutoSize = true;
            this.CreatedLabel.Location = new System.Drawing.Point(30, 411);
            this.CreatedLabel.Name = "CreatedLabel";
            this.CreatedLabel.Size = new System.Drawing.Size(50, 13);
            this.CreatedLabel.TabIndex = 6;
            this.CreatedLabel.Text = "Created: ";
            // 
            // LastEditedLabel
            // 
            this.LastEditedLabel.AutoSize = true;
            this.LastEditedLabel.Location = new System.Drawing.Point(204, 411);
            this.LastEditedLabel.Name = "LastEditedLabel";
            this.LastEditedLabel.Size = new System.Drawing.Size(63, 13);
            this.LastEditedLabel.TabIndex = 7;
            this.LastEditedLabel.Text = "Last Edited:";
            // 
            // LastEditedDateLabel
            // 
            this.LastEditedDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LastEditedDateLabel.Location = new System.Drawing.Point(273, 411);
            this.LastEditedDateLabel.Name = "LastEditedDateLabel";
            this.LastEditedDateLabel.Size = new System.Drawing.Size(110, 13);
            this.LastEditedDateLabel.TabIndex = 9;
            // 
            // CreatedDateLabel
            // 
            this.CreatedDateLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CreatedDateLabel.Location = new System.Drawing.Point(86, 410);
            this.CreatedDateLabel.Name = "CreatedDateLabel";
            this.CreatedDateLabel.Size = new System.Drawing.Size(101, 14);
            this.CreatedDateLabel.TabIndex = 10;
            // 
            // NoteFormat
            // 
            this.NoteFormat.FormattingEnabled = true;
            this.NoteFormat.Location = new System.Drawing.Point(301, 230);
            this.NoteFormat.Name = "NoteFormat";
            this.NoteFormat.Size = new System.Drawing.Size(121, 21);
            this.NoteFormat.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 448);
            this.Controls.Add(this.NoteFormat);
            this.Controls.Add(this.CreatedDateLabel);
            this.Controls.Add(this.LastEditedDateLabel);
            this.Controls.Add(this.LastEditedLabel);
            this.Controls.Add(this.CreatedLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.NoteTitleLabel);
            this.Controls.Add(this.NoteLabel);
            this.Controls.Add(this.NoteTextBox);
            this.Controls.Add(this.NoteTitleTextBox);
            this.Name = "Form1";
            this.Text = "Note Keeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NoteTitleTextBox;
        private System.Windows.Forms.TextBox NoteTextBox;
        private System.Windows.Forms.Label NoteLabel;
        private System.Windows.Forms.Label NoteTitleLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label CreatedLabel;
        private System.Windows.Forms.Label LastEditedLabel;
        private System.Windows.Forms.Label LastEditedDateLabel;
        private System.Windows.Forms.Label CreatedDateLabel;
        private System.Windows.Forms.ComboBox NoteFormat;
    }
}

