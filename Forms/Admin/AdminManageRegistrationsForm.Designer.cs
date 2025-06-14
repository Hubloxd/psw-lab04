namespace lab04.Forms.Admin
{
    partial class AdminManageRegistrationsForm
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
            dataGridViewRegistrations = new DataGridView();
            toolStrip = new ToolStrip();
            btnApprove = new ToolStripButton();
            btnReject = new ToolStripButton();
            btnRefresh = new ToolStripButton();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            lblEvent = new Label();
            cmbEvents = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRegistrations).BeginInit();
            toolStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewRegistrations
            // 
            dataGridViewRegistrations.AllowUserToAddRows = false;
            dataGridViewRegistrations.AllowUserToDeleteRows = false;
            dataGridViewRegistrations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRegistrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRegistrations.Location = new Point(12, 55);
            dataGridViewRegistrations.MultiSelect = false;
            dataGridViewRegistrations.Name = "dataGridViewRegistrations";
            dataGridViewRegistrations.ReadOnly = true;
            dataGridViewRegistrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRegistrations.Size = new Size(776, 354);
            dataGridViewRegistrations.TabIndex = 0;
            dataGridViewRegistrations.SelectionChanged += dataGridViewRegistrations_SelectionChanged;
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { btnApprove, btnReject, btnRefresh });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(800, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // btnApprove
            // 
            btnApprove.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnApprove.Enabled = false;
            btnApprove.ImageTransparentColor = Color.Magenta;
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(62, 22);
            btnApprove.Text = "Zatwierdź";
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnReject.Enabled = false;
            btnReject.ImageTransparentColor = Color.Magenta;
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(49, 22);
            btnReject.Text = "Odrzuć";
            btnReject.Click += btnReject_Click;
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
            // lblEvent
            // 
            lblEvent.AutoSize = true;
            lblEvent.Location = new Point(12, 32);
            lblEvent.Name = "lblEvent";
            lblEvent.Size = new Size(71, 15);
            lblEvent.TabIndex = 3;
            lblEvent.Text = "Wydarzenie:";
            // 
            // cmbEvents
            // 
            cmbEvents.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEvents.FormattingEnabled = true;
            cmbEvents.Location = new Point(93, 29);
            cmbEvents.Name = "cmbEvents";
            cmbEvents.Size = new Size(250, 23);
            cmbEvents.TabIndex = 4;
            cmbEvents.SelectedIndexChanged += cmbEvents_SelectedIndexChanged;
            // 
            // AdminManageRegistrationsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbEvents);
            Controls.Add(lblEvent);
            Controls.Add(statusStrip);
            Controls.Add(toolStrip);
            Controls.Add(dataGridViewRegistrations);
            Name = "AdminManageRegistrationsForm";
            Text = "Zarządzanie rejestracjami";
            Load += AdminManageRegistrationsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewRegistrations).EndInit();
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewRegistrations;
        private ToolStrip toolStrip;
        private ToolStripButton btnApprove;
        private ToolStripButton btnReject;
        private ToolStripButton btnRefresh;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private Label lblEvent;
        private ComboBox cmbEvents;
    }
} 