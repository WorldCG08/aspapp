using System;
using System.ComponentModel.DataAnnotations;
using aspapp.Models;

namespace aspapp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        public byte MembershipTypeId { get; set; }
        public  MembershipTypeDto MembershipType { get; set; }
        
        //[Min18YearsOldForMembership]
        public DateTime? Birthdate { get; set; }
    }
}