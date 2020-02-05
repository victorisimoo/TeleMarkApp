using System;
using System.Linq;
using TeleMarkApp.Services;

namespace TeleMarkApp.Models {
    public class ClientModel {
        public static int codeClient = 0;
        public int ClientId { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String TelephoneNumber { get; set; }
        public String Description { get; set; }

        public bool SaveClient(){
            try {
                codeClient++;
                this.ClientId = codeClient;
                Storage.Instance.ClientList.Add(this);
                return true;
            }catch (Exception e) {
                return false;
            }
        }

        public bool UpdateClient(){
            try{
                
                return true;
            }catch (Exception e) {
                return false;
            }
        }


    }
}