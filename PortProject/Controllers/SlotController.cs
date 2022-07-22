using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortProject.Controllers
{
    public class SlotController : Controller
    {
        
        Uri baseAddress = new Uri("https://localhost:44310/api");
        //In asp.net MVC httpclient is available to consume Web API
        //Take reference of httpclient
        //Click on reference and add reference
        // GET: Port
        HttpClient client;

        public SlotController()
        {  //intialize http client object 
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        // GET: SlotController
        public ActionResult Index()
        {
            {//Using this http client obj call port web API
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/port").Result;
                List<PortSlot> slotModel = new List<PortSlot>();
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    //Deserialise json data into slotModel for
                    //this newton soft
                    //for serialization and desserialization
                    //Install from nuget -Newton soft package - Newtonsoft.Json
                    slotModel = JsonConvert.DeserializeObject<List<PortSlot>>(data);
                }
                return View(slotModel);
            }
        }

        // GET: SlotController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SlotController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SlotController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SlotController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SlotController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SlotController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SlotController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
