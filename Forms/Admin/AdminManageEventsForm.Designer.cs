namespace lab04.Forms.Admin
{
    partial class AdminManageEventsForm
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
            dataGridViewEvents = new DataGridView();
            toolStrip = new ToolStrip();
            btnAddEvent = new ToolStripButton();
            btnEditEvent = new ToolStripButton();
            btnDeleteEvent = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).BeginInit();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewEvents
            // 
            dataGridViewEvents.AllowUserToAddRows = false;
            dataGridViewEvents.AllowUserToDeleteRows = false;
            dataGridViewEvents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEvents.Location = new Point(12, 28);
            dataGridViewEvents.MultiSelect = false;
            dataGridViewEvents.Name = "dataGridViewEvents";
            dataGridViewEvents.ReadOnly = true;
            dataGridViewEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewEvents.Size = new Size(776, 381);
            dataGridViewEvents.TabIndex = 0;
            dataGridViewEvents.SelectionChanged += dataGridViewEvents_SelectionChanged;
            dataGridViewEvents.DoubleClick += dataGridViewEvents_DoubleClick;
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { btnAddEvent, btnEditEvent, btnDeleteEvent, btnRefresh });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // btnAddEvent
            // 
            btnAddEvent.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnAddEvent.ImageTransparentColor = Color.Magenta;
            btnAddEvent.Name = "btnAddEvent";
            btnAddEvent.Size = new Size(42, 22);
            btnAddEvent.Text = "Dodaj";
            btnAddEvent.Click += btnAddEvent_Click;
            // 
            // btnEditEvent
            // 
            btnEditEvent.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnEditEvent.Enabled = false;
            btnEditEvent.ImageTransparentColor = Color.Magenta;
            btnEditEvent.Name = "btnEditEvent";
            btnEditEvent.Size = new Size(44, 22);
            btnEditEvent.Text = "Edytuj";
            btnEditEvent.Click += btnEditEvent_Click;
            // 
            // btnDeleteEvent
            // 
            btnDeleteEvent.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDeleteEvent.Enabled = false;
            btnDeleteEvent.ImageTransparentColor = Color.Magenta;
            btnDeleteEvent.Name = "btnDeleteEvent";
            btnDeleteEvent.Size = new Size(38, 22);
            btnDeleteEvent.Text = "Usuń";
            btnDeleteEvent.Click += btnDeleteEvent_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnRefresh.ImageTransparentColor = Color.Magenta;
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(55, 22);
            btnRefresh.Text = "Odśwież";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 428);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(800, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // AdminManageEventsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Controls.Add(dataGridViewEvents);
            Name = "AdminManageEventsForm";
            Text = "Zarządzanie wydarzeniami";
            Load += AdminManageEventsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).EndInit();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewEvents;
        private ToolStrip toolStrip;
        private ToolStripButton btnAddEvent;
        private ToolStripButton btnEditEvent;
        private ToolStripButton btnDeleteEvent;
        private ToolStripButton btnRefresh;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
    }
} 