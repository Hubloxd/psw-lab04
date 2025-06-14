using lab04.Data.Models;
using System.ComponentModel;

namespace lab04;

partial class AdminDashboardForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        headerPanel = new Panel();
        titleLabel = new Label();
        welcomeLabel = new Label();
        logoutButton = new Button();
        mainPanel = new Panel();
        statsPanel = new Panel();
        statsLabel = new Label();
        usersCountLabel = new Label();
        eventsCountLabel = new Label();
        registrationsCountLabel = new Label();
        navPanel = new Panel();
        navLabel = new Label();
        usersButton = new Button();
        eventsButton = new Button();
        registrationsButton = new Button();
        footerPanel = new Panel();
        statusLabel = new Label();
        timeLabel = new Label();
        headerPanel.SuspendLayout();
        mainPanel.SuspendLayout();
        statsPanel.SuspendLayout();
        navPanel.SuspendLayout();
        footerPanel.SuspendLayout();
        SuspendLayout();
        // 
        // headerPanel
        // 
        headerPanel.BackColor = Color.FromArgb(52, 73, 94);
        headerPanel.Controls.Add(titleLabel);
        headerPanel.Controls.Add(welcomeLabel);
        headerPanel.Controls.Add(logoutButton);
        headerPanel.Dock = DockStyle.Top;
        headerPanel.Location = new Point(0, 0);
        headerPanel.Name = "headerPanel";
        headerPanel.Size = new Size(1000, 80);
        headerPanel.TabIndex = 0;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        titleLabel.ForeColor = Color.White;
        titleLabel.Location = new Point(20, 15);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(269, 32);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Panel Administracyjny";
        // 
        // welcomeLabel
        // 
        welcomeLabel.AutoSize = true;
        welcomeLabel.Font = new Font("Segoe UI", 10F);
        welcomeLabel.ForeColor = Color.FromArgb(189, 195, 199);
        welcomeLabel.Location = new Point(20, 50);
        welcomeLabel.Name = "welcomeLabel";
        welcomeLabel.Size = new Size(135, 19);
        welcomeLabel.TabIndex = 1;
        welcomeLabel.Text = "Witaj, Administrator!";
        // 
        // logoutButton
        // 
        logoutButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        logoutButton.BackColor = Color.FromArgb(231, 76, 60);
        logoutButton.FlatAppearance.BorderSize = 0;
        logoutButton.FlatStyle = FlatStyle.Flat;
        logoutButton.Font = new Font("Segoe UI", 10F);
        logoutButton.ForeColor = Color.White;
        logoutButton.Location = new Point(1680, 25);
        logoutButton.Name = "logoutButton";
        logoutButton.Size = new Size(100, 30);
        logoutButton.TabIndex = 2;
        logoutButton.Text = "Wyloguj";
        logoutButton.UseVisualStyleBackColor = false;
        logoutButton.Click += LogoutButton_Click;
        // 
        // mainPanel
        // 
        mainPanel.BackColor = Color.FromArgb(236, 240, 241);
        mainPanel.Controls.Add(statsPanel);
        mainPanel.Controls.Add(navPanel);
        mainPanel.Dock = DockStyle.Fill;
        mainPanel.Location = new Point(0, 80);
        mainPanel.Name = "mainPanel";
        mainPanel.Padding = new Padding(20);
        mainPanel.Size = new Size(1000, 420);
        mainPanel.TabIndex = 1;
        // 
        // statsPanel
        // 
        statsPanel.BackColor = Color.White;
        statsPanel.BorderStyle = BorderStyle.FixedSingle;
        statsPanel.Controls.Add(statsLabel);
        statsPanel.Controls.Add(usersCountLabel);
        statsPanel.Controls.Add(eventsCountLabel);
        statsPanel.Controls.Add(registrationsCountLabel);
        statsPanel.Location = new Point(30, 30);
        statsPanel.Name = "statsPanel";
        statsPanel.Size = new Size(940, 120);
        statsPanel.TabIndex = 0;
        // 
        // statsLabel
        // 
        statsLabel.AutoSize = true;
        statsLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        statsLabel.ForeColor = Color.FromArgb(52, 73, 94);
        statsLabel.Location = new Point(20, 15);
        statsLabel.Name = "statsLabel";
        statsLabel.Size = new Size(98, 25);
        statsLabel.TabIndex = 0;
        statsLabel.Text = "Statystyki";
        // 
        // usersCountLabel
        // 
        usersCountLabel.BackColor = Color.FromArgb(52, 152, 219);
        usersCountLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        usersCountLabel.ForeColor = Color.White;
        usersCountLabel.Location = new Point(30, 60);
        usersCountLabel.Name = "usersCountLabel";
        usersCountLabel.Size = new Size(200, 40);
        usersCountLabel.TabIndex = 1;
        usersCountLabel.Text = "Użytkownicy: 0";
        usersCountLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // eventsCountLabel
        // 
        eventsCountLabel.BackColor = Color.FromArgb(46, 204, 113);
        eventsCountLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        eventsCountLabel.ForeColor = Color.White;
        eventsCountLabel.Location = new Point(250, 60);
        eventsCountLabel.Name = "eventsCountLabel";
        eventsCountLabel.Size = new Size(200, 40);
        eventsCountLabel.TabIndex = 2;
        eventsCountLabel.Text = "Wydarzenia: 0";
        eventsCountLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // registrationsCountLabel
        // 
        registrationsCountLabel.BackColor = Color.FromArgb(155, 89, 182);
        registrationsCountLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        registrationsCountLabel.ForeColor = Color.White;
        registrationsCountLabel.Location = new Point(470, 60);
        registrationsCountLabel.Name = "registrationsCountLabel";
        registrationsCountLabel.Size = new Size(200, 40);
        registrationsCountLabel.TabIndex = 3;
        registrationsCountLabel.Text = "Zapisy: 0";
        registrationsCountLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // navPanel
        // 
        navPanel.BackColor = Color.White;
        navPanel.BorderStyle = BorderStyle.FixedSingle;
        navPanel.Controls.Add(navLabel);
        navPanel.Controls.Add(usersButton);
        navPanel.Controls.Add(eventsButton);
        navPanel.Controls.Add(registrationsButton);
        navPanel.Location = new Point(30, 170);
        navPanel.Name = "navPanel";
        navPanel.Size = new Size(940, 200);
        navPanel.TabIndex = 1;
        // 
        // navLabel
        // 
        navLabel.AutoSize = true;
        navLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        navLabel.ForeColor = Color.FromArgb(52, 73, 94);
        navLabel.Location = new Point(20, 15);
        navLabel.Name = "navLabel";
        navLabel.Size = new Size(97, 25);
        navLabel.TabIndex = 0;
        navLabel.Text = "Zarządzaj";
        // 
        // usersButton
        // 
        usersButton.BackColor = Color.FromArgb(52, 152, 219);
        usersButton.FlatAppearance.BorderSize = 0;
        usersButton.FlatStyle = FlatStyle.Flat;
        usersButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        usersButton.ForeColor = Color.White;
        usersButton.Location = new Point(30, 70);
        usersButton.Name = "usersButton";
        usersButton.Size = new Size(200, 80);
        usersButton.TabIndex = 1;
        usersButton.Text = "👥\r\nUżytkownicy";
        usersButton.UseVisualStyleBackColor = false;
        usersButton.Click += UsersButton_Click;
        usersButton.MouseEnter += Button_MouseEnter;
        usersButton.MouseLeave += Button_MouseLeave;
        // 
        // eventsButton
        // 
        eventsButton.BackColor = Color.FromArgb(46, 204, 113);
        eventsButton.FlatAppearance.BorderSize = 0;
        eventsButton.FlatStyle = FlatStyle.Flat;
        eventsButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        eventsButton.ForeColor = Color.White;
        eventsButton.Location = new Point(250, 70);
        eventsButton.Name = "eventsButton";
        eventsButton.Size = new Size(200, 80);
        eventsButton.TabIndex = 2;
        eventsButton.Text = "📅\r\nWydarzenia";
        eventsButton.UseVisualStyleBackColor = false;
        eventsButton.Click += EventsButton_Click;
        eventsButton.MouseEnter += Button_MouseEnter;
        eventsButton.MouseLeave += Button_MouseLeave;
        // 
        // registrationsButton
        // 
        registrationsButton.BackColor = Color.FromArgb(155, 89, 182);
        registrationsButton.FlatAppearance.BorderSize = 0;
        registrationsButton.FlatStyle = FlatStyle.Flat;
        registrationsButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        registrationsButton.ForeColor = Color.White;
        registrationsButton.Location = new Point(470, 70);
        registrationsButton.Name = "registrationsButton";
        registrationsButton.Size = new Size(200, 80);
        registrationsButton.TabIndex = 3;
        registrationsButton.Text = "📝\r\nZapisy";
        registrationsButton.UseVisualStyleBackColor = false;
        registrationsButton.Click += RegistrationsButton_Click;
        registrationsButton.MouseEnter += Button_MouseEnter;
        registrationsButton.MouseLeave += Button_MouseLeave;
        // 
        // footerPanel
        // 
        footerPanel.BackColor = Color.FromArgb(44, 62, 80);
        footerPanel.Controls.Add(statusLabel);
        footerPanel.Controls.Add(timeLabel);
        footerPanel.Dock = DockStyle.Bottom;
        footerPanel.Location = new Point(0, 500);
        footerPanel.Name = "footerPanel";
        footerPanel.Size = new Size(1000, 30);
        footerPanel.TabIndex = 2;
        // 
        // statusLabel
        // 
        statusLabel.AutoSize = true;
        statusLabel.ForeColor = Color.White;
        statusLabel.Location = new Point(20, 8);
        statusLabel.Name = "statusLabel";
        statusLabel.Size = new Size(99, 15);
        statusLabel.TabIndex = 0;
        statusLabel.Text = "Status: Połączony";
        // 
        // timeLabel
        // 
        timeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        timeLabel.AutoSize = true;
        timeLabel.ForeColor = Color.White;
        timeLabel.Location = new Point(1680, 8);
        timeLabel.Name = "timeLabel";
        timeLabel.Size = new Size(91, 15);
        timeLabel.TabIndex = 1;
        timeLabel.Text = "14.06.2025 02:03";
        // 
        // AdminDashboardForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 530);
        Controls.Add(mainPanel);
        Controls.Add(headerPanel);
        Controls.Add(footerPanel);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "AdminDashboardForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "System Zarządzania - Panel Administratora";
        Load += AdminDashboardForm_Load;
        headerPanel.ResumeLayout(false);
        headerPanel.PerformLayout();
        mainPanel.ResumeLayout(false);
        statsPanel.ResumeLayout(false);
        statsPanel.PerformLayout();
        navPanel.ResumeLayout(false);
        navPanel.PerformLayout();
        footerPanel.ResumeLayout(false);
        footerPanel.PerformLayout();
        ResumeLayout(false);
    }

    private void ReportsButton_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    #endregion

    private Panel headerPanel;
    private Label titleLabel;
    private Label welcomeLabel;
    private Button logoutButton;
    private Panel mainPanel;
    private Panel statsPanel;
    private Label statsLabel;
    private Label usersCountLabel;
    private Label eventsCountLabel;
    private Label registrationsCountLabel;
    private Panel navPanel;
    private Label navLabel;
    private Button usersButton;
    private Button eventsButton;
    private Button registrationsButton;
    private Panel footerPanel;
    private Label statusLabel;
    private Label timeLabel;
}