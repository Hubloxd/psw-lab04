using lab04.Data.Models;
using lab04.Forms.Admin;
using lab04.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab04;

public partial class AdminDashboardForm : Form
{
    private System.Windows.Forms.Timer clockTimer;
    public AdminDashboardForm()
    {
        throw new ArgumentNullException(Name);
    }

    public AdminDashboardForm(Data.Models.User user, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        this._user = user;
        this._serviceProvider = serviceProvider;
    }

    private readonly IServiceProvider _serviceProvider;
    private readonly Data.Models.User _user;

    private void AdminDashboardForm_Load(object sender, EventArgs e)
    {
        LoadStatistics();
        InitializeClock();
        UpdateStatusBar();
    }

    private void InitializeClock()
    {
        clockTimer = new();
        clockTimer.Interval = 1000; // Update every second
        clockTimer.Tick += ClockTimer_Tick;
        clockTimer.Start();
    }

    private void ClockTimer_Tick(object sender, EventArgs e)
    {
        timeLabel.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }

    private void LoadStatistics()
    {
        try
        {
            var userService = _serviceProvider.GetRequiredService<UserService>();
            var eventService = _serviceProvider.GetRequiredService<EventService>();
            var registrationService = _serviceProvider.GetRequiredService<RegistrationService>();

            int usersCount = userService.GetUsersCount();
            int eventsCount = eventService.GetEventsCount();
            int registrationsCount = registrationService.GetRegistrationsCount();

            usersCountLabel.Text = $"Użytkownicy: {usersCount}";
            eventsCountLabel.Text = $"Wydarzenia: {eventsCount}";
            registrationsCountLabel.Text = $"Zapisy: {registrationsCount}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas ładowania statystyk: {ex.Message}",
                "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void UpdateStatusBar()
    {
        statusLabel.Text = $"Zalogowany jako: {_user.FirstName} {_user.LastName} ({_user.Login})";
    }

    private void UsersButton_Click(object sender, EventArgs e)
    {
        try
        {
            var usersForm = new AdminManageUsersForm(this._serviceProvider);
            this.Hide();
            usersForm.ShowDialog();
            this.Show();
            LoadStatistics();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas otwierania modułu użytkowników: {ex.Message}",
                "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void EventsButton_Click(object sender, EventArgs e)
    {
        try
        {
            var eventsForm = new AdminManageEventsForm(this._serviceProvider);
            this.Hide();
            eventsForm.ShowDialog();
            this.Show();
            LoadStatistics();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas otwierania modułu wydarzeń: {ex.Message}",
                "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void RegistrationsButton_Click(object sender, EventArgs e)
    {
        try
        {
            var registrationsForm = new AdminManageRegistrationsForm(this._serviceProvider);
            this.Hide();
            registrationsForm.ShowDialog();
            this.Show();
            LoadStatistics();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Błąd podczas otwierania modułu zapisów: {ex.Message}",
                "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LogoutButton_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Czy na pewno chcesz się wylogować?",
            "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            clockTimer?.Stop();
            this.Close();
        }
    }

    private void Button_MouseEnter(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            button.BackColor = LightenColor(button.BackColor, 20);
            button.Cursor = Cursors.Hand;
        }
    }

    private void Button_MouseLeave(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            // Przywróć oryginalne kolory
            if (button == usersButton)
                button.BackColor = Color.FromArgb(52, 152, 219);
            else if (button == eventsButton)
                button.BackColor = Color.FromArgb(46, 204, 113);
            else if (button == registrationsButton)
                button.BackColor = Color.FromArgb(155, 89, 182);

            button.Cursor = Cursors.Default;
        }
    }

    private Color LightenColor(Color color, int amount)
    {
        int r = Math.Min(255, color.R + amount);
        int g = Math.Min(255, color.G + amount);
        int b = Math.Min(255, color.B + amount);
        return Color.FromArgb(r, g, b);
    }

    public void RefreshData()
    {
        LoadStatistics();
        UpdateStatusBar();
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            clockTimer?.Stop();
            clockTimer?.Dispose();
            components?.Dispose();
        }
        base.Dispose(disposing);
    }
}