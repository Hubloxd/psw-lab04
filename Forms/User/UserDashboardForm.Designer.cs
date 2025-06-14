using System.ComponentModel;

namespace lab04.Forms.User;

partial class UserDashboardForm
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
        panelUserInfo = new Panel();
        lblUserEmail = new Label();
        lblUserLogin = new Label();
        lblUserName = new Label();
        label3 = new Label();
        label2 = new Label();
        label1 = new Label();
        panelRegistrations = new Panel();
        dataGridViewRegistrations = new DataGridView();
        label4 = new Label();
        panelButtons = new Panel();
        btnLogout = new Button();
        btnRegisterForEvent = new Button();
        statusStrip = new StatusStrip();
        toolStripStatusLabel = new ToolStripStatusLabel();
        timeLabel = new Label();
        panelUserInfo.SuspendLayout();
        panelRegistrations.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewRegistrations).BeginInit();
        panelButtons.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();
        // 
        // panelUserInfo
        // 
        panelUserInfo.BackColor = Color.White;
        panelUserInfo.BorderStyle = BorderStyle.FixedSingle;
        panelUserInfo.Controls.Add(lblUserEmail);
        panelUserInfo.Controls.Add(lblUserLogin);
        panelUserInfo.Controls.Add(lblUserName);
        panelUserInfo.Controls.Add(label3);
        panelUserInfo.Controls.Add(label2);
        panelUserInfo.Controls.Add(label1);
        panelUserInfo.Location = new Point(12, 12);
        panelUserInfo.Name = "panelUserInfo";
        panelUserInfo.Size = new Size(300, 120);
        panelUserInfo.TabIndex = 0;
        // 
        // lblUserEmail
        // 
        lblUserEmail.AutoSize = true;
        lblUserEmail.Location = new Point(100, 80);
        lblUserEmail.Name = "lblUserEmail";
        lblUserEmail.Size = new Size(38, 15);
        lblUserEmail.TabIndex = 5;
        lblUserEmail.Text = "Email";
        // 
        // lblUserLogin
        // 
        lblUserLogin.AutoSize = true;
        lblUserLogin.Location = new Point(100, 50);
        lblUserLogin.Name = "lblUserLogin";
        lblUserLogin.Size = new Size(37, 15);
        lblUserLogin.TabIndex = 4;
        lblUserLogin.Text = "Login";
        // 
        // lblUserName
        // 
        lblUserName.AutoSize = true;
        lblUserName.Location = new Point(100, 20);
        lblUserName.Name = "lblUserName";
        lblUserName.Size = new Size(38, 15);
        lblUserName.TabIndex = 3;
        lblUserName.Text = "Name";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(20, 80);
        label3.Name = "label3";
        label3.Size = new Size(41, 15);
        label3.TabIndex = 2;
        label3.Text = "Email:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(20, 50);
        label2.Name = "label2";
        label2.Size = new Size(40, 15);
        label2.TabIndex = 1;
        label2.Text = "Login:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(20, 20);
        label1.Name = "label1";
        label1.Size = new Size(33, 15);
        label1.TabIndex = 0;
        label1.Text = "Imię:";
        // 
        // panelRegistrations
        // 
        panelRegistrations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelRegistrations.BackColor = Color.White;
        panelRegistrations.BorderStyle = BorderStyle.FixedSingle;
        panelRegistrations.Controls.Add(dataGridViewRegistrations);
        panelRegistrations.Controls.Add(label4);
        panelRegistrations.Location = new Point(12, 150);
        panelRegistrations.Name = "panelRegistrations";
        panelRegistrations.Size = new Size(776, 300);
        panelRegistrations.TabIndex = 1;
        // 
        // dataGridViewRegistrations
        // 
        dataGridViewRegistrations.AllowUserToAddRows = false;
        dataGridViewRegistrations.AllowUserToDeleteRows = false;
        dataGridViewRegistrations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewRegistrations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridViewRegistrations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewRegistrations.Location = new Point(10, 30);
        dataGridViewRegistrations.MultiSelect = false;
        dataGridViewRegistrations.Name = "dataGridViewRegistrations";
        dataGridViewRegistrations.ReadOnly = true;
        dataGridViewRegistrations.RowTemplate.Height = 25;
        dataGridViewRegistrations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridViewRegistrations.Size = new Size(754, 258);
        dataGridViewRegistrations.TabIndex = 1;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(10, 10);
        label4.Name = "label4";
        label4.Size = new Size(89, 15);
        label4.TabIndex = 0;
        label4.Text = "Moje rejestracje:";
        // 
        // panelButtons
        // 
        panelButtons.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        panelButtons.Controls.Add(btnLogout);
        panelButtons.Controls.Add(btnRegisterForEvent);
        panelButtons.Location = new Point(12, 460);
        panelButtons.Name = "panelButtons";
        panelButtons.Size = new Size(776, 50);
        panelButtons.TabIndex = 2;
        // 
        // btnLogout
        // 
        btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLogout.BackColor = Color.FromArgb(231, 76, 60);
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.FlatStyle = FlatStyle.Flat;
        btnLogout.ForeColor = Color.White;
        btnLogout.Location = new Point(656, 10);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(120, 30);
        btnLogout.TabIndex = 1;
        btnLogout.Text = "Wyloguj";
        btnLogout.UseVisualStyleBackColor = false;
        btnLogout.Click += btnLogout_Click;
        btnLogout.MouseEnter += Button_MouseEnter;
        btnLogout.MouseLeave += Button_MouseLeave;
        // 
        // btnRegisterForEvent
        // 
        btnRegisterForEvent.BackColor = Color.FromArgb(52, 152, 219);
        btnRegisterForEvent.FlatAppearance.BorderSize = 0;
        btnRegisterForEvent.FlatStyle = FlatStyle.Flat;
        btnRegisterForEvent.ForeColor = Color.White;
        btnRegisterForEvent.Location = new Point(10, 10);
        btnRegisterForEvent.Name = "btnRegisterForEvent";
        btnRegisterForEvent.Size = new Size(120, 30);
        btnRegisterForEvent.TabIndex = 0;
        btnRegisterForEvent.Text = "Zapisz się";
        btnRegisterForEvent.UseVisualStyleBackColor = false;
        btnRegisterForEvent.Click += btnRegisterForEvent_Click;
        btnRegisterForEvent.MouseEnter += Button_MouseEnter;
        btnRegisterForEvent.MouseLeave += Button_MouseLeave;
        // 
        // statusStrip
        // 
        statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
        statusStrip.Location = new Point(0, 520);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(800, 22);
        statusStrip.TabIndex = 3;
        statusStrip.Text = "statusStrip1";
        // 
        // toolStripStatusLabel
        // 
        toolStripStatusLabel.Name = "toolStripStatusLabel";
        toolStripStatusLabel.Size = new Size(0, 17);
        // 
        // timeLabel
        // 
        timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        timeLabel.AutoSize = true;
        timeLabel.Location = new Point(688, 12);
        timeLabel.Name = "timeLabel";
        timeLabel.Size = new Size(100, 15);
        timeLabel.TabIndex = 4;
        timeLabel.Text = "00.00.0000 00:00:00";
        // 
        // UserDashboardForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(236, 240, 241);
        ClientSize = new Size(800, 542);
        Controls.Add(timeLabel);
        Controls.Add(statusStrip);
        Controls.Add(panelButtons);
        Controls.Add(panelRegistrations);
        Controls.Add(panelUserInfo);
        MinimumSize = new Size(816, 581);
        Name = "UserDashboardForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Panel użytkownika";
        Load += UserDashboardForm_Load;
        panelUserInfo.ResumeLayout(false);
        panelUserInfo.PerformLayout();
        panelRegistrations.ResumeLayout(false);
        panelRegistrations.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridViewRegistrations).EndInit();
        panelButtons.ResumeLayout(false);
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel panelUserInfo;
    private Label lblUserEmail;
    private Label lblUserLogin;
    private Label lblUserName;
    private Label label3;
    private Label label2;
    private Label label1;
    private Panel panelRegistrations;
    private DataGridView dataGridViewRegistrations;
    private Label label4;
    private Panel panelButtons;
    private Button btnLogout;
    private Button btnRegisterForEvent;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel toolStripStatusLabel;
    private Label timeLabel;
}