using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeleMarkApp.Models;

namespace TeleMarkApp.Services {
    public class Storage {
        private static Storage _instance = null;
        public static Storage Instance {
            get {
                if (_instance == null) _instance = new Storage();
                return _instance;
            }
        }

        public List<ClientModel> ClientList = new List<ClientModel>();
    }
}