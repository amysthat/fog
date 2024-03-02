namespace Editor
{
    partial class StringProperty
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
            EditBox = new TextBox();
            PropertyEditPanel.SuspendLayout();
            SuspendLayout();
            // 
            // PropertyEditPanel
            // 
            PropertyEditPanel.Controls.Add(EditBox);
            PropertyEditPanel.Controls.SetChildIndex(EditBox, 0);
            // 
            // EditBox
            // 
            EditBox.Location = new Point(0, 4);
            EditBox.Name = "EditBox";
            EditBox.Size = new Size(342, 23);
            EditBox.TabIndex = 2;
            EditBox.TextChanged += EditBox_TextChanged;
            // 
            // StringProperty
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "StringProperty";
            PropertyEditPanel.ResumeLayout(false);
            PropertyEditPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox EditBox;
    }
}
