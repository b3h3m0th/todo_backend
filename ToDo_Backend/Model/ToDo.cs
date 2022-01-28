using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo_Backend.Model
{
    [Table("todos")]
    public class ToDo
    {
        [Key]
        public int ID { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Titel { get; set; }

        [MaxLength(300)]
        public string Beschreibung { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public bool Erledigt { get; set; }
    }
}