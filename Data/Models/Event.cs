using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lab04.Data.Models
{
    /// <summary>
    /// Klasa reprezentująca wydarzenie.
    /// </summary>
    [Table("Events")]
    public class Event
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nazwa")]
        [StringLength(100)]
        public required string Name { get; set; }

        [Required]
        [Column("agenda")]
        public required string Agenda { get; set; }

        [Required]
        [Column("termin")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
