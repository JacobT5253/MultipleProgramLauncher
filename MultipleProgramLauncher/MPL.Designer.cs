namespace MultipleProgramLauncher
{
    partial class MPL
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MPL));
            Home_Panel = new Panel();
            ProgramLauncher_Flow_Panel = new FlowLayoutPanel();
            Top_Home_Panel = new Panel();
            CreateProfile_Button = new Button();
            HomeTop_Panel = new Label();
            CreateBatch_Panel = new Panel();
            Middle_Create_Flow_Panel = new FlowLayoutPanel();
            Top_Create_Panel = new Panel();
            back_Button = new Button();
            AddFiles_Label = new Label();
            Bottom_Create_Panel = new Panel();
            orgPath_Panel = new Panel();
            AddPath_Button = new Button();
            orPastePath_Label = new Label();
            PathTextBox = new TextBox();
            Save_Button = new Button();
            AddExeFiles_Link = new LinkLabel();
            Home_Panel.SuspendLayout();
            Top_Home_Panel.SuspendLayout();
            CreateBatch_Panel.SuspendLayout();
            Top_Create_Panel.SuspendLayout();
            Bottom_Create_Panel.SuspendLayout();
            orgPath_Panel.SuspendLayout();
            SuspendLayout();
            // 
            // Home_Panel
            // 
            Home_Panel.BackgroundImageLayout = ImageLayout.None;
            Home_Panel.Controls.Add(ProgramLauncher_Flow_Panel);
            Home_Panel.Controls.Add(Top_Home_Panel);
            Home_Panel.Location = new Point(839, 80);
            Home_Panel.Name = "Home_Panel";
            Home_Panel.Size = new Size(777, 526);
            Home_Panel.TabIndex = 0;
            // 
            // ProgramLauncher_Flow_Panel
            // 
            ProgramLauncher_Flow_Panel.AutoScroll = true;
            ProgramLauncher_Flow_Panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ProgramLauncher_Flow_Panel.BackColor = SystemColors.ControlLight;
            ProgramLauncher_Flow_Panel.Dock = DockStyle.Bottom;
            ProgramLauncher_Flow_Panel.FlowDirection = FlowDirection.TopDown;
            ProgramLauncher_Flow_Panel.Location = new Point(0, 40);
            ProgramLauncher_Flow_Panel.Name = "ProgramLauncher_Flow_Panel";
            ProgramLauncher_Flow_Panel.Size = new Size(777, 486);
            ProgramLauncher_Flow_Panel.TabIndex = 2;
            // 
            // Top_Home_Panel
            // 
            Top_Home_Panel.BackColor = SystemColors.GradientInactiveCaption;
            Top_Home_Panel.Controls.Add(CreateProfile_Button);
            Top_Home_Panel.Controls.Add(HomeTop_Panel);
            Top_Home_Panel.Dock = DockStyle.Top;
            Top_Home_Panel.Location = new Point(0, 0);
            Top_Home_Panel.Name = "Top_Home_Panel";
            Top_Home_Panel.Size = new Size(777, 40);
            Top_Home_Panel.TabIndex = 3;
            // 
            // CreateProfile_Button
            // 
            CreateProfile_Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CreateProfile_Button.BackgroundImageLayout = ImageLayout.Stretch;
            CreateProfile_Button.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CreateProfile_Button.Location = new Point(632, 0);
            CreateProfile_Button.Name = "CreateProfile_Button";
            CreateProfile_Button.Size = new Size(145, 40);
            CreateProfile_Button.TabIndex = 0;
            CreateProfile_Button.Text = "Create New Profile";
            CreateProfile_Button.UseVisualStyleBackColor = true;
            CreateProfile_Button.Click += CreateProfile_Button_Click;
            // 
            // HomeTop_Panel
            // 
            HomeTop_Panel.Anchor = AnchorStyles.Top;
            HomeTop_Panel.AutoSize = true;
            HomeTop_Panel.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            HomeTop_Panel.Location = new Point(273, 1);
            HomeTop_Panel.Name = "HomeTop_Panel";
            HomeTop_Panel.Size = new Size(201, 31);
            HomeTop_Panel.TabIndex = 0;
            HomeTop_Panel.Text = "Program Launcher";
            // 
            // CreateBatch_Panel
            // 
            CreateBatch_Panel.BackColor = SystemColors.GradientInactiveCaption;
            CreateBatch_Panel.Controls.Add(Middle_Create_Flow_Panel);
            CreateBatch_Panel.Controls.Add(Top_Create_Panel);
            CreateBatch_Panel.Controls.Add(Bottom_Create_Panel);
            CreateBatch_Panel.Location = new Point(10, 5);
            CreateBatch_Panel.Name = "CreateBatch_Panel";
            CreateBatch_Panel.Size = new Size(777, 467);
            CreateBatch_Panel.TabIndex = 1;
            CreateBatch_Panel.Visible = false;
            // 
            // Middle_Create_Flow_Panel
            // 
            Middle_Create_Flow_Panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Middle_Create_Flow_Panel.AutoScroll = true;
            Middle_Create_Flow_Panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Middle_Create_Flow_Panel.BackColor = SystemColors.ControlLight;
            Middle_Create_Flow_Panel.FlowDirection = FlowDirection.TopDown;
            Middle_Create_Flow_Panel.Location = new Point(0, 40);
            Middle_Create_Flow_Panel.Name = "Middle_Create_Flow_Panel";
            Middle_Create_Flow_Panel.Size = new Size(777, 360);
            Middle_Create_Flow_Panel.TabIndex = 2;
            Middle_Create_Flow_Panel.WrapContents = false;
            // 
            // Top_Create_Panel
            // 
            Top_Create_Panel.Controls.Add(back_Button);
            Top_Create_Panel.Controls.Add(AddFiles_Label);
            Top_Create_Panel.Dock = DockStyle.Top;
            Top_Create_Panel.Location = new Point(0, 0);
            Top_Create_Panel.Name = "Top_Create_Panel";
            Top_Create_Panel.Size = new Size(777, 40);
            Top_Create_Panel.TabIndex = 0;
            // 
            // back_Button
            // 
            back_Button.BackColor = Color.Transparent;
            back_Button.BackgroundImage = (Image)resources.GetObject("back_Button.BackgroundImage");
            back_Button.BackgroundImageLayout = ImageLayout.Stretch;
            back_Button.ForeColor = Color.Coral;
            back_Button.Location = new Point(0, 0);
            back_Button.Name = "back_Button";
            back_Button.Size = new Size(40, 40);
            back_Button.TabIndex = 4;
            back_Button.UseVisualStyleBackColor = false;
            back_Button.Click += backButton_Click;
            // 
            // AddFiles_Label
            // 
            AddFiles_Label.Anchor = AnchorStyles.Top;
            AddFiles_Label.AutoSize = true;
            AddFiles_Label.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            AddFiles_Label.Location = new Point(146, 2);
            AddFiles_Label.Name = "AddFiles_Label";
            AddFiles_Label.Size = new Size(463, 31);
            AddFiles_Label.TabIndex = 3;
            AddFiles_Label.Text = "Add files below to launch with the batch file";
            // 
            // Bottom_Create_Panel
            // 
            Bottom_Create_Panel.Controls.Add(orgPath_Panel);
            Bottom_Create_Panel.Controls.Add(Save_Button);
            Bottom_Create_Panel.Controls.Add(AddExeFiles_Link);
            Bottom_Create_Panel.Dock = DockStyle.Bottom;
            Bottom_Create_Panel.Location = new Point(0, 397);
            Bottom_Create_Panel.Name = "Bottom_Create_Panel";
            Bottom_Create_Panel.Size = new Size(777, 70);
            Bottom_Create_Panel.TabIndex = 4;
            // 
            // orgPath_Panel
            // 
            orgPath_Panel.Anchor = AnchorStyles.Bottom;
            orgPath_Panel.Controls.Add(AddPath_Button);
            orgPath_Panel.Controls.Add(orPastePath_Label);
            orgPath_Panel.Controls.Add(PathTextBox);
            orgPath_Panel.Location = new Point(192, 6);
            orgPath_Panel.Name = "orgPath_Panel";
            orgPath_Panel.Size = new Size(382, 61);
            orgPath_Panel.TabIndex = 0;
            // 
            // AddPath_Button
            // 
            AddPath_Button.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AddPath_Button.Location = new Point(327, 27);
            AddPath_Button.Name = "AddPath_Button";
            AddPath_Button.Size = new Size(48, 28);
            AddPath_Button.TabIndex = 4;
            AddPath_Button.Text = "Add";
            AddPath_Button.UseVisualStyleBackColor = true;
            AddPath_Button.Click += AddPathButton_Click;
            // 
            // orPastePath_Label
            // 
            orPastePath_Label.AutoSize = true;
            orPastePath_Label.Location = new Point(92, 4);
            orPastePath_Label.Name = "orPastePath_Label";
            orPastePath_Label.Size = new Size(138, 20);
            orPastePath_Label.TabIndex = 2;
            orPastePath_Label.Text = "or paste PATH here:";
            // 
            // PathTextBox
            // 
            PathTextBox.Location = new Point(9, 27);
            PathTextBox.Name = "PathTextBox";
            PathTextBox.PlaceholderText = "ex: C:\\Users\\YourName\\Desktop\\program.exe";
            PathTextBox.Size = new Size(312, 27);
            PathTextBox.TabIndex = 3;
            // 
            // Save_Button
            // 
            Save_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Save_Button.Location = new Point(650, 10);
            Save_Button.Name = "Save_Button";
            Save_Button.Size = new Size(115, 48);
            Save_Button.TabIndex = 0;
            Save_Button.Text = "Save Profile";
            Save_Button.UseVisualStyleBackColor = true;
            Save_Button.Click += SaveButton_Click;
            // 
            // AddExeFiles_Link
            // 
            AddExeFiles_Link.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddExeFiles_Link.AutoSize = true;
            AddExeFiles_Link.Location = new Point(21, 14);
            AddExeFiles_Link.Name = "AddExeFiles_Link";
            AddExeFiles_Link.Size = new Size(139, 40);
            AddExeFiles_Link.TabIndex = 1;
            AddExeFiles_Link.TabStop = true;
            AddExeFiles_Link.Text = "Search for .exe Files\r\non this computer\r\n";
            AddExeFiles_Link.LinkClicked += AddExeFiles_LinkClicked;
            // 
            // MPL
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1697, 733);
            Controls.Add(Home_Panel);
            Controls.Add(CreateBatch_Panel);
            Name = "MPL";
            Text = "Multiple Program Launcher 1.0";
            Home_Panel.ResumeLayout(false);
            Top_Home_Panel.ResumeLayout(false);
            Top_Home_Panel.PerformLayout();
            CreateBatch_Panel.ResumeLayout(false);
            Top_Create_Panel.ResumeLayout(false);
            Top_Create_Panel.PerformLayout();
            Bottom_Create_Panel.ResumeLayout(false);
            Bottom_Create_Panel.PerformLayout();
            orgPath_Panel.ResumeLayout(false);
            orgPath_Panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel Home_Panel;
        private Button CreateNewBatch;
        private Panel CreateBatch_Panel;
        private Button Save_Button;
        private LinkLabel AddExeFiles_Link;
        private FlowLayoutPanel Middle_Create_Flow_Panel;
        private Label AddFiles_Label;
        private Panel Bottom_Create_Panel;
        private Label orPastePath_Label;
        private TextBox PathTextBox;
        private Button AddPath_Button;
        private Panel Top_Create_Panel;
        private Panel orgPath_Panel;
        private Button back_Button;
        private FlowLayoutPanel ProgramLauncher_Flow_Panel;
        private Panel Top_Home_Panel;
        private Label HomeTop_Panel;
        private Button CreateProfile_Button;
    }
}