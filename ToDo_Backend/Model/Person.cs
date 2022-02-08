using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_Backend.Model
{
    [Table("persons")]
    public class Person
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Vorname { get; set; }

        [Required, MinLength(2), MaxLength(30)]
        public string Nachname { get; set; }

        [Required]
        public DateTime Geburtsdatum { get; set; }

        public virtual ICollection<ToDo> ToDos { get; set; } = new HashSet<ToDo>();
    }
}
