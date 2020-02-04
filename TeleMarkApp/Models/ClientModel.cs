using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeleMarkApp.Services;

namespace TeleMarkApp.Models {
    public class ClientModel {

        public String Name { get; set; }
        public String LastName { get; set; }
        public String TelephoneNumber { get; set; }
        public String Description { get; set; }

        public bool SaveClient(){
            try {
                Storage.Instance.ClientList.Add(this);
                return true;
            }catch (Exception e) {
                return false;
            }
        }


    }
}