using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using EvolentMvcApp.Models;

namespace EvolentMvcApp.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

        public ActionResult Index()
        {
            IEnumerable<Contact> contactList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contacts").Result;
            contactList = response.Content.ReadAsAsync<IEnumerable<Contact>>().Result;
            return View(contactList);
        }

        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Contact());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Contacts/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Contact>().Result);
            }

        }

        [HttpPost]
        public ActionResult AddOrEdit(Contact cnt)
        {
            if (cnt.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Contacts", cnt).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Contacts/"+cnt.Id,cnt).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Contacts/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
       
    }
}
