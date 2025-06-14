using lab04.Services;
using lab04.Data.Models;
using Microsoft.Extensions.DependencyInjection;

namespace lab04.Forms.User
{
    public partial class UserRegisterForEventForm : Form
    {
        private readonly EventService eventService;
        private readonly RegistrationService registrationService;
        private readonly Data.Models.User currentUser;
        private Event? selectedEvent;

        public UserRegisterForEventForm(Data.Models.User user, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.currentUser = user;
            this.eventService = serviceProvider.GetRequiredService<EventService>();
            this.registrationService = serviceProvider.GetRequiredService<RegistrationService>();
        }

        private async void UserRegisterForEventForm_Load(object sender, EventArgs e)
        {
            try
            {
                var events = await eventService.GetAllEvents();
                cmbEvents.DataSource = events;
                cmbEvents.DisplayMember = "Name";
                cmbEvents.ValueMember = "Id";
                cmbEvents.SelectedIndex = -1;

                // Initialize participation type combo box
                var participationTypes = new Dictionary<string, string>
                {
                    { "Słuchacz", "Słuchacz" },
                    { "Autor", "Autor" },
                    { "Sponsor", "Sponsor" },
                    { "Organizator", "Organizator" }
                };
                cmbParticipationType.DataSource = new BindingSource(participationTypes, null);
                cmbParticipationType.DisplayMember = "Key";
                cmbParticipationType.ValueMember = "Value";
                cmbParticipationType.SelectedIndex = 0;

                // Initialize food preferences combo box
                var foodTypes = new Dictionary<string, string>
                {
                    { "Bez preferencji", "Bez preferencji" },
                    { "Wegetariańskie", "Wegetariańskie" },
                    { "Bez glutenu", "Bez glutenu" }
                };
                cmbFoodPreferences.DataSource = new BindingSource(foodTypes, null);
                cmbFoodPreferences.DisplayMember = "Key";
                cmbFoodPreferences.ValueMember = "Value";
                cmbFoodPreferences.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas ładowania wydarzeń: {ex.Message}");
            }
        }

        private void cmbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEvents.SelectedItem is Event selectedEvent)
            {
                this.selectedEvent = selectedEvent;
                txtAgenda.Text = selectedEvent.Agenda;
                lblEventDate.Text = $"Termin: {selectedEvent.Date:dd.MM.yyyy HH:mm}";
            }
            else
            {
                this.selectedEvent = null;
                txtAgenda.Text = string.Empty;
                lblEventDate.Text = "Termin:";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (selectedEvent == null)
            {
                ShowWarning("Wybierz wydarzenie, na które chcesz się zarejestrować.");
                return;
            }

            try
            {
                var registration = new Registration
                {
                    User = currentUser,
                    Event = selectedEvent,
                    AttendType = ((KeyValuePair<string, string>)cmbParticipationType.SelectedItem!).Value,
                    FoodType = ((KeyValuePair<string, string>)cmbFoodPreferences.SelectedItem!).Value,
                    AcceptState = "Oczekuje" // Oczekuje na zatwierdzenie
                };

                // Update the method call to explicitly specify the out parameter type to resolve ambiguity
                registrationService.AddRegistration(registration, out Registration _);
                ShowInfo("Zgłoszenie zostało wysłane pomyślnie. Oczekuje na zatwierdzenie przez administratora.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas rejestracji: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarning(string message)
        {
            MessageBox.Show(message, "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
} 