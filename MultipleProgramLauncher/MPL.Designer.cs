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
            HomePanel = new Panel();
            EditBatch = new Button();
            CreateNewBatch = new Button();
            CreateBatchPanel = new Panel();
            Desc1 = new Label();
            TablePanel = new FlowLayoutPanel();
            AddExeFiles = new LinkLabel();
            ExportBatch = new Button();
            HomePanel.SuspendLayout();
            CreateBatchPanel.SuspendLayout();
            SuspendLayout();
            // 
            // HomePanel
            // 
            HomePanel.Controls.Add(EditBatch);
            HomePanel.Controls.Add(CreateNewBatch);
            HomePanel.Dock = DockStyle.Fill;
            HomePanel.Location = new Point(0, 0);
            HomePanel.Name = "HomePanel";
            HomePanel.Size = new Size(729, 492);
            HomePanel.TabIndex = 0;
            // 
            // EditBatch
            // 
            EditBatch.Anchor = AnchorStyles.Right;
            EditBatch.Location = new Point(416, 194);
            EditBatch.Name = "EditBatch";
            EditBatch.Size = new Size(219, 151);
            EditBatch.TabIndex = 1;
            EditBatch.Text = "Edit Batch";
            EditBatch.UseVisualStyleBackColor = true;
            EditBatch.Click += EditBatch_Click;
            // 
            // CreateNewBatch
            // 
            CreateNewBatch.Anchor = AnchorStyles.Left;
            CreateNewBatch.Location = new Point(129, 194);
            CreateNewBatch.Name = "CreateNewBatch";
            CreateNewBatch.Size = new Size(219, 151);
            CreateNewBatch.TabIndex = 0;
            CreateNewBatch.Text = "Create New Batch";
            CreateNewBatch.UseVisualStyleBackColor = true;
            CreateNewBatch.Click += CreateNewBatch_Click;
            // 
            // CreateBatchPanel
            // 
            CreateBatchPanel.BackColor = SystemColors.GradientInactiveCaption;
            CreateBatchPanel.Controls.Add(Desc1);
            CreateBatchPanel.Controls.Add(TablePanel);
            CreateBatchPanel.Controls.Add(AddExeFiles);
            CreateBatchPanel.Controls.Add(ExportBatch);
            CreateBatchPanel.Dock = DockStyle.Fill;
            CreateBatchPanel.Location = new Point(0, 0);
            CreateBatchPanel.Name = "CreateBatchPanel";
            CreateBatchPanel.Size = new Size(729, 492);
            CreateBatchPanel.TabIndex = 1;
            CreateBatchPanel.Visible = false;
            // 
            // Desc1
            // 
            Desc1.AutoSize = true;
            Desc1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            Desc1.Location = new Point(11, 9);
            Desc1.Name = "Desc1";
            Desc1.Size = new Size(463, 31);
            Desc1.TabIndex = 3;
            Desc1.Text = "Add files below to launch with the batch file";
            // 
            // TablePanel
            // 
            TablePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TablePanel.AutoScroll = true;
            TablePanel.BackColor = SystemColors.ControlLightLight;
            TablePanel.FlowDirection = FlowDirection.TopDown;
            TablePanel.Location = new Point(0, 49);
            TablePanel.Name = "TablePanel";
            TablePanel.Size = new Size(729, 358);
            TablePanel.TabIndex = 2;
            TablePanel.WrapContents = false;
            // 
            // AddExeFiles
            // 
            AddExeFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddExeFiles.AutoSize = true;
            AddExeFiles.Location = new Point(62, 432);
            AddExeFiles.Name = "AddExeFiles";
            AddExeFiles.Size = new Size(100, 20);
            AddExeFiles.TabIndex = 1;
            AddExeFiles.TabStop = true;
            AddExeFiles.Text = "Add .exe Files";
            AddExeFiles.LinkClicked += AddExeFiles_LinkClicked;
            // 
            // ExportBatch
            // 
            ExportBatch.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ExportBatch.Location = new Point(567, 432);
            ExportBatch.Name = "ExportBatch";
            ExportBatch.Size = new Size(94, 29);
            ExportBatch.TabIndex = 0;
            ExportBatch.Text = "Export Batch";
            ExportBatch.UseVisualStyleBackColor = true;
            ExportBatch.Click += ExportBatch_Click;
            // 
            // MPL
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 492);
            Controls.Add(CreateBatchPanel);
            Controls.Add(HomePanel);
            Name = "MPL";
            Text = "Multiple Program Launcher 1.0";
            HomePanel.ResumeLayout(false);
            CreateBatchPanel.ResumeLayout(false);
            CreateBatchPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel HomePanel;
        private Button EditBatch;
        private Button CreateNewBatch;
        private Panel CreateBatchPanel;
        private Button ExportBatch;
        private LinkLabel AddExeFiles;
        private FlowLayoutPanel TablePanel;
        private Label Desc1;
    }
}