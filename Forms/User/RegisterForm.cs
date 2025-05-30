using lab04.Services;

namespace lab04;

public partial class RegisterForm : Form
{
    private readonly UserService _userService;
    public RegisterForm(UserService userService)
    {
        _userService = userService;
        InitializeComponent();
    }
}