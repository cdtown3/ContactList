using System.ComponentModel.DataAnnotations;

namespace contact_list_backend.Models
{
    public class ContactFrequency
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
