using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace contact_list_backend.Models
{
    [Owned]
    public class Address
    {
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string State { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Zip code must contain only numbers.")]
        public string Zip { get; set; }
    }

    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must contain only numbers.")]
        public string PhoneNumber { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public int ContactFrequencyId { get; set; }
    }
}
