namespace NeuralNetworkProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TitleLabel = new System.Windows.Forms.Label();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.GuessLabel = new System.Windows.Forms.Label();
            this.ConfidenceLabel = new System.Windows.Forms.Label();
            this.ConsoleLabel = new System.Windows.Forms.Label();
            this.TrainButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.LossLabel = new System.Windows.Forms.Label();
            this.ConsoleTitleLabel = new System.Windows.Forms.Label();
            this.ModelParametersLabel = new System.Windows.Forms.Label();
            this.BatchSizeTextBox = new System.Windows.Forms.TextBox();
            this.BatchCountTextBox = new System.Windows.Forms.TextBox();
            this.BatchSizeLabel = new System.Windows.Forms.Label();
            this.BatchCountLabel = new System.Windows.Forms.Label();
            this.ExplanationLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AcknowledgementsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TitleLabel.Location = new System.Drawing.Point(834, 36);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(552, 38);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Handwritten Letter Neural Network";
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.Color.White;
            this.LoadButton.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.LoadButton.FlatAppearance.BorderSize = 3;
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LoadButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoadButton.Location = new System.Drawing.Point(836, 695);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(96, 37);
            this.LoadButton.TabIndex = 1;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            this.LoadButton.MouseHover += new System.EventHandler(this.LoadButton_MouseHover);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SaveButton.Location = new System.Drawing.Point(1079, 695);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 37);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseHover += new System.EventHandler(this.SaveButton_MouseHover);
            // 
            // GuessLabel
            // 
            this.GuessLabel.AutoSize = true;
            this.GuessLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuessLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GuessLabel.Location = new System.Drawing.Point(836, 157);
            this.GuessLabel.Name = "GuessLabel";
            this.GuessLabel.Size = new System.Drawing.Size(111, 28);
            this.GuessLabel.TabIndex = 4;
            this.GuessLabel.Text = "Guess: -";
            this.GuessLabel.MouseHover += new System.EventHandler(this.GuessLabel_MouseHover);
            // 
            // ConfidenceLabel
            // 
            this.ConfidenceLabel.AutoSize = true;
            this.ConfidenceLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfidenceLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ConfidenceLabel.Location = new System.Drawing.Point(836, 208);
            this.ConfidenceLabel.Name = "ConfidenceLabel";
            this.ConfidenceLabel.Size = new System.Drawing.Size(203, 28);
            this.ConfidenceLabel.TabIndex = 5;
            this.ConfidenceLabel.Text = "Confidence: --%";
            this.ConfidenceLabel.MouseHover += new System.EventHandler(this.ConfidenceLabel_MouseHover);
            // 
            // ConsoleLabel
            // 
            this.ConsoleLabel.AutoSize = true;
            this.ConsoleLabel.BackColor = System.Drawing.Color.Black;
            this.ConsoleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConsoleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleLabel.ForeColor = System.Drawing.Color.LawnGreen;
            this.ConsoleLabel.Location = new System.Drawing.Point(836, 377);
            this.ConsoleLabel.MaximumSize = new System.Drawing.Size(200, 200);
            this.ConsoleLabel.MinimumSize = new System.Drawing.Size(350, 120);
            this.ConsoleLabel.Name = "ConsoleLabel";
            this.ConsoleLabel.Size = new System.Drawing.Size(350, 120);
            this.ConsoleLabel.TabIndex = 6;
            this.ConsoleLabel.Text = "*";
            // 
            // TrainButton
            // 
            this.TrainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TrainButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TrainButton.Location = new System.Drawing.Point(958, 695);
            this.TrainButton.Name = "TrainButton";
            this.TrainButton.Size = new System.Drawing.Size(96, 37);
            this.TrainButton.TabIndex = 7;
            this.TrainButton.Text = "Train";
            this.TrainButton.UseVisualStyleBackColor = true;
            this.TrainButton.Click += new System.EventHandler(this.TrainButton_Click);
            this.TrainButton.MouseHover += new System.EventHandler(this.TrainButton_MouseHover);
            // 
            // ResetButton
            // 
            this.ResetButton.BackColor = System.Drawing.Color.Tomato;
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ResetButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ResetButton.Location = new System.Drawing.Point(480, 750);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(96, 37);
            this.ResetButton.TabIndex = 8;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            this.ResetButton.MouseHover += new System.EventHandler(this.ResetButton_MouseHover);
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.Color.Green;
            this.SubmitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SubmitButton.Location = new System.Drawing.Point(590, 750);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(96, 37);
            this.SubmitButton.TabIndex = 9;
            this.SubmitButton.Text = "Guess";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            this.SubmitButton.MouseHover += new System.EventHandler(this.SubmitButton_MouseHover);
            // 
            // LossLabel
            // 
            this.LossLabel.AutoSize = true;
            this.LossLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LossLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LossLabel.Location = new System.Drawing.Point(836, 262);
            this.LossLabel.Name = "LossLabel";
            this.LossLabel.Size = new System.Drawing.Size(126, 28);
            this.LossLabel.TabIndex = 10;
            this.LossLabel.Text = "Loss: --%";
            this.LossLabel.MouseHover += new System.EventHandler(this.LossLabel_MouseHover);
            // 
            // ConsoleTitleLabel
            // 
            this.ConsoleTitleLabel.AutoSize = true;
            this.ConsoleTitleLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleTitleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ConsoleTitleLabel.Location = new System.Drawing.Point(836, 334);
            this.ConsoleTitleLabel.Name = "ConsoleTitleLabel";
            this.ConsoleTitleLabel.Size = new System.Drawing.Size(110, 28);
            this.ConsoleTitleLabel.TabIndex = 11;
            this.ConsoleTitleLabel.Text = "Console";
            this.ConsoleTitleLabel.MouseHover += new System.EventHandler(this.ConsoleTitleLabel_MouseHover);
            // 
            // ModelParametersLabel
            // 
            this.ModelParametersLabel.AutoSize = true;
            this.ModelParametersLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModelParametersLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ModelParametersLabel.Location = new System.Drawing.Point(836, 532);
            this.ModelParametersLabel.Name = "ModelParametersLabel";
            this.ModelParametersLabel.Size = new System.Drawing.Size(226, 28);
            this.ModelParametersLabel.TabIndex = 12;
            this.ModelParametersLabel.Text = "Training Settings";
            // 
            // BatchSizeTextBox
            // 
            this.BatchSizeTextBox.CausesValidation = false;
            this.BatchSizeTextBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchSizeTextBox.Location = new System.Drawing.Point(1029, 581);
            this.BatchSizeTextBox.Name = "BatchSizeTextBox";
            this.BatchSizeTextBox.Size = new System.Drawing.Size(100, 32);
            this.BatchSizeTextBox.TabIndex = 13;
            this.BatchSizeTextBox.Text = "64";
            this.BatchSizeTextBox.Leave += new System.EventHandler(this.BatchSizeTextBox_Leave);
            // 
            // BatchCountTextBox
            // 
            this.BatchCountTextBox.CausesValidation = false;
            this.BatchCountTextBox.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchCountTextBox.Location = new System.Drawing.Point(1029, 636);
            this.BatchCountTextBox.Name = "BatchCountTextBox";
            this.BatchCountTextBox.Size = new System.Drawing.Size(100, 32);
            this.BatchCountTextBox.TabIndex = 14;
            this.BatchCountTextBox.Text = "256";
            this.BatchCountTextBox.Leave += new System.EventHandler(this.BatchCountTextBox_Leave);
            // 
            // BatchSizeLabel
            // 
            this.BatchSizeLabel.AutoSize = true;
            this.BatchSizeLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchSizeLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BatchSizeLabel.Location = new System.Drawing.Point(836, 585);
            this.BatchSizeLabel.Name = "BatchSizeLabel";
            this.BatchSizeLabel.Size = new System.Drawing.Size(134, 28);
            this.BatchSizeLabel.TabIndex = 15;
            this.BatchSizeLabel.Text = "Batch Size";
            this.BatchSizeLabel.MouseHover += new System.EventHandler(this.BatchSizeLabel_MouseHover);
            // 
            // BatchCountLabel
            // 
            this.BatchCountLabel.AutoSize = true;
            this.BatchCountLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatchCountLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BatchCountLabel.Location = new System.Drawing.Point(836, 637);
            this.BatchCountLabel.Name = "BatchCountLabel";
            this.BatchCountLabel.Size = new System.Drawing.Size(155, 28);
            this.BatchCountLabel.TabIndex = 16;
            this.BatchCountLabel.Text = "Batch Count";
            this.BatchCountLabel.MouseHover += new System.EventHandler(this.BatchCountLabel_MouseHover);
            // 
            // ExplanationLabel
            // 
            this.ExplanationLabel.AutoSize = true;
            this.ExplanationLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExplanationLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExplanationLabel.Location = new System.Drawing.Point(1219, 157);
            this.ExplanationLabel.MaximumSize = new System.Drawing.Size(350, 210);
            this.ExplanationLabel.MinimumSize = new System.Drawing.Size(100, 180);
            this.ExplanationLabel.Name = "ExplanationLabel";
            this.ExplanationLabel.Size = new System.Drawing.Size(330, 180);
            this.ExplanationLabel.TabIndex = 17;
            this.ExplanationLabel.Text = "Hover over a control for information about what it does.";
            // 
            // DeleteButton
            // 
            this.DeleteButton.BackColor = System.Drawing.Color.Tomato;
            this.DeleteButton.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.DeleteButton.FlatAppearance.BorderSize = 3;
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DeleteButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DeleteButton.Location = new System.Drawing.Point(1079, 750);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(96, 37);
            this.DeleteButton.TabIndex = 18;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            this.DeleteButton.MouseHover += new System.EventHandler(this.DeleteButton_MouseHover);
            // 
            // AcknowledgementsLabel
            // 
            this.AcknowledgementsLabel.AutoSize = true;
            this.AcknowledgementsLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcknowledgementsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.AcknowledgementsLabel.Location = new System.Drawing.Point(1236, 778);
            this.AcknowledgementsLabel.Name = "AcknowledgementsLabel";
            this.AcknowledgementsLabel.Size = new System.Drawing.Size(300, 22);
            this.AcknowledgementsLabel.TabIndex = 19;
            this.AcknowledgementsLabel.Text = "Developed by Gage Moore (2026)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1542, 809);
            this.Controls.Add(this.AcknowledgementsLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ExplanationLabel);
            this.Controls.Add(this.BatchCountLabel);
            this.Controls.Add(this.BatchSizeLabel);
            this.Controls.Add(this.BatchCountTextBox);
            this.Controls.Add(this.BatchSizeTextBox);
            this.Controls.Add(this.ModelParametersLabel);
            this.Controls.Add(this.ConsoleTitleLabel);
            this.Controls.Add(this.LossLabel);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.TrainButton);
            this.Controls.Add(this.ConsoleLabel);
            this.Controls.Add(this.ConfidenceLabel);
            this.Controls.Add(this.GuessLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.TitleLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Handwritten Letter Neural Network";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label GuessLabel;
        private System.Windows.Forms.Label ConfidenceLabel;
        private System.Windows.Forms.Label ConsoleLabel;
        private System.Windows.Forms.Button TrainButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label LossLabel;
        private System.Windows.Forms.Label ConsoleTitleLabel;
        private System.Windows.Forms.Label ModelParametersLabel;
        private System.Windows.Forms.TextBox BatchSizeTextBox;
        private System.Windows.Forms.TextBox BatchCountTextBox;
        private System.Windows.Forms.Label BatchSizeLabel;
        private System.Windows.Forms.Label BatchCountLabel;
        private System.Windows.Forms.Label ExplanationLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label AcknowledgementsLabel;
    }
}

