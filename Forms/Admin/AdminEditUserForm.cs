using lab04.Data.Models;
using lab04.Services;

namespace lab04.Forms.Admin
{
    public partial class AdminEditUserForm : Form
    {
        private readonly Data.Models.User user;
        private readonly UserService _userService;

        public AdminEditUserForm(Data.Models.User user, UserService userService)
        {
            this.user = user;
            this._userService = userService;
            InitializeComponent();
            LoadUserData();
        }
    }
}
