using lab04.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab04.Forms.Admin
{
    public partial class AdminAddUserForm : Form
    {
        private readonly UserService _userService;

        public AdminAddUserForm()
        {
            throw new ArgumentNullException("ServiceProvider was not provided");
        }

        public AdminAddUserForm(UserService userService)
        {
            InitializeComponent();
            this._userService = userService;
        }
    }
}
