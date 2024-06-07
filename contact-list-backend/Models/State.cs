using System.ComponentModel.DataAnnotations;

namespace contact_list_backend.Models
{
    public class State
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2)]
        public string Abbreviation { get; set; }
    }
}
