using lab04.Data.Models;
using lab04.Services;
using Microsoft.Extensions.DependencyInjection;

namespace lab04.Forms.User
{
    public partial class UserDashboardForm : Form
    {
        private readonly Data.Models.User currentUser;
        private readonly IServiceProvider serviceProvider;
        private readonly RegistrationService registrationService;
        private readonly EventService eventService;
        private System.Windows.Forms.Timer clockTimer;

        public UserDashboardForm(Data.Models.User user, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.currentUser = user;
            this.serviceProvider = serviceProvider;
            this.registrationService = serviceProvider.GetRequiredService<RegistrationService>();
            this.eventService = serviceProvider.GetRequiredService<EventService>();
        }

        private void UserDashboardForm_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
            LoadRegistrations();
            InitializeClock();
            UpdateStatusBar();
        }

        private void InitializeClock()
        {
            clockTimer = new System.Windows.Forms.Timer();
            clockTimer.Interval = 1000; // Update every second
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void LoadUserInfo()
        {
            lblUserName.Text = $"{currentUser.FirstName} {currentUser.LastName}";
            lblUserLogin.Text = currentUser.Login;
            lblUserEmail.Text = currentUser.Email;
        }

        private void LoadRegistrations()
        {
            try
            {
                var userId = currentUser.Id;
                var registrations = registrationService.GetAllUsersRegistrations(userId).Result;


                if (registrations.Length == 0)
                {
                    ShowInfo("Nie masz żadnych rejestracji.");
                    dataGridViewRegistrations.DataSource = null;
                    return;
                }

                dataGridViewRegistrations.DataSource = registrations;
                UpdateStatusLabel($"Załadowano {registrations.Length} rejestracji.");
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas ładowania rejestracji: {ex.Message}");
            }
        }

        private void UpdateStatusBar()
        {
            toolStripStatusLabel.Text = $"Zalogowany jako: {currentUser.FirstName} {currentUser.LastName} ({currentUser.Login})";
        }

        private void btnRegisterForEvent_Click(object sender, EventArgs e)
        {
            try
            {
                using var registerForm = new UserRegisterForEventForm(currentUser, serviceProvider);
                if (registerForm.ShowDialog() == DialogResult.OK)
                {
                    LoadRegistrations();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas otwierania formularza rejestracji: {ex.Message}");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Czy na pewno chcesz się wylogować?",
                "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                clockTimer?.Stop();
                this.Close();
            }
        }

        private void UpdateStatusLabel(string message)
        {
            toolStripStatusLabel.Text = $"{DateTime.Now:HH:mm:ss} - {message}";
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(button.BackColor.R + 20, button.BackColor.G + 20, button.BackColor.B + 20);
                button.Cursor = Cursors.Hand;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == btnRegisterForEvent)
                    button.BackColor = Color.FromArgb(52, 152, 219);
                else if (button == btnLogout)
                    button.BackColor = Color.FromArgb(231, 76, 60);

                button.Cursor = Cursors.Default;
            }
        }
    }
}