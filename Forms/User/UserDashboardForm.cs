using lab04.Data.Models;

namespace lab04;

public partial class UserDashboardForm : Form
{
    public UserDashboardForm(User user, IServiceProvider serviceProvider)
    {
        InitializeComponent();
    }
}