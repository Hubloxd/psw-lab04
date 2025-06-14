using lab04.Data.Contexts;
using lab04.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace lab04.Services
{
    internal class RegistrationService(DatabaseContext dbContext)
    {
        private readonly DatabaseContext _dbContext = dbContext;

        /// <summary>
        /// Pobiera wszystkie rejestracje. Zwraca pustą tablicę, jeśli nie ma żadnej rejestracji.
        /// </summary>
        public Task<Registration[]> GetAllRegistrations()
        {
            var registrations = _dbContext.Registrations.ToArray();
            return Task.FromResult(registrations);
        }

        /// <summary>
        /// Tworzy nowy zapis na wydarzenie. Zwraca true, jeśli zapis został dodany pomyślnie.
        /// </summary>
        /// <param name="registration"></param>
        /// <param name="createdRegistration"></param>
        public Task<bool> AddRegistration(Registration registration, out Registration createdRegistration)
        {
            ArgumentNullException.ThrowIfNull(registration);
            var dbEntry = _dbContext.Registrations.Add(registration);

            createdRegistration = dbEntry.Entity;
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        public void ChangeRegistrationAcceptance(int id, bool accepted = true)
        {
            var registration = _dbContext.Registrations.Find(id);
            ArgumentNullException.ThrowIfNull(registration);
            registration.AcceptState = (accepted ? "Zatwierdzono" : "Odrzucono");

            _dbContext.Registrations.Update(registration);
            _dbContext.SaveChanges();
        }

        internal int GetRegistrationsCount()
        {
            return _dbContext.Registrations.Count();
        }

        internal Registration[] GetRegistrationsForEvent(int id)
        {
            return _dbContext.Registrations
                .Where(r => r.Event.Id == id)
                .Include(r => r.User)
                .ToArray();
        }

        internal void ApproveRegistration(int id)
        {
            ChangeRegistrationAcceptance(id, true);
        }

        internal Task<Registration[]> GetAllUsersRegistrations(int userId)
        {
            var registrations = _dbContext.Registrations
                .Where(r => r.User.Id == userId)
                .Include(r => r.Event)
                .ToArray();
            return Task.FromResult(registrations);
        }

        public void AddRegistration(Registration registration, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (registration == null)
                {
                    errorMessage = "Rejestracja nie może być pusta.";
                    return;
                }

                if (registration.User == null || registration.Event == null)
                {
                    errorMessage = "Użytkownik i wydarzenie są wymagane.";
                    return;
                }

                // Sprawdź czy użytkownik już jest zarejestrowany na to wydarzenie
                var existingRegistration = _dbContext.Registrations
                    .FirstOrDefault(r => r.User.Id == registration.User.Id && r.Event.Id == registration.Event.Id);

                if (existingRegistration != null)
                {
                    errorMessage = "Użytkownik jest już zarejestrowany na to wydarzenie.";
                    return;
                }

                registration.AcceptState = "Oczekuje";
                _dbContext.Registrations.Add(registration);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = $"Błąd podczas dodawania rejestracji: {ex.Message}";
            }
        }

        public void ApproveRegistration(int registrationId, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var registration = _dbContext.Registrations.Find(registrationId);
                if (registration == null)
                {
                    errorMessage = "Nie znaleziono rejestracji.";
                    return;
                }

                registration.AcceptState = "Zatwierdzono";
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = $"Błąd podczas zatwierdzania rejestracji: {ex.Message}";
            }
        }

        public void RejectRegistration(int registrationId, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                var registration = _dbContext.Registrations.Find(registrationId);
                if (registration == null)
                {
                    errorMessage = "Nie znaleziono rejestracji.";
                    return;
                }

                registration.AcceptState = "Odrzucono";
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                errorMessage = $"Błąd podczas odrzucania rejestracji: {ex.Message}";
            }
        }
    }
}
