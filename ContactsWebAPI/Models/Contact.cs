using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Dob { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
        public string Description { get; set; }
        public bool isFavorite { get; set; }
    }
}