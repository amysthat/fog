namespace Editor
{
    partial class DllLocator
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
            label1 = new Label();
            label2 = new Label();
            ImportedCheckBox = new CheckBox();
            GetDllButton = new Button();
            ImportProjButton = new Button();
            ContinueButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(471, 15);
            label1.TabIndex = 0;
            label1.Text = "We need your project's .dll file in order to get things going. Here is what you need to do:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 41);
            label2.Name = "label2";
            label2.Size = new Size(236, 60);
            label2.TabIndex = 1;
            label2.Text = "Fire up your IDE and create a .NET 7 project.\r\nSet your project to Class Library.\r\nImport fogEngine .dll to your project.\r\nSelect the .csproj from the button below.";
            // 
            // ImportedCheckBox
            // 
            ImportedCheckBox.AutoSize = true;
            ImportedCheckBox.Enabled = false;
            ImportedCheckBox.Location = new Point(12, 116);
            ImportedCheckBox.Name = "ImportedCheckBox";
            ImportedCheckBox.Size = new Size(116, 19);
            ImportedCheckBox.TabIndex = 2;
            ImportedCheckBox.Text = ".csproj imported.";
            ImportedCheckBox.UseVisualStyleBackColor = true;
            // 
            // GetDllButton
            // 
            GetDllButton.Location = new Point(12, 224);
            GetDllButton.Name = "GetDllButton";
            GetDllButton.Size = new Size(200, 23);
            GetDllButton.TabIndex = 3;
            GetDllButton.Text = "Get the fogEngine .dll";
            GetDllButton.UseVisualStyleBackColor = true;
            GetDllButton.Click += GetDllButton_Click;
            // 
            // ImportProjButton
            // 
            ImportProjButton.Enabled = false;
            ImportProjButton.Location = new Point(134, 113);
            ImportProjButton.Name = "ImportProjButton";
            ImportProjButton.Size = new Size(72, 23);
            ImportProjButton.TabIndex = 4;
            ImportProjButton.Text = "Import";
            ImportProjButton.UseVisualStyleBackColor = true;
            ImportProjButton.Click += ImportProjButton_Click;
            // 
            // ContinueButton
            // 
            ContinueButton.Enabled = false;
            ContinueButton.Location = new Point(389, 224);
            ContinueButton.Name = "ContinueButton";
            ContinueButton.Size = new Size(94, 23);
            ContinueButton.TabIndex = 5;
            ContinueButton.Text = "Continue";
            ContinueButton.UseVisualStyleBackColor = true;
            ContinueButton.Click += ContinueButton_Click;
            // 
            // DllLocator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 256);
            ControlBox = false;
            Controls.Add(ContinueButton);
            Controls.Add(ImportProjButton);
            Controls.Add(GetDllButton);
            Controls.Add(ImportedCheckBox);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DllLocator";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dll Needed";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox ImportedCheckBox;
        private Button GetDllButton;
        private Button ImportProjButton;
        private Button ContinueButton;
    }
}