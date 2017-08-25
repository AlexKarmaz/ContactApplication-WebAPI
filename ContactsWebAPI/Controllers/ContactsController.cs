using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactsWebAPI.Models;
using System.Web.Http.Cors;

namespace ContactsWebAPI.Controllers
{
    [EnableCors(origins: "http://127.0.0.1:5500", headers: "*", methods: "*")]
    public class ContactsController : ApiController
    {

        public IEnumerable<Contact> Get()
        {
            return ContactsService.Instance.GetAllContacts();
        }

        public IHttpActionResult Get(int id)
        {
            var contact = ContactsService.Instance.GetAllContacts().FirstOrDefault((c) => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        public IHttpActionResult Post(int id, Contact contact)
        {
            if (contact != null)
            {
                ContactsService.Instance.Add(contact);

                return Ok(contact);
            }
            else
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(int[] array)
        {
            if (array == null)
            {
                return NotFound();
            }

           ContactsService.Instance.removeContact(array);

            return Ok();
        }

        public IHttpActionResult Put(int id, Contact contact)
        {
            if (contact == null)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            if (ContactsService.Instance.Update(contact))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
