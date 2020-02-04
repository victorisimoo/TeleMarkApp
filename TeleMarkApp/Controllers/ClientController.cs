using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeleMarkApp.Models;
using TeleMarkApp.Services;

namespace TeleMarkApp.Controllers {
    public class ClientController : Controller {
        // GET: Client
        public ActionResult Index() {
            return View(Storage.Instance.ClientList);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                var Client = new ClientModel {
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    TelephoneNumber = collection["TelephoneNumber"],
                    Description = collection["Description"]
                };

                if (Client.SaveClient()) {
                    return RedirectToAction("Index");
                }else {
                    return View(Client);
                }
            } catch {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }catch {
                return View();
            }
        }
    }
}
