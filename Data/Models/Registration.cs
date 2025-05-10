using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab04.Data.Models
{
    /// <summary>
    /// Klasa reprezentująca rejestrację użytkownika na wydarzenie.
    /// </summary>
    [Table("Registrations")]
    internal class Registration
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
        [Range(0, 4)]
        public ushort AttendType { get; set; } = 0;

        [Required]
        [Column("food_type")]
        [Range(0, 3)]
        // mozliwe typy jedzenia: 0 - bez preferencji, 1 - wegetarianin, 2 - bezglutenowe
        public ushort FoodType { get; set; } = 0;

        [Required]
        [Column("accept_state")]
        [Range(0, 2)]
        // 0 - oczekuje, 1 - zaakceptowane, 2 - odrzucone
        public ushort AcceptState { get; set; } = 0;

        public override string ToString()
        {
            var attendType = AttendType switch
            {
                0 => "Sluchacz",
                1 => "Autor",
                2 => "Sponsor",
                3 => "Organizator",
                _ => "Nieznany typ"
            };

            var foodType = FoodType switch
            {
                0 => "Bez preferencji",
                1 => "Wegetarianin",
                2 => "Bezglutenowe",
                _ => "Nieznany typ"
            };

            return $"{Id} {User.Id} {Event.Id} {attendType} {foodType} {AcceptState}";
        }
    }
}
