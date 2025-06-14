using lab04.Services;

namespace lab04.Forms.Admin
{
    public partial class AdminAddUserForm : Form
    {
        private readonly UserService _userService;

        public AdminAddUserForm(UserService userService)
        {
            InitializeComponent();
            this._userService = userService;
        }
    }
}
