using lab04.Services;
using lab04.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace lab04.Forms.Admin
{
    public partial class AdminManageRegistrationsForm : Form
    {
        private Registration? selectedRegistration;
        private readonly RegistrationService registrationService;
        private readonly EventService eventService;

        public AdminManageRegistrationsForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            registrationService = serviceProvider.GetRequiredService<RegistrationService>();
            eventService = serviceProvider.GetRequiredService<EventService>();
        }

        private void AdminManageRegistrationsForm_Load(object sender, EventArgs e)
        {
            LoadEvents();
            LoadRegistrations();
            UpdateButtonStates();
        }

        #region Event Handlers

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (selectedRegistration == null)
            {
                ShowWarning("Wybierz zgłoszenie do zatwierdzenia.");
                return;
            }

            try
            {
                registrationService.ApproveRegistration(selectedRegistration.Id, out _);
                ShowInfo("Zgłoszenie zostało zatwierdzone.");
                LoadRegistrations();
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas zatwierdzania zgłoszenia: {ex.Message}");
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (selectedRegistration == null)
            {
                ShowWarning("Wybierz zgłoszenie do odrzucenia.");
                return;
            }

            try
            {
                registrationService.RejectRegistration(selectedRegistration.Id, out _);
                ShowInfo("Zgłoszenie zostało odrzucone.");
                LoadRegistrations();
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas odrzucania zgłoszenia: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRegistrations();
            UpdateStatusLabel("Lista rejestracji została odświeżona.");
        }

        private void cmbEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRegistrations();
        }

        private void dataGridViewRegistrations_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRegistrations.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewRegistrations.SelectedRows[0];
                selectedRegistration = selectedRow.DataBoundItem as Registration;
            }
            else
            {
                selectedRegistration = null;
            }
            UpdateButtonStates();
        }

        #endregion

        #region Private Methods

        private async void LoadEvents()
        {
            try
            {
                var events = await eventService.GetAllEvents();
                cmbEvents.DataSource = events;
                cmbEvents.DisplayMember = "Name";
                cmbEvents.ValueMember = "Id";
                cmbEvents.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas ładowania wydarzeń: {ex.Message}");
            }
        }

        private void LoadRegistrations()
        {
            try
            {
                if (cmbEvents.SelectedValue == null)
                {
                    dataGridViewRegistrations.DataSource = null;
                    return;
                }

                if (cmbEvents.SelectedValue is not int eventId)
                {
                    return;
                }

                var registrations = registrationService.GetRegistrationsForEvent(eventId).ToList();
                dataGridViewRegistrations.DataSource = registrations;
                UpdateStatusLabel($"Załadowano {registrations.Count} rejestracji.");
            }
            catch (Exception ex)
            {
                ShowError($"Błąd podczas ładowania rejestracji: {ex.Message}");
            }
        }

        private void UpdateButtonStates()
        {
            bool registrationSelected = selectedRegistration != null;
            bool isPending = registrationSelected && selectedRegistration.AcceptState == "Oczekuje";
            btnApprove.Enabled = isPending;
            btnReject.Enabled = isPending;
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

        #endregion
    }
} 