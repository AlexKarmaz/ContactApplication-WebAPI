using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http;
using ContactsWebAPI.Models;
using System.Web.Http.Cors;

namespace ContactsWebAPI.Controllers
{
    [EnableCors(origins: "http://127.0.0.1:5500", headers: "*", methods: "*")]
    public class FavoriteContactsController : ApiController
    {
        public IHttpActionResult Post(int id)
        {
            Contact contact = ContactsService.Instance.GetAllContacts().FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            ContactsService.Instance.changeFavorite(id);
          
            return Ok();
        }
    }
}
