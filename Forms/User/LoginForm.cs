using lab04.Services;
using Microsoft.Extensions.DependencyInjection;

namespace lab04
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        public LoginForm(UserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show("Nieprawidłowe dane logowania.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Przejdź do odpowiedniego panelu w zależności od uprawnień
                if (user.Permissions == 0)
                {
                    this.Hide();
                    var serviceProvider = Program.ServiceProvider;
                    var adminDashboard = new AdminDashboardForm(user, serviceProvider);
                    adminDashboard.ShowDialog();
                    this.Show();
                }
                else if (user.Permissions == 1)
                {
                    var serviceProvider = Program.ServiceProvider;
                    throw new NotImplementedException("Panel użytkownika nie został jeszcze zaimplementowany.");
                    var userDashboard = new UserDashboardForm(user, serviceProvider);
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
