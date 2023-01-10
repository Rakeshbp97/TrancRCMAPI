using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Models
{
    public class MangeClientModel
    {
        public class AddClient
        {
            public int tenantID { get; set; }
            public int userID { get; set; }
            public string clientName { get; set; }
        }
        public class ModifyClient
        {
            public int tenantID { get; set; }
            public int userID { get; set; }
            public int clientID { get; set; }
            public string clientName { get; set; }
        }
        public class AddDisposition
        {
            public string dispositionName { get; set; }
            public int userID { get; set; }
        }
        public class ModifyDisposition
        {
            public string dispositionName { get; set; }
            public int userID { get; set; }
            public int dispositionID { get; set; }
        }
        public class AddSubDisposition
        {
            public string subDispositionName { get; set; }
            public int userID { get; set; }
        }
        public class ModifySubDisposition
        {
            public string subDispositionName { get; set; }
            public int userID { get; set; }
            public int subDispositionID { get; set; }
        }
        public class AddActionCode
        {
            public string actionCodeName { get; set; }
            public int userID { get; set; }
        }
        public class ModifyActionCode
        {
            public string actionCodeName { get; set; }
            public int userID { get; set; }
            public int actionCodeID { get; set; }
        }
    }
}
