using lab04.Services;
using lab04.Data.Models;

namespace lab04.Forms.Admin
{
    public partial class AdminEditEventForm : Form
    {
        private readonly EventService eventService;
        private readonly Event eventToEdit;

        internal AdminEditEventForm(Event eventToEdit, EventService eventService)
        {
            InitializeComponent();
            this.eventService = eventService;
            this.eventToEdit = eventToEdit;
            LoadEventData();
        }

        private void LoadEventData()
        {
            txtName.Text = eventToEdit.Name;
            txtDescription.Text = eventToEdit.Agenda;
            dateTimePicker.Value = eventToEdit.Date;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    eventToEdit.Name = txtName.Text;
                    eventToEdit.Agenda = txtDescription.Text;
                    eventToEdit.Date = dateTimePicker.Value;

                    eventService.UpdateEvent(eventToEdit);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas aktualizacji wydarzenia: {ex.Message}", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Nazwa wydarzenia jest wymagana.", "Błąd walidacji",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (dateTimePicker.Value < DateTime.Now)
            {
                MessageBox.Show("Data wydarzenia nie może być z przeszłości.", "Błąd walidacji",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
} 