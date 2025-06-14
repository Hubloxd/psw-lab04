using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab04.Data.Models
{
    /// <summary>
    /// Klasa reprezentująca rejestrację użytkownika na wydarzenie.
    /// </summary>
    [Table("Registrations")]
    public class Registration
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("user")]
        public required User User { get; set; }

        [Required]
        [Column("event")]
        public required Event Event { get; set; }

        [Required]
        [Column("attend_type")]
        // mozliwe typy uczestnictwa: 0 - sluchacz, 1 - autor, 2 - sponsor, 3 - organizator
        public required string AttendType { get; set; }

        [Required]
        [Column("food_type")]
        [Range(0, 3)]
        // mozliwe typy jedzenia: 0 - bez preferencji, 1 - wegetarianin, 2 - bezglutenowe
        public required string FoodType { get; set; }

        [Required]
        [Column("accept_state")]
        [Range(0, 2)]
        // 0 - oczekuje, 1 - zaakceptowane, 2 - odrzucone
        public required string AcceptState { get; set; }

        public override string ToString()
        {
            return $"{Id} {User.Id} {Event.Id} {AttendType} {FoodType} {AcceptState}";
        }
    }
}
