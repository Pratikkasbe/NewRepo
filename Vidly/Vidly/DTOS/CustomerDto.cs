using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOS
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        //navigation property
        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        //[If18YearOrNot]
        public DateTime? BirthDate { get; set; }
    }
}