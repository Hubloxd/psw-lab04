using lab04.Data.Models;
using lab04.Services;

namespace lab04.Forms.Admin
{
    public partial class AdminManageUsersForm : Form
    {
        private readonly UserService _userService;

        public AdminManageUsersForm()
        {
            throw new ArgumentNullException("ServiceProvider was not provided");
        }

        public AdminManageUsersForm(UserService userService)
        {
            this._userService = userService;

            InitializeComponent();
            InitLayout();
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            var users = _userService.GetAllUsers().Result;
            if (users == null)
                return;

            foreach (var user in users)
            {
                var flowPanel = new FlowLayoutPanel()
                {
                    AutoSize = true,
                };
                var label = new Label()
                {
                    Text = user.FirstName
                };
                var button = new Button()
                {
                    Text = "Usuń",
                };
                button.Click += (sender, e) => HandleDeleteUser(user);

                flowPanel.Controls.Add(label);
                flowPanel.Controls.Add(button);
                flowLayoutPanel1.Controls.Add(flowPanel);
            }
        }

        private void RefreshLayout()
        {
            this.flowLayoutPanel1.Controls.Clear();
            this.InitLayout();
        }

        private void HandleDeleteUser(User user)
        {
            var confirmationResult = MessageBox.Show(
                $"Czy na pewno chcesz usunąć użytkownika {user.FirstName} {user.LastName}?",
                "Potwierdzenie",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );
            if (confirmationResult != DialogResult.Yes)
                return;

            _userService.DeleteUserById(user.Id);
            this.RefreshLayout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new AdminAddUserForm(_userService);
            form.FormClosed += (s, args) => this.RefreshLayout();
            form.ShowDialog(this);
        }
    }
}
