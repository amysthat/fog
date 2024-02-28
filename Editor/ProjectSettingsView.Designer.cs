namespace Editor
{
    partial class ProjectSettingsView
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
            groupBox1 = new GroupBox();
            ResolutionFullscreen = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            ResolutionY = new NumericUpDown();
            label1 = new Label();
            ResolutionX = new NumericUpDown();
            ApplyButton = new Button();
            label4 = new Label();
            Title = new TextBox();
            groupBox2 = new GroupBox();
            ClearColorPickButton = new Button();
            label5 = new Label();
            ClearColorB = new NumericUpDown();
            label6 = new Label();
            ClearColorG = new NumericUpDown();
            label7 = new Label();
            ClearColorR = new NumericUpDown();
            StartupEntity = new TextBox();
            label8 = new Label();
            DefaultFont = new TextBox();
            label9 = new Label();
            groupBox3 = new GroupBox();
            DefaultFontColorPickButton = new Button();
            label10 = new Label();
            DefaultTextColorB = new NumericUpDown();
            label11 = new Label();
            DefaultTextColorG = new NumericUpDown();
            label12 = new Label();
            DefaultTextColorR = new NumericUpDown();
            PlayerAssembly = new TextBox();
            label13 = new Label();
            GUID = new TextBox();
            label14 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ResolutionY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ResolutionX).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ClearColorB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ClearColorG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ClearColorR).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DefaultTextColorB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DefaultTextColorG).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DefaultTextColorR).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ResolutionFullscreen);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(ResolutionY);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(ResolutionX);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(787, 49);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Resolution";
            // 
            // ResolutionFullscreen
            // 
            ResolutionFullscreen.AutoSize = true;
            ResolutionFullscreen.Location = new Point(373, 18);
            ResolutionFullscreen.Name = "ResolutionFullscreen";
            ResolutionFullscreen.Size = new Size(42, 19);
            ResolutionFullscreen.TabIndex = 5;
            ResolutionFullscreen.Text = "On";
            ResolutionFullscreen.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(304, 19);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 4;
            label3.Text = "Fullscreen:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(155, 19);
            label2.Name = "label2";
            label2.Size = new Size(17, 15);
            label2.TabIndex = 3;
            label2.Text = "Y:";
            // 
            // ResolutionY
            // 
            ResolutionY.Location = new Point(178, 17);
            ResolutionY.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            ResolutionY.Name = "ResolutionY";
            ResolutionY.Size = new Size(120, 23);
            ResolutionY.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 1;
            label1.Text = "X:";
            // 
            // ResolutionX
            // 
            ResolutionX.Location = new Point(29, 17);
            ResolutionX.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            ResolutionX.Name = "ResolutionX";
            ResolutionX.Size = new Size(120, 23);
            ResolutionX.TabIndex = 0;
            // 
            // ApplyButton
            // 
            ApplyButton.Location = new Point(724, 555);
            ApplyButton.Name = "ApplyButton";
            ApplyButton.Size = new Size(75, 23);
            ApplyButton.TabIndex = 1;
            ApplyButton.Text = "Save";
            ApplyButton.UseVisualStyleBackColor = true;
            ApplyButton.Click += ApplyButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 69);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 6;
            label4.Text = "Window Title:";
            // 
            // Title
            // 
            Title.Location = new Point(103, 66);
            Title.Name = "Title";
            Title.Size = new Size(696, 23);
            Title.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ClearColorPickButton);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(ClearColorB);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(ClearColorG);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(ClearColorR);
            groupBox2.Location = new Point(12, 95);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(787, 49);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Clear Color";
            // 
            // ClearColorPickButton
            // 
            ClearColorPickButton.Location = new Point(661, 17);
            ClearColorPickButton.Name = "ClearColorPickButton";
            ClearColorPickButton.Size = new Size(120, 23);
            ClearColorPickButton.TabIndex = 6;
            ClearColorPickButton.Text = "Pick...";
            ClearColorPickButton.UseVisualStyleBackColor = true;
            ClearColorPickButton.Click += ClearColorPickButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(304, 19);
            label5.Name = "label5";
            label5.Size = new Size(17, 15);
            label5.TabIndex = 5;
            label5.Text = "B:";
            // 
            // ClearColorB
            // 
            ClearColorB.Location = new Point(327, 17);
            ClearColorB.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            ClearColorB.Name = "ClearColorB";
            ClearColorB.Size = new Size(120, 23);
            ClearColorB.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(155, 19);
            label6.Name = "label6";
            label6.Size = new Size(18, 15);
            label6.TabIndex = 3;
            label6.Text = "G:";
            // 
            // ClearColorG
            // 
            ClearColorG.Location = new Point(178, 17);
            ClearColorG.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            ClearColorG.Name = "ClearColorG";
            ClearColorG.Size = new Size(120, 23);
            ClearColorG.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 19);
            label7.Name = "label7";
            label7.Size = new Size(17, 15);
            label7.TabIndex = 1;
            label7.Text = "R:";
            // 
            // ClearColorR
            // 
            ClearColorR.Location = new Point(29, 17);
            ClearColorR.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            ClearColorR.Name = "ClearColorR";
            ClearColorR.Size = new Size(120, 23);
            ClearColorR.TabIndex = 0;
            // 
            // StartupEntity
            // 
            StartupEntity.Location = new Point(105, 150);
            StartupEntity.Name = "StartupEntity";
            StartupEntity.Size = new Size(694, 23);
            StartupEntity.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 153);
            label8.Name = "label8";
            label8.Size = new Size(81, 15);
            label8.TabIndex = 8;
            label8.Text = "Startup Entity:";
            // 
            // DefaultFont
            // 
            DefaultFont.Location = new Point(99, 179);
            DefaultFont.Name = "DefaultFont";
            DefaultFont.Size = new Size(700, 23);
            DefaultFont.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 182);
            label9.Name = "label9";
            label9.Size = new Size(75, 15);
            label9.TabIndex = 10;
            label9.Text = "Default Font:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(DefaultFontColorPickButton);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(DefaultTextColorB);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(DefaultTextColorG);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(DefaultTextColorR);
            groupBox3.Location = new Point(12, 208);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(787, 49);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Default Text Color";
            // 
            // DefaultFontColorPickButton
            // 
            DefaultFontColorPickButton.Location = new Point(661, 17);
            DefaultFontColorPickButton.Name = "DefaultFontColorPickButton";
            DefaultFontColorPickButton.Size = new Size(120, 23);
            DefaultFontColorPickButton.TabIndex = 6;
            DefaultFontColorPickButton.Text = "Pick...";
            DefaultFontColorPickButton.UseVisualStyleBackColor = true;
            DefaultFontColorPickButton.Click += DefaultFontColorPickButton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(304, 19);
            label10.Name = "label10";
            label10.Size = new Size(17, 15);
            label10.TabIndex = 5;
            label10.Text = "B:";
            // 
            // DefaultTextColorB
            // 
            DefaultTextColorB.Location = new Point(327, 17);
            DefaultTextColorB.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            DefaultTextColorB.Name = "DefaultTextColorB";
            DefaultTextColorB.Size = new Size(120, 23);
            DefaultTextColorB.TabIndex = 4;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(155, 19);
            label11.Name = "label11";
            label11.Size = new Size(18, 15);
            label11.TabIndex = 3;
            label11.Text = "G:";
            // 
            // DefaultTextColorG
            // 
            DefaultTextColorG.Location = new Point(178, 17);
            DefaultTextColorG.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            DefaultTextColorG.Name = "DefaultTextColorG";
            DefaultTextColorG.Size = new Size(120, 23);
            DefaultTextColorG.TabIndex = 2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 19);
            label12.Name = "label12";
            label12.Size = new Size(17, 15);
            label12.TabIndex = 1;
            label12.Text = "R:";
            // 
            // DefaultTextColorR
            // 
            DefaultTextColorR.Location = new Point(29, 17);
            DefaultTextColorR.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            DefaultTextColorR.Name = "DefaultTextColorR";
            DefaultTextColorR.Size = new Size(120, 23);
            DefaultTextColorR.TabIndex = 0;
            // 
            // PlayerAssembly
            // 
            PlayerAssembly.Location = new Point(312, 263);
            PlayerAssembly.Name = "PlayerAssembly";
            PlayerAssembly.Size = new Size(487, 23);
            PlayerAssembly.TabIndex = 13;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(18, 266);
            label13.Name = "label13";
            label13.Size = new Size(288, 15);
            label13.TabIndex = 12;
            label13.Text = "Player Assembly (modification is not recommended):";
            // 
            // GUID
            // 
            GUID.Location = new Point(55, 555);
            GUID.Name = "GUID";
            GUID.ReadOnly = true;
            GUID.Size = new Size(663, 23);
            GUID.TabIndex = 15;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(12, 558);
            label14.Name = "label14";
            label14.Size = new Size(37, 15);
            label14.TabIndex = 14;
            label14.Text = "GUID:";
            // 
            // ProjectSettingsView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(811, 590);
            Controls.Add(GUID);
            Controls.Add(label14);
            Controls.Add(PlayerAssembly);
            Controls.Add(label13);
            Controls.Add(groupBox3);
            Controls.Add(DefaultFont);
            Controls.Add(label9);
            Controls.Add(StartupEntity);
            Controls.Add(label8);
            Controls.Add(groupBox2);
            Controls.Add(Title);
            Controls.Add(label4);
            Controls.Add(ApplyButton);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProjectSettingsView";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Project Settings";
            Load += ProjectSettingsView_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ResolutionY).EndInit();
            ((System.ComponentModel.ISupportInitialize)ResolutionX).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ClearColorB).EndInit();
            ((System.ComponentModel.ISupportInitialize)ClearColorG).EndInit();
            ((System.ComponentModel.ISupportInitialize)ClearColorR).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DefaultTextColorB).EndInit();
            ((System.ComponentModel.ISupportInitialize)DefaultTextColorG).EndInit();
            ((System.ComponentModel.ISupportInitialize)DefaultTextColorR).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private NumericUpDown ResolutionX;
        private Label label2;
        private NumericUpDown ResolutionY;
        private Label label1;
        private Label label3;
        private CheckBox ResolutionFullscreen;
        private Button ApplyButton;
        private Label label4;
        private TextBox Title;
        private GroupBox groupBox2;
        private Label label6;
        private NumericUpDown ClearColorG;
        private Label label7;
        private NumericUpDown ClearColorR;
        private Label label5;
        private NumericUpDown ClearColorB;
        private Button ClearColorPickButton;
        private TextBox StartupEntity;
        private Label label8;
        private TextBox DefaultFont;
        private Label label9;
        private GroupBox groupBox3;
        private Button DefaultFontColorPickButton;
        private Label label10;
        private NumericUpDown DefaultTextColorB;
        private Label label11;
        private NumericUpDown DefaultTextColorG;
        private Label label12;
        private NumericUpDown DefaultTextColorR;
        private TextBox PlayerAssembly;
        private Label label13;
        private TextBox GUID;
        private Label label14;
    }
}