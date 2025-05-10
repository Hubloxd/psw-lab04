using lab04.Data.Contexts;
using lab04.Data.Models;

namespace lab04.Services
{
    internal class EventService(DatabaseContext dbContext)
    {
        private readonly DatabaseContext _dbContext = dbContext;

        /// <summary>
        /// Pobiera wszystkie wydarzenia. Zwraca pustą tablice, jeśli nie ma żadnego wydarzenia.
        /// </summary>
        public Task<Event[]> GetAllEvents()
        {
            var events = _dbContext.Events.ToArray();
            return Task.FromResult(events);
        }

        /// <summary>
        /// Pobiera wydarzenie na podstawie ID. Zwraca null, jeśli wydarzenie nie zostało znalezione.
        /// </summary>
        /// <param name="id"></param>
        public Task<Event?> GetEventById(int id)
        {
            var eventItem = _dbContext.Events.Find(id);
            return Task.FromResult(eventItem);
        }

        /// <summary>
        /// Dodaje nowe wydarzenie do bazy danych. Zwraca true, jeśli wydarzenie zostało dodane pomyślnie.
        /// </summary>
        /// <param name="eventItem"></param>
        /// <param name="createdEvent"></param>
        public Task<bool> AddEvent(Event eventItem, out Event createdEvent)
        {
            ArgumentNullException.ThrowIfNull(eventItem);
            var dbEntry = _dbContext.Events.Add(eventItem);

            createdEvent = dbEntry.Entity;
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        public Task<bool> UpdateEvent(Event eventItem)
        {
            ArgumentNullException.ThrowIfNull(eventItem);
            _dbContext.Events.Update(eventItem);
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }
    }
}
