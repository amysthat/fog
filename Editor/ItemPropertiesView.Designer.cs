namespace Editor
{
    partial class ItemPropertiesView
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
            GUIDTextbox = new TextBox();
            TypeTextbox = new TextBox();
            label2 = new Label();
            ApplyButton = new Button();
            OpenDefaultApplication = new Button();
            groupBox1 = new GroupBox();
            PropertyPanel = new Panel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "GUID:";
            // 
            // GUIDTextbox
            // 
            GUIDTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            GUIDTextbox.Location = new Point(55, 12);
            GUIDTextbox.Name = "GUIDTextbox";
            GUIDTextbox.ReadOnly = true;
            GUIDTextbox.Size = new Size(493, 23);
            GUIDTextbox.TabIndex = 1;
            // 
            // TypeTextbox
            // 
            TypeTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TypeTextbox.Location = new Point(52, 41);
            TypeTextbox.Name = "TypeTextbox";
            TypeTextbox.ReadOnly = true;
            TypeTextbox.Size = new Size(496, 23);
            TypeTextbox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 2;
            label2.Text = "Type:";
            // 
            // ApplyButton
            // 
            ApplyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ApplyButton.Enabled = false;
            ApplyButton.Location = new Point(444, 532);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(104, 23);
            ApplyButton.TabIndex = 4;
            ApplyButton.Text = "Apply";
            ApplyButton.UseVisualStyleBackColor = true;
            // 
            // OpenDefaultApplication
            // 
            OpenDefaultApplication.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            OpenDefaultApplication.Location = new Point(12, 532);
            OpenDefaultApplication.Name = "OpenDefaultApplication";
            OpenDefaultApplication.Size = new Size(217, 23);
            OpenDefaultApplication.TabIndex = 5;
            OpenDefaultApplication.Text = "Open with default application";
            OpenDefaultApplication.UseVisualStyleBackColor = true;
            OpenDefaultApplication.Click += OpenDefaultApplication_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(PropertyPanel);
            groupBox1.Location = new Point(12, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(536, 456);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Exposed Properties";
            // 
            // PropertyPanel
            // 
            PropertyPanel.Dock = DockStyle.Fill;
            PropertyPanel.Location = new Point(3, 19);
            PropertyPanel.Name = "PropertyPanel";
            PropertyPanel.Size = new Size(530, 434);
            PropertyPanel.TabIndex = 0;
            // 
            // ItemPropertiesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 567);
            Controls.Add(groupBox1);
            Controls.Add(OpenDefaultApplication);
            Controls.Add(ApplyButton);
            Controls.Add(TypeTextbox);
            Controls.Add(label2);
            Controls.Add(GUIDTextbox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ItemPropertiesView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Item Properties";
            Shown += ItemPropertiesView_Shown;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox GUIDTextbox;
        private TextBox TypeTextbox;
        private Label label2;
        private Button ApplyButton;
        private Button OpenDefaultApplication;
        private GroupBox groupBox1;
        private Panel PropertyPanel;
    }
}