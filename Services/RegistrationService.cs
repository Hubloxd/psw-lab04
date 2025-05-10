using lab04.Data.Contexts;
using lab04.Data.Models;

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
            registration.AcceptState = (ushort)(accepted ? 1 : 2); // 1 - zaakceptowane 2 - odrzucone

            _dbContext.Registrations.Update(registration);
            _dbContext.SaveChanges();
        }
    }
}
