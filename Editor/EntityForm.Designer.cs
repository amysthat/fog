namespace Editor
{
    partial class EntityForm
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
            EntityNameTextbox = new TextBox();
            label2 = new Label();
            ComponentsGroup = new GroupBox();
            PositionTextbox = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "GUID:";
            // 
            // GUIDTextbox
            // 
            GUIDTextbox.Location = new Point(55, 6);
            GUIDTextbox.Name = "GUIDTextbox";
            GUIDTextbox.ReadOnly = true;
            GUIDTextbox.Size = new Size(939, 23);
            GUIDTextbox.TabIndex = 1;
            // 
            // EntityNameTextbox
            // 
            EntityNameTextbox.Location = new Point(60, 35);
            EntityNameTextbox.Name = "EntityNameTextbox";
            EntityNameTextbox.Size = new Size(248, 23);
            EntityNameTextbox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Name:";
            // 
            // ComponentsGroup
            // 
            ComponentsGroup.Location = new Point(314, 35);
            ComponentsGroup.Name = "ComponentsGroup";
            ComponentsGroup.Size = new Size(680, 575);
            ComponentsGroup.TabIndex = 4;
            ComponentsGroup.TabStop = false;
            ComponentsGroup.Text = "Components";
            // 
            // PositionTextbox
            // 
            PositionTextbox.Location = new Point(71, 64);
            PositionTextbox.Name = "PositionTextbox";
            PositionTextbox.Size = new Size(237, 23);
            PositionTextbox.TabIndex = 6;
            PositionTextbox.Text = "0; 0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 5;
            label3.Text = "Position:";
            // 
            // EntityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 622);
            Controls.Add(PositionTextbox);
            Controls.Add(label3);
            Controls.Add(ComponentsGroup);
            Controls.Add(EntityNameTextbox);
            Controls.Add(label2);
            Controls.Add(GUIDTextbox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EntityForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Entity Properties";
            Shown += EntityForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox GUIDTextbox;
        private TextBox EntityNameTextbox;
        private Label label2;
        private GroupBox ComponentsGroup;
        private TextBox PositionTextbox;
        private Label label3;
    }
}