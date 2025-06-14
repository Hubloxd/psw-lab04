using lab04.Services;
using lab04.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace lab04.Forms.Admin
{
    public partial class AdminManageEventsForm : Form
    {
        private List<Event> events;
        private Event? selectedEvent;
        private readonly EventService eventService;

        public AdminManageEventsForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            events = [];
            eventService = serviceProvider.GetRequiredService<EventService>();
        }

        private void AdminManageEventsForm_Load(object sender, EventArgs e)
        {
            LoadEvents();
            UpdateButtonStates();
        }

        #region Event Handlers

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            try
            {
                using var addEventForm = new AdminAddEventForm(eventService);
                if (addEventForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEvents();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas dodawania wydarzenia: {ex.Message}");
            }
        }

        private void btnEditEvent_Click(object sender, EventArgs e)
        {
            if (selectedEvent == null)
            {
                ShowWarning("Wybierz wydarzenie do edycji.");
                return;
            }

            try
            {
                OpenEditEventForm(selectedEvent);
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas edycji wydarzenia: {ex.Message}");
            }
        }

        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (selectedEvent == null)
            {
                ShowWarning("Wybierz wydarzenie do usunięcia.");
                return;
            }

            var result = MessageBox.Show(
                $"Czy na pewno chcesz usunąć wydarzenie '{selectedEvent.Name}'?\n\nTa operacja jest nieodwracalna.",
                "Potwierdzenie usunięcia",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                try
                {
                    String eventName = selectedEvent.Name;
                    eventService.DeleteEvent(selectedEvent.Id);
                    LoadEvents();
                    UpdateStatusLabel($"Usunięto wydarzenie: {eventName}");
                    selectedEvent = null;
                    UpdateButtonStates();
                }
                catch (Exception ex)
                {
                    ShowError($"Błąd podczas usuwania wydarzenia: {ex.Message}");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEvents();
            UpdateStatusLabel("Lista wydarzeń została odświeżona.");
        }

        private void dataGridViewEvents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewEvents.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewEvents.SelectedRows[0];
                selectedEvent = selectedRow.DataBoundItem as Event;
            }
            else
            {
                selectedEvent = null;
            }
            UpdateButtonStates();
        }

        private void dataGridViewEvents_DoubleClick(object sender, EventArgs e)
        {
            if (selectedEvent != null)
            {
                OpenEditEventForm(selectedEvent);
            }
        }

        #endregion

        #region Private Methods

        private void LoadEvents()
        {
            try
            {
                events = eventService.GetAllEvents().Result.ToList();
                dataGridViewEvents.DataSource = events;
                UpdateStatusLabel($"Załadowano {events.Count} wydarzeń.");
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas ładowania wydarzeń: {ex.Message}");
            }
        }

        private void UpdateButtonStates()
        {
            bool eventSelected = selectedEvent != null;
            btnDeleteEvent.Enabled = eventSelected;
            btnEditEvent.Enabled = eventSelected;
        }

        private void UpdateStatusLabel(string message)
        {
            toolStripStatusLabel.Text = $"{DateTime.Now:HH:mm:ss} - {message}";
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

        private void OpenEditEventForm(Event eventItem)
        {
            try
            {
                using var editForm = new AdminEditEventForm(eventItem, eventService);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEvents();
                    UpdateStatusLabel($"Zaktualizowano dane wydarzenia: {eventItem.Name}");
                }
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas edycji wydarzenia: {ex.Message}");
            }
        }

        #endregion


    }
} 