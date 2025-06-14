using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lab04.Forms.Admin
{
    public partial class AdminAddUserForm : Form
    {
        public Data.Models.User NewUser { get; private set; }

        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Button btnSave;
        private Button btnCancel;
        private Panel panelButtons;

        private void InitializeComponent()
        {
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            panelButtons = new Panel();
            textBoxName = new TextBox();
            labelName = new Label();
            textBoxLastName = new TextBox();
            labelLastName = new Label();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.Location = new Point(20, 20);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(121, 15);
            lblUsername.TabIndex = 10;
            lblUsername.Text = "Nazwa użytkownika:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.Location = new Point(20, 40);
            txtUsername.MaxLength = 50;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(350, 23);
            txtUsername.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(20, 169);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(20, 189);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(350, 23);
            txtEmail.TabIndex = 7;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.Location = new Point(20, 220);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(41, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Hasło:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(20, 240);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(350, 23);
            txtPassword.TabIndex = 5;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConfirmPassword.Location = new Point(20, 272);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(99, 15);
            lblConfirmPassword.TabIndex = 4;
            lblConfirmPassword.Text = "Potwierdź hasło:";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 9F);
            txtConfirmPassword.Location = new Point(20, 292);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(350, 23);
            txtConfirmPassword.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(210, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(80, 30);
            btnSave.TabIndex = 1;
            btnSave.Text = "Zapisz";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(158, 158, 158);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(300, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 30);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(240, 240, 240);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Controls.Add(btnSave);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(0, 331);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(400, 50);
            panelButtons.TabIndex = 11;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Segoe UI", 9F);
            textBoxName.Location = new Point(20, 95);
            textBoxName.MaxLength = 50;
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(350, 23);
            textBoxName.TabIndex = 12;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelName.Location = new Point(20, 77);
            labelName.Name = "labelName";
            labelName.Size = new Size(32, 15);
            labelName.TabIndex = 13;
            labelName.Text = "Imię";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Font = new Font("Segoe UI", 9F);
            textBoxLastName.Location = new Point(20, 143);
            textBoxLastName.MaxLength = 50;
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(350, 23);
            textBoxLastName.TabIndex = 14;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLastName.Location = new Point(20, 125);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(60, 15);
            labelLastName.TabIndex = 15;
            labelLastName.Text = "Nazwisko";
            // 
            // AdminAddUserForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(400, 381);
            Controls.Add(textBoxLastName);
            Controls.Add(labelLastName);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(panelButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminAddUserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Dodaj nowego użytkownika";
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    NewUser = new Data.Models.User
                    {
                        Login = txtUsername.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Password = txtPassword.Text.Trim(), 
                        FirstName = textBoxName.Text.Trim(),
                        LastName = textBoxLastName.Text.Trim(),
                    };

                    this._userService.AddUser(NewUser, out _);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas zapisywania użytkownika: {ex.Message}",
                        "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            // Walidacja nazwy użytkownika
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                ShowValidationError("Nazwa użytkownika jest wymagana.", txtUsername);
                return false;
            }

            if (txtUsername.Text.Length < 3)
            {
                ShowValidationError("Nazwa użytkownika musi mieć co najmniej 3 znaki.", txtUsername);
                return false;
            }

            if (!Regex.IsMatch(txtUsername.Text, @"^[a-zA-Z0-9_]+$"))
            {
                ShowValidationError("Nazwa użytkownika może zawierać tylko litery, cyfry i podkreślenia.", txtUsername);
                return false;
            }

            // Walidacja emaila
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ShowValidationError("Email jest wymagany.", txtEmail);
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                ShowValidationError("Podaj prawidłowy adres email.", txtEmail);
                return false;
            }

            // Walidacja hasła
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                ShowValidationError("Hasło jest wymagane.", txtPassword);
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                ShowValidationError("Hasło musi mieć co najmniej 6 znaków.", txtPassword);
                return false;
            }

            // Walidacja potwierdzenia hasła
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                ShowValidationError("Hasła nie są identyczne.", txtConfirmPassword);
                return false;
            }

            // Sprawdzenie czy użytkownik już istnieje (tutaj przykładowa implementacja)
            if (UserExists(txtUsername.Text))
            {
                ShowValidationError("Użytkownik o tej nazwie już istnieje.", txtUsername);
                return false;
            }

            return true;
        }

        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private bool UserExists(string username)
        {
            // Tutaj powinna być logika sprawdzenia w bazie danych
            // Na potrzeby przykładu zwracam false
            return false;
        }
        private TextBox textBoxName;
        private Label labelName;
        private TextBox textBoxLastName;
        private Label labelLastName;
    }
}