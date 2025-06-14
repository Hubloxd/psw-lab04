using lab04.Services;
using lab04.Data.Models;

namespace lab04.Forms.Admin
{
    public partial class AdminAddEventForm : Form
    {
        private readonly EventService eventService;
        public Event? NewEvent { get; private set; }

        internal AdminAddEventForm(EventService eventService)
        {
            InitializeComponent();
            this.eventService = eventService;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    var newEvent = new Event
                    {
                        Name = txtName.Text,
                        Agenda = txtDescription.Text,
                        Date = dateTimePicker.Value,
                    };

                    eventService.AddEvent(newEvent, out var createdEvent);
                    NewEvent = createdEvent;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania wydarzenia: {ex.Message}", "Błąd",
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