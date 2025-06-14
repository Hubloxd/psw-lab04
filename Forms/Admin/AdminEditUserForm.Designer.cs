using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using lab04.Data.Models;

namespace lab04.Forms.Admin
{
    public partial class AdminEditUserForm : Form
    {
        public Data.Models.User UpdatedUser { get; private set; }

        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblRole;
        private ComboBox cmbRole;
        private GroupBox grpPasswordReset;
        private CheckBox chkResetPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmNewPassword;
        private TextBox txtConfirmNewPassword;
        private Button btnSave;
        private Button btnCancel;
        private Panel panelButtons;
        private TextBox textBoxFirstName;


        private void InitializeComponent()
        {
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblRole = new Label();
            cmbRole = new ComboBox();
            grpPasswordReset = new GroupBox();
            txtConfirmNewPassword = new TextBox();
            lblConfirmNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblNewPassword = new Label();
            chkResetPassword = new CheckBox();
            btnSave = new Button();
            btnCancel = new Button();
            panelButtons = new Panel();
            textBoxFirstName = new TextBox();
            labelFirstName = new Label();
            textBoxLastName = new TextBox();
            labelLastName = new Label();
            grpPasswordReset.SuspendLayout();
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
            lblUsername.TabIndex = 11;
            lblUsername.Text = "Nazwa użytkownika:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.Location = new Point(20, 40);
            txtUsername.MaxLength = 50;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(400, 23);
            txtUsername.TabIndex = 10;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.Location = new Point(20, 75);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(20, 95);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(400, 23);
            txtEmail.TabIndex = 8;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRole.Location = new Point(20, 213);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(34, 15);
            lblRole.TabIndex = 7;
            lblRole.Text = "Rola:";
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 9F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "0", "1" });
            cmbRole.Location = new Point(20, 233);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(200, 23);
            cmbRole.TabIndex = 6;
            // 
            // grpPasswordReset
            // 
            grpPasswordReset.Controls.Add(txtConfirmNewPassword);
            grpPasswordReset.Controls.Add(lblConfirmNewPassword);
            grpPasswordReset.Controls.Add(txtNewPassword);
            grpPasswordReset.Controls.Add(lblNewPassword);
            grpPasswordReset.Controls.Add(chkResetPassword);
            grpPasswordReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpPasswordReset.Location = new Point(20, 262);
            grpPasswordReset.Name = "grpPasswordReset";
            grpPasswordReset.Size = new Size(400, 164);
            grpPasswordReset.TabIndex = 0;
            grpPasswordReset.TabStop = false;
            grpPasswordReset.Text = "Reset hasła";
            // 
            // txtConfirmNewPassword
            // 
            txtConfirmNewPassword.Enabled = false;
            txtConfirmNewPassword.Font = new Font("Segoe UI", 9F);
            txtConfirmNewPassword.Location = new Point(15, 125);
            txtConfirmNewPassword.Name = "txtConfirmNewPassword";
            txtConfirmNewPassword.PasswordChar = '*';
            txtConfirmNewPassword.Size = new Size(370, 23);
            txtConfirmNewPassword.TabIndex = 0;
            // 
            // lblConfirmNewPassword
            // 
            lblConfirmNewPassword.AutoSize = true;
            lblConfirmNewPassword.Enabled = false;
            lblConfirmNewPassword.Font = new Font("Segoe UI", 9F);
            lblConfirmNewPassword.Location = new Point(15, 105);
            lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            lblConfirmNewPassword.Size = new Size(93, 15);
            lblConfirmNewPassword.TabIndex = 1;
            lblConfirmNewPassword.Text = "Potwierdź hasło:";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Enabled = false;
            txtNewPassword.Font = new Font("Segoe UI", 9F);
            txtNewPassword.Location = new Point(15, 75);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(370, 23);
            txtNewPassword.TabIndex = 2;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Enabled = false;
            lblNewPassword.Font = new Font("Segoe UI", 9F);
            lblNewPassword.Location = new Point(15, 55);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(72, 15);
            lblNewPassword.TabIndex = 3;
            lblNewPassword.Text = "Nowe hasło:";
            // 
            // chkResetPassword
            // 
            chkResetPassword.AutoSize = true;
            chkResetPassword.Font = new Font("Segoe UI", 9F);
            chkResetPassword.Location = new Point(15, 25);
            chkResetPassword.Name = "chkResetPassword";
            chkResetPassword.Size = new Size(164, 19);
            chkResetPassword.TabIndex = 4;
            chkResetPassword.Text = "Resetuj hasło użytkownika";
            chkResetPassword.UseVisualStyleBackColor = true;
            chkResetPassword.CheckedChanged += chkResetPassword_CheckedChanged;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(270, 10);
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
            btnCancel.Location = new Point(360, 10);
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
            panelButtons.Location = new Point(0, 436);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(450, 50);
            panelButtons.TabIndex = 12;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Font = new Font("Segoe UI", 9F);
            textBoxFirstName.Location = new Point(20, 141);
            textBoxFirstName.MaxLength = 100;
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(400, 23);
            textBoxFirstName.TabIndex = 13;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelFirstName.Location = new Point(20, 121);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(35, 15);
            labelFirstName.TabIndex = 14;
            labelFirstName.Text = "Imię:";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Font = new Font("Segoe UI", 9F);
            textBoxLastName.Location = new Point(20, 187);
            textBoxLastName.MaxLength = 100;
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(400, 23);
            textBoxLastName.TabIndex = 15;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLastName.Location = new Point(20, 167);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(60, 15);
            labelLastName.TabIndex = 16;
            labelLastName.Text = "Nazwisko";
            // 
            // AdminEditUserForm
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            CancelButton = btnCancel;
            ClientSize = new Size(450, 486);
            Controls.Add(textBoxLastName);
            Controls.Add(labelLastName);
            Controls.Add(textBoxFirstName);
            Controls.Add(labelFirstName);
            Controls.Add(grpPasswordReset);
            Controls.Add(cmbRole);
            Controls.Add(lblRole);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(panelButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdminEditUserForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edytuj użytkownika";
            grpPasswordReset.ResumeLayout(false);
            grpPasswordReset.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private void LoadUserData()
        {
            txtUsername.Text = user.Login;
            txtEmail.Text = user.Email;
            cmbRole.SelectedItem = user.Permissions;
            textBoxFirstName.Text = user.FirstName;
            textBoxLastName.Text = user.LastName;
        }

        private void chkResetPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = chkResetPassword.Checked;
            lblNewPassword.Enabled = enabled;
            txtNewPassword.Enabled = enabled;
            lblConfirmNewPassword.Enabled = enabled;
            txtConfirmNewPassword.Enabled = enabled;

            if (!enabled)
            {
                txtNewPassword.Clear();
                txtConfirmNewPassword.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    UpdatedUser = new Data.Models.User
                    {
                        Id = user.Id,
                        Login = txtUsername.Text.Trim(),
                        FirstName = textBoxFirstName.Text.Trim(),
                        LastName = textBoxLastName.Text.Trim(),
                        Password = chkResetPassword.Checked ? txtNewPassword.Text.Trim() : user.Password,
                        Email = txtEmail.Text.Trim(),
                        Permissions = ushort.Parse(cmbRole.SelectedItem.ToString()),
                    };

                    this._userService.UpdateUser(UpdatedUser);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas aktualizacji użytkownika: {ex.Message}",
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

            // Walidacja hasła (jeśli jest resetowane)
            if (chkResetPassword.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
                {
                    ShowValidationError("Nowe hasło jest wymagane.", txtNewPassword);
                    return false;
                }

                if (txtNewPassword.Text.Length < 6)
                {
                    ShowValidationError("Nowe hasło musi mieć co najmniej 6 znaków.", txtNewPassword);
                    return false;
                }

                if (txtNewPassword.Text != txtConfirmNewPassword.Text)
                {
                    ShowValidationError("Hasła nie są identyczne.", txtConfirmNewPassword);
                    return false;
                }
            }

            return true;
        }

        private void ShowValidationError(string message, Control control)
        {
            MessageBox.Show(message, "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            control.Focus();
        }

        private Label labelFirstName; private TextBox textBoxLastName;
        private Label labelLastName;
    }
}