using System.Security.Cryptography;
using System.Text;
using lab04.Data.Contexts;
using lab04.Data.Models;

namespace lab04.Services
{
    /// <summary>
    /// Usługa do zarządzania użytkownikami.
    /// </summary>
    /// <param name="dbContext"></param>
    public class UserService(DatabaseContext dbContext)
    {
        private readonly DatabaseContext _dbContext = dbContext;

        /// <summary>
        /// Pobiera użytkownika na podstawie loginu i hasła. Zwraca pustą tablicę, jeśli nie ma żadnego użytkownika.
        /// </summary>
        public Task<User[]> GetAllUsers()
        {
            var users = _dbContext.Users.ToArray();
            return Task.FromResult(users);
        }

        /// <summary>
        /// Pobiera użytkownika na podstawie ID. Zwraca null, jeśli użytkownik nie został znaleziony.
        /// </summary>
        /// <param name="id"></param>
        public Task<User?> GetUserById(int id)
        {
            var user = _dbContext.Users.Find(id);
            return Task.FromResult(user);
        }

        /// <summary>
        /// Dodaje nowego użytkownika do bazy danych. Zwraca true, jeśli użytkownik został dodany pomyślnie.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="createdUser"></param>
        public Task<bool> AddUser(User user, out User createdUser)
        {
            ArgumentNullException.ThrowIfNull(user);
            user.Password = HashPassword(user.Password); // Hashowanie hasła w ramach podstawowych standardów bezpieczeństwa

            var dbEntry = _dbContext.Users.Add(user);
            createdUser = dbEntry.Entity;

            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        /// <summary>
        /// Aktualizuje użytkownika w bazie danych. Zwraca true, jeśli użytkownik został zaktualizowany pomyślnie.
        /// </summary>
        /// <param name="id"></param>
        public Task<bool> DeleteUserById(int id)
        {
            var user = _dbContext.Users.Find(id);
            ArgumentNullException.ThrowIfNull(user);

            _dbContext.Users.Remove(user);
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        /// <summary>
        /// Aktualizuje użytkownika w bazie danych. Zwraca true, jeśli użytkownik został zaktualizowany pomyślnie.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPassword"></param>
        public Task<bool> ResetUserPassword(int id, string newPassword)
        {
            var user = _dbContext.Users.Find(id);
            ArgumentNullException.ThrowIfNull(user);
            
            user.Password = HashPassword(newPassword);
            return Task.FromResult(_dbContext.SaveChanges() > 0);
        }

        /// <summary>
        /// Loguje użytkownika na podstawie loginu i hasła. Zwraca true, jeśli użytkownik został zalogowany pomyślnie.
        /// Bardzo naiwne podejście do logowania. W rzeczywistej aplikacji użyjemy serwisu autoryzacji, na bieżąco weryfikującego czy użytkownik ma dostęp do zasobów,
        /// z ewentualną implementacją JWT.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public Task<User?> LoginUser(string login, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Login == login && u.Password == HashPassword(password));
            return Task.FromResult(user);
        }

        /// <summary>
        /// Hashuje hasło użytkownika. Używamy algorytmu SHA256 do haszowania hasła.
        /// </summary>
        /// <param name="password"></param>
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
        
        public bool UserExists(string login) =>
            _dbContext.Users.Any(u => u.Login == login);

        internal void UpdateUser(User updatedUser)
        {
            ArgumentNullException.ThrowIfNull(updatedUser);
            var existingUser = _dbContext.Users.Find(updatedUser.Id);
            if (existingUser == null)
                throw new InvalidOperationException($"Użytkownik o ID {updatedUser.Id} nie został znaleziony.");
            
            existingUser.Login = updatedUser.Login;
            existingUser.Password = HashPassword(updatedUser.Password);
            existingUser.Email = updatedUser.Email;
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Permissions = updatedUser.Permissions;
            _dbContext.SaveChanges();
        }

        internal int GetUsersCount()
        {
            return _dbContext.Users.Count();
        }
    }
}
