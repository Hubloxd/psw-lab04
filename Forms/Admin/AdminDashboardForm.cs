using lab04.Data.Models;
using lab04.Forms.Admin;
using lab04.Services;
using Microsoft.Extensions.DependencyInjection;

namespace lab04;

public partial class AdminDashboardForm : Form
{
    public AdminDashboardForm()
    {
        throw new ArgumentNullException(Name);
    }

    public AdminDashboardForm(User user, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        this._user = user;
        this._serviceProvider = serviceProvider;
        this.label1.Text += user.FirstName;
    }

    private readonly IServiceProvider _serviceProvider;
    private readonly User _user;

    private void button1_Click(object sender, EventArgs e)
    {
        this.Hide();
        var form = this._serviceProvider.GetService<AdminManageUsersForm>();
        form!.ShowDialog();
        this.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {

    }
}