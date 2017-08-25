using ContactsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebAPI
{
    public sealed class ContactsService
    {
        private static readonly Lazy<ContactsService> instance = new Lazy<ContactsService>(() => new ContactsService());

        private List<Contact> Contacts = new List<Contact>
            {
                new Contact { Id = 1, FirstName = "Alex", SecondName = "Karmaz", Dob = "01.01.1999", Phone = "5555567", Gender = "male", Relationship = "Home", Description = "about hf", isFavorite = true  },
                new Contact { Id = 2, FirstName = "Dima", SecondName = "Ignatenko", Dob = "01.01.1999", Phone = "48885", Gender = "male", Relationship = "Work", Description = "about hf", isFavorite = true  },
                new Contact { Id = 3, FirstName = "John", SecondName = "Smit", Dob = "01.01.1999", Phone = "676755", Gender = "male", Relationship = "Home", Description = "about hfh", isFavorite = false  },
                new Contact { Id = 4, FirstName = "Smith", SecondName = "John", Dob = "01.01.1999", Phone = "15551232", Gender = "female", Relationship = "Other", Description = "about hhf" , isFavorite = false },
                new Contact { Id = 5, FirstName = "Kinglsey", SecondName = "Obo", Dob = "01.01.1999", Phone = "4535543", Gender = "male", Relationship = "Other", Description = "about bvfh", isFavorite = false  }
            };
        public static ContactsService Instance { get { return instance.Value; } }

        private ContactsService() { }

        public List<Contact> GetAllContacts()
        {
            return Instance.Contacts;
        }

        public bool changeFavorite (int id)
        {
            Contact contact = Instance.Contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                contact.isFavorite = false;
                return false;
            }

            if(contact.isFavorite == true)
            {
                contact.isFavorite = false;
            }
            else
            {
                contact.isFavorite = true;
            }
           
            return true;                       
        }

        public bool removeContact(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Contact contact = Instance.Contacts.FirstOrDefault(c => c.Id == array[i]);
                if (contact != null)
                {
                    Instance.Contacts.Remove(contact);
                }
                else
                {
                    return false;
                }
            }
           
            return true;
        }

        public Contact Add(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException();
            }
            contact.Id = Instance.GetAllContacts().Last().Id + 1;
            Instance.Contacts.Add(contact);
            return contact;
        }

        public bool Update(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException("newContact");
            }
            Contact oldContact = Instance.Contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (oldContact == null)
            {
                return false;
            }

            oldContact.FirstName = contact.FirstName;
            oldContact.SecondName = contact.SecondName;
            oldContact.Dob = contact.Dob;
            oldContact.Phone = contact.Phone;
            oldContact.Description = contact.Description;
            oldContact.Gender = contact.Gender;
            oldContact.isFavorite = contact.isFavorite;
            oldContact.Relationship = contact.Relationship;


            return true;
        }
    }
}