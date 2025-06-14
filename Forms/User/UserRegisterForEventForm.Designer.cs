namespace lab04.Forms.User
{
    partial class UserRegisterForEventForm
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
            components = new System.ComponentModel.Container();
            lblEvent = new Label();
            cmbEvents = new ComboBox();
            lblAgenda = new Label();
            txtAgenda = new TextBox();
            lblEventDate = new Label();
            lblParticipationType = new Label();
            cmbParticipationType = new ComboBox();
            lblFoodPreferences = new Label();
            cmbFoodPreferences = new ComboBox();
            btnRegister = new Button();
            btnCancel = new Button();
            panelButtons = new Panel();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblEvent
            // 
            lblEvent.AutoSize = true;
            lblEvent.Location = new Point(12, 15);
            lblEvent.Name = "lblEvent";
            lblEvent.Size = new Size(89, 15);
            lblEvent.TabIndex = 0;
            lblEvent.Text = "Wydarzenie:";
            // 
            // cmbEvents
            // 
            cmbEvents.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEvents.FormattingEnabled = true;
            cmbEvents.Location = new Point(107, 12);
            cmbEvents.Name = "cmbEvents";
            cmbEvents.Size = new Size(250, 23);
            cmbEvents.TabIndex = 1;
            cmbEvents.SelectedIndexChanged += cmbEvents_SelectedIndexChanged;
            // 
            // lblAgenda
            // 
            lblAgenda.AutoSize = true;
            lblAgenda.Location = new Point(12, 50);
            lblAgenda.Name = "lblAgenda";
            lblAgenda.Size = new Size(50, 15);
            lblAgenda.TabIndex = 2;
            lblAgenda.Text = "Agenda:";
            // 
            // txtAgenda
            // 
            txtAgenda.Location = new Point(107, 47);
            txtAgenda.Multiline = true;
            txtAgenda.Name = "txtAgenda";
            txtAgenda.ReadOnly = true;
            txtAgenda.Size = new Size(250, 60);
            txtAgenda.TabIndex = 3;
            // 
            // lblEventDate
            // 
            lblEventDate.AutoSize = true;
            lblEventDate.Location = new Point(12, 120);
            lblEventDate.Name = "lblEventDate";
            lblEventDate.Size = new Size(45, 15);
            lblEventDate.TabIndex = 4;
            lblEventDate.Text = "Termin:";
            // 
            // lblParticipationType
            // 
            lblParticipationType.AutoSize = true;
            lblParticipationType.Location = new Point(12, 150);
            lblParticipationType.Name = "lblParticipationType";
            lblParticipationType.Size = new Size(89, 15);
            lblParticipationType.TabIndex = 5;
            lblParticipationType.Text = "Typ uczestnictwa:";
            // 
            // cmbParticipationType
            // 
            cmbParticipationType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParticipationType.FormattingEnabled = true;
            cmbParticipationType.Location = new Point(107, 147);
            cmbParticipationType.Name = "cmbParticipationType";
            cmbParticipationType.Size = new Size(250, 23);
            cmbParticipationType.TabIndex = 6;
            // 
            // lblFoodPreferences
            // 
            lblFoodPreferences.AutoSize = true;
            lblFoodPreferences.Location = new Point(12, 180);
            lblFoodPreferences.Name = "lblFoodPreferences";
            lblFoodPreferences.Size = new Size(89, 15);
            lblFoodPreferences.TabIndex = 7;
            lblFoodPreferences.Text = "Wyżywienie:";
            // 
            // cmbFoodPreferences
            // 
            cmbFoodPreferences.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFoodPreferences.FormattingEnabled = true;
            cmbFoodPreferences.Location = new Point(107, 177);
            cmbFoodPreferences.Name = "cmbFoodPreferences";
            cmbFoodPreferences.Size = new Size(250, 23);
            cmbFoodPreferences.TabIndex = 8;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(107, 10);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(120, 30);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Zarejestruj";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(237, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 30);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnRegister);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 220);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(384, 50);
            panelButtons.TabIndex = 11;
            // 
            // UserRegisterForEventForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 270);
            Controls.Add(panelButtons);
            Controls.Add(cmbFoodPreferences);
            Controls.Add(lblFoodPreferences);
            Controls.Add(cmbParticipationType);
            Controls.Add(lblParticipationType);
            Controls.Add(lblEventDate);
            Controls.Add(txtAgenda);
            Controls.Add(lblAgenda);
            Controls.Add(cmbEvents);
            Controls.Add(lblEvent);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UserRegisterForEventForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rejestracja na wydarzenie";
            Load += UserRegisterForEventForm_Load;
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEvent;
        private ComboBox cmbEvents;
        private Label lblAgenda;
        private TextBox txtAgenda;
        private Label lblEventDate;
        private Label lblParticipationType;
        private ComboBox cmbParticipationType;
        private Label lblFoodPreferences;
        private ComboBox cmbFoodPreferences;
        private Button btnRegister;
        private Button btnCancel;
        private Panel panelButtons;
    }
} 