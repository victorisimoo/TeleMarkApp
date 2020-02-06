using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeleMarkApp.Models;
using TeleMarkApp.Services;

namespace TeleMarkApp.Controllers {
    public class ClientController : Controller {

        // GET: Client
        public ActionResult Index(string sortOrder) {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LastNameSortParam = sortOrder == "Lastname" ? "lastname_desc" : "Lastname";
            var clients = Storage.Instance.ClientList;
            switch (sortOrder){
                case "name_desc":
                   clients = Storage.Instance.ClientList.OrderByDescending(X=>X.Name).ToList();
                break;
                case "Lastname":
                   clients = Storage.Instance.ClientList.OrderBy(X => X.LastName).ToList();
                break;
                case "lastname_desc":
                   clients = Storage.Instance.ClientList.OrderByDescending(X => X.LastName).ToList();
                    break;
                default:
                    clients = Storage.Instance.ClientList.OrderBy(X => X.Name).ToList();
                break;
            }
            return View(clients.ToList());
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
            try{
                var Client = Storage.Instance.ClientList.Where(c => c.ClientId == id).FirstOrDefault();
                return View(Client);
            }catch{
                return View();
            }
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                Storage.Instance.ClientList.RemoveAll(c => c.ClientId == id);
                var Client = new ClientModel {
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    TelephoneNumber = collection["TelephoneNumber"],
                    Description = collection["Description"]
                };

                if (Client.SaveClient()){
                    return RedirectToAction("Index");
                }else{
                    return View(Client);
                }

            } catch {
                
                    return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id) {
            try{
                var Client = Storage.Instance.ClientList.Where(c => c.ClientId == id).FirstOrDefault();
                return View(Client);
            }
            catch{
                return View();
            }
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            var Client = new ClientModel();
            try{
                if (Client == null)
                    return View("NotFound");

                Storage.Instance.ClientList.RemoveAll(c => c.ClientId == id);
                if (Client.UpdateClient()){
                    return RedirectToAction("Index");
                }
                else{
                    return View(Client);
                }
            }
            catch{
                return View(Client);
            }
        }
    }
}
