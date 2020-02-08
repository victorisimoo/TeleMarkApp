using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TeleMarkApp.Models;
using TeleMarkApp.Services;

namespace TeleMarkApp.Controllers {
    public class ClientController : Controller {

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
        // GET: Client
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            ViewBag.LastNameSortParam = string.IsNullOrEmpty(sortOrder) ? "lastname_asc" : "";
            var clients = Storage.Instance.ClientList;

            if (sortOrder == "name_asc")
            {
                for (int i = 0; i < clients.Count - 1; i++)
                {
                    for (int j = 0; j < clients.Count - i - 1; j++)
                    {
                        if (Compare_Names(clients[j].Name, clients[j + 1].Name))
                        {
                            var aux = clients[j];
                            clients[j] = clients[j + 1];
                            clients[j + 1] = aux;
                        }
                    }

                }
                Storage.Instance.ClientList = clients;
            }
            else
            {
                for (int i = 0; i < clients.Count - 1; i++)
                {
                    for (int j = 0; j < clients.Count - i - 1; j++)
                    {
                        if (Compare_Names(clients[j].LastName, clients[j + 1].LastName))
                        {
                            var aux = clients[j];
                            clients[j] = clients[j + 1];
                            clients[j + 1] = aux;
                        }
                    }

                }
                Storage.Instance.ClientList = clients;
            }
            return View(clients.ToList());
        }

        //Method for compare names and lastnames on the ClientList
        public bool Compare_Names(string name_1, string name_2)
        {
            int size = 0;
            if (name_1.Length > name_2.Length)
            {
                size = name_1.Length;
            }
            else
            {
                size = name_2.Length;
            }

            for (int k = 0; k < size; k++)
            {
                if (k < name_1.Length && k < name_2.Length)
                {
                    if (name_1[k].CompareTo(name_2[k]) < 0)
                    {
                        return false;
                    }
                    else if (name_1[k].CompareTo(name_2[k]) == 0)
                    {
                        return false;
                    }
                    else if (name_1[k].CompareTo(name_2[k]) > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
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
