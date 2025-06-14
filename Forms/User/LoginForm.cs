using lab04.Forms.User;
using lab04.Services;
using Microsoft.Extensions.DependencyInjection;
using lab04.Data.Models;

namespace lab04
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        private int failedAttempts = 0;
        private bool isBlocked = false;

        public LoginForm(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private void UpdateLoginButtonState()
        {
            if (isBlocked)
            {
                btnLogin.Enabled = false;
                btnLogin.Text = $"Logowanie Zablokowane";
            }
            else
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Zaloguj";
            }
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            if (isBlocked)
            {
                MessageBox.Show("Logowanie Zablokowane", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var user = await _userService.LoginUser(login, password);

                if (user == null)
                {
                    failedAttempts++;
                    if (failedAttempts >= 3)
                    {
                        isBlocked = true;
                        UpdateLoginButtonState();
                        MessageBox.Show("Zbyt wiele nieudanych prób logowania. Logowanie Zostało Zablokowane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Nieprawidłowy login lub hasło. Pozostało prób: {3 - failedAttempts}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }

                // Przejdź do odpowiedniego panelu w zależności od uprawnień
                if (user.Permissions == 0)
                {
                    this.Hide();
                    var serviceProvider = Program.ServiceProvider;
                    var adminDashboard = new AdminDashboardForm(user, serviceProvider);
                    adminDashboard.FormClosed += (s, args) => this.Close(); // Zamknij aplikację po zamknięciu panelu administratora
                    adminDashboard.ShowDialog();
                    this.Show();
                }
                else if (user.Permissions == 1)
                {
                    var serviceProvider = Program.ServiceProvider;
                    var userDashboard = new UserDashboardForm(user, serviceProvider);
                    userDashboard.FormClosed += (s, args) => this.Close(); // Zamknij aplikację po zamknięciu panelu użytkownika
                    this.Hide();
                    userDashboard.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Nieprawidłowe uprawnienia konta.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void LnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var serviceProvider = Program.ServiceProvider;
            var registerForm = serviceProvider.GetRequiredService<RegisterForm>();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }
    }
}
