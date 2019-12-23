using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using EvolentHealthProject.Models;
using System.Net;
using System.Web.Http.Description;

namespace EvolentHealthProject.Controllers
{
    public class ContactsController : ApiController
    {
        //private readonly ContactContext _context;
        private readonly ContactDetailsEntities _context;

        public ContactsController()
        {
            _context = new ContactDetailsEntities();
        }

        // GET /api/contacts  
        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts.ToList();
        }

        /*[ResponseType(typeof(Contact))]
        public IHttpActionResult GetContacts(int id)
        {
            Contact contct = _context.Contacts.Find(id);
            if (contct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(contct);
        }*/

        // POST /api/contacts 
        [HttpPost]
        public Contact CreateContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact;
        }

        // PUT /api/contacts/1  
        [HttpPut]
        public void UpdateContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var contct = _context.Contacts.SingleOrDefault(x => x.Id == id);

            // Might be user sends invalid id.  
            if (contct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            contct.FirstName = contact.FirstName;
            contct.LastName = contact.LastName;
            contct.Email = contact.Email;
            contct.PhoneNumber = contact.PhoneNumber;
            contct.ContactStatus = contact.ContactStatus;

            _context.SaveChanges();
        }


        // Delete /api/contacts/1  
        [HttpDelete]
        public void DeleteContact(int id)
        {
            var contct = _context.Contacts.SingleOrDefault(x => x.Id == id);

            // Might be user sends invalid id.  
            if (contct == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Contacts.Remove(contct);
            // Now the object is marked as removed in memory  


            // Now it is done  
            _context.SaveChanges();
        }

    }
}
