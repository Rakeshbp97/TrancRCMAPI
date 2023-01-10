using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Models
{
    public class MangeClientModel
    {
        public class KAddTenant
        {
            public string tenantName { get; set; }
        }
        public class KAddClient
        {
            public string tenantName { get; set; }
            public string clientName { get; set; }

            public string Roles { get; set; }
        }
        public class Login
        {
            public string username { get; set; }
            public string password { get; set; }
            public string tenant { get; set; }
        }

        public class UserDetails
        {
            public string tenantName { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string emailId { get; set; }
            public string username { get; set; }
            public List<clientdetails> clientdetails { get; set; }
        }

        public class clientdetails
        {
            public string projectName { get; set; }
            public string projectRole { get; set; }

        }

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
