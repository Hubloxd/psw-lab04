using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab04.Data.Models
{
    /// <summary>
    /// Klasa reprezentująca użytkownika.
    /// </summary>
    [Table("Users")]
    internal class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("first_name")]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [Column("login")]
        [StringLength(50)]
        public required string Login { get; set; }

        [Required]
        [Column("password")]
        [StringLength(255)]
        public required string Password { get; set; }

        [Required]
        [Column("email")]
        [StringLength(100)]
        public required string Email { get; set; }

        [Required]
        [Column("permissions")]
        [Range(0, 1)]
        // 0 - admin, 1 - uzytkownik
        public ushort Permissions { get; set; } = 1;

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Login} {Password} {Email} {Permissions}";
        }
    }
}
