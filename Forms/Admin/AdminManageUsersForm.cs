using lab04.Services;
using lab04.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace lab04.Forms.Admin
{
    public partial class AdminManageUsersForm : Form
    {
        // Przykładowa lista użytkowników - zastąp odpowiednią logiką dostępu do danych
        private List<Data.Models.User> users;
        private Data.Models.User? selectedUser;
        private readonly UserService userService;

        public AdminManageUsersForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            users = [];
            userService = serviceProvider.GetRequiredService<UserService>();
        }

        private void AdminManageUsersForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            UpdateButtonStates();
        }

        #region Event Handlers

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                // Otwórz formularz dodawania użytkownika
                using var addUserForm = new AdminAddUserForm(userService);
                if (addUserForm.ShowDialog() == DialogResult.OK)
                {
                    // Odśwież listę użytkowników po dodaniu
                    LoadUsers();
                    //UpdateStatusLabel($"Dodano nowego użytkownika: {addUserForm.NewUser.Username}");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas dodawania użytkownika: {ex.Message}");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (selectedUser == null)
            {
                ShowWarning("Wybierz użytkownika do usunięcia.");
                return;
            }

            var result = MessageBox.Show(
                $"Czy na pewno chcesz usunąć użytkownika '{selectedUser.Login}'?\n\nTa operacja jest nieodwracalna.",
                "Potwierdzenie usunięcia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DeleteUser(selectedUser);
                    LoadUsers();
                    UpdateStatusLabel($"Usunięto użytkownika: {selectedUser.Login}");
                    selectedUser = null;
                    UpdateButtonStates();
                }
                catch (Exception ex)
                {
                    ShowError($"Błąd podczas usuwania użytkownika: {ex.Message}");
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (selectedUser == null)
            {
                ShowWarning("Wybierz użytkownika do zresetowania hasła.");
                return;
            }

            var result = MessageBox.Show(
                $"Czy na pewno chcesz zresetować hasło użytkownika '{selectedUser.Login}'?\n\nNowe hasło zostanie wysłane na adres email użytkownika.",
                "Potwierdzenie resetowania hasła",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string newPassword = ResetUserPassword(selectedUser);
                    ShowInfo($"Hasło zostało zresetowane.\nNowe tymczasowe hasło: {newPassword}\n\nHasło zostało również wysłane na email użytkownika.");
                    UpdateStatusLabel($"Zresetowano hasło dla: {selectedUser.Login}");
                }
                catch (Exception ex)
                {
                    ShowError($"Błąd podczas resetowania hasła: {ex.Message}");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            UpdateStatusLabel("Lista użytkowników została odświeżona.");
        }

        private void dataGridViewUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewUsers.SelectedRows[0];
                selectedUser = selectedRow.DataBoundItem as Data.Models.User;
            }
            else
            {
                selectedUser = null;
            }
            UpdateButtonStates();
        }

        private void dataGridViewUsers_DoubleClick(object sender, EventArgs e)
        {
            if (selectedUser != null)
            {
                // Otwórz formularz edycji użytkownika
                OpenEditUserForm(selectedUser);
            }
        }

        #endregion

        #region Private Methods

        private void LoadUsers()
        {
            try
            {
                users = GetUsersFromDatabase();

                dataGridViewUsers.DataSource = users;
                UpdateStatusLabel($"Załadowano {users.Count} użytkowników.");
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas ładowania użytkowników: {ex.Message}");
            }
        }

        private void UpdateButtonStates()
        {
            bool userSelected = selectedUser != null;

            btnResetPassword.Enabled = userSelected;
            btnDeleteUser.Enabled = userSelected;
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

        private void OpenEditUserForm(Data.Models.User user)
        {
            try
            {
                using var editForm = new AdminEditUserForm(user, userService);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                    UpdateStatusLabel($"Zaktualizowano dane użytkownika: {user.Login}");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas edycji użytkownika: {ex.Message}");
            }
        }

        #endregion

        #region Database Methods (do zaimplementowania)

        private List<Data.Models.User> GetUsersFromDatabase()
        {
            var users = userService.GetAllUsers().Result.ToList();
            if (users == null || !users.Any())
            {
                ShowWarning("Brak użytkowników w bazie danych.");
                return new List<Data.Models.User>();
            }
            return users;
        }

        private void DeleteUser(Data.Models.User user) =>
            this.userService.DeleteUserById(user.Id);

        private string ResetUserPassword(Data.Models.User user)
        {
            // Implementuj logikę resetowania hasła
            // 1. Wygeneruj nowe tymczasowe hasło
            // 2. Zaktualizuj hasło w bazie danych
            // 3. Wyślij email z nowym hasłem
            string newPassword = GenerateTemporaryPassword();

            // Tutaj kod aktualizacji bazy danych i wysyłania emaila

            return newPassword;
        }

        private string GenerateTemporaryPassword()
        {
            // Prosta implementacja generowania hasła
            const string chars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        #endregion
    }
}