namespace Editor
{
    partial class PropertyField
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
            PropertyNameLabel = new Label();
            PropertyEditPanel = new Panel();
            label1 = new Label();
            PropertyEditPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PropertyNameLabel
            // 
            PropertyNameLabel.AutoSize = true;
            PropertyNameLabel.Location = new Point(4, 7);
            PropertyNameLabel.Name = "PropertyNameLabel";
            PropertyNameLabel.Size = new Size(87, 15);
            PropertyNameLabel.TabIndex = 0;
            PropertyNameLabel.Text = "Property Name";
            // 
            // PropertyEditPanel
            // 
            PropertyEditPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            PropertyEditPanel.Controls.Add(label1);
            PropertyEditPanel.Location = new Point(188, 0);
            PropertyEditPanel.Name = "PropertyEditPanel";
            PropertyEditPanel.Size = new Size(342, 30);
            PropertyEditPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 7);
            label1.Name = "label1";
            label1.Size = new Size(202, 15);
            label1.TabIndex = 0;
            label1.Text = "There was an error handling this part.";
            // 
            // PropertyField
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PropertyEditPanel);
            Controls.Add(PropertyNameLabel);
            Name = "PropertyField";
            Size = new Size(530, 30);
            PropertyEditPanel.ResumeLayout(false);
            PropertyEditPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        protected Panel PropertyEditPanel;
        private Label label1;
        protected Label PropertyNameLabel;
    }
}
