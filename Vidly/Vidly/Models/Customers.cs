using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        //navigation property
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}