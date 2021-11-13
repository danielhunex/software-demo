using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private const string BaseUrl = "https://localhost:44342/";
        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var contacts = new List<ContactModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/contacts");
                if (Res.IsSuccessStatusCode)
                {
                    var contactsJson = await Res.Content.ReadAsStringAsync();
                    contacts = JsonConvert.DeserializeObject<List<ContactModel>>(contactsJson);
                }

            }
            return View(contacts);
        }


        public async Task<IActionResult> Edit(long id)
        {
            ContactModel contactModel = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"api/{id}");
                if (Res.IsSuccessStatusCode)
                {
                    var contactsJson = await Res.Content.ReadAsStringAsync();
                    contactModel = JsonConvert.DeserializeObject<ContactModel>(contactsJson);
                }

            }
            return View(contactModel);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Edit(ContactModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync("api/contacts", content);

                return RedirectToAction("Index");
            }
        }

        public IActionResult Create()
        {
            return View(new ContactModel());
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Create(ContactModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                HttpResponseMessage Res = await client.PostAsync("api/contacts", content);

                return RedirectToAction("Index");
            }
        }
    }
}

