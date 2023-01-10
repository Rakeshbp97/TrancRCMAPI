using ClientService.Interfaces;
using ClientService.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ClientService.Models.MangeClientModel;



namespace ClientService.Controllers
{
    //[EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class IAMController : ControllerBase
    {
        private readonly IManageClient _manageclient;




        class user
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string enabled { get; set; }
            public string username { get; set; }
            public List<usercred> credentials { get; set; }
        }
        class usercred
        {
            public string type { get; set; }
            public string value { get; set; }
        }
        public IAMController(IManageClient manageclient)
        {
            _manageclient = manageclient;
        }



        [HttpPost]
        [Route("Klogin")]
        public string Klogin(Login obj)
        {
            var postData = new List<KeyValuePair<String, String>> {
              new KeyValuePair<String, String>("username", obj.username),
              new KeyValuePair<String, String>("password" , obj.password),
               new KeyValuePair<String, String>("grant_type", "password"),
              new KeyValuePair<String, String>("client_id" , "admin-cli")
             };
            string token = IAMService.Token(obj.tenant, postData);
            string resuser = IAMService.VerifyTokenKeycloak("http://10.1.240.16:8080/auth/realms/" + obj.tenant + "/protocol/openid-connect/userinfo", token);

            return resuser;
        }

        [HttpPost]
        [Route("AddClient")]
        public int AddClient(KAddClient obj)
        {
            if (ModelState.IsValid)
            {
                var postData = new List<KeyValuePair<String, String>> {
              new KeyValuePair<String, String>("username", "admin"),
              new KeyValuePair<String, String>("password" , "admin"),
               new KeyValuePair<String, String>("grant_type", "password"),
              new KeyValuePair<String, String>("client_id" , "admin-cli")
             };
                string token = IAMService.Token(obj.tenantName, postData);
                var client = new
                {
                    clientId = obj.clientName,
                    defaultRoles= Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(obj.Roles)

                };
                string resclient = IAMService.ConsumeKeycloakService(client, "http://10.1.240.16:8080/auth/realms/"+obj.tenantName+"/clients-registrations/default", token);//client creation
                return 200;
            }
            return 400;
        }


                [HttpPost]
        [Route("AddTenant")]
        public int AddTenant(KAddTenant obj)
        {
            if (ModelState.IsValid)
            {
                //success
                var postData = new List<KeyValuePair<String, String>> {
              new KeyValuePair<String, String>("username", "admin"),
              new KeyValuePair<String, String>("password" , "admin"),
               new KeyValuePair<String, String>("grant_type", "password"),
              new KeyValuePair<String, String>("client_id" , "admin-cli")
             };
                string token = IAMService.Token("master", postData);//Access token 
                var realm = new
                {
                    realm = obj.tenantName
                };
                string res = IAMService.ConsumeKeycloakService(realm, "http://10.1.240.16:8080/auth/admin/realms", token);//tenant creation
                                                                                                                          //var client = new
                                                                                                                          //{
                                                                                                                          //    clientId = "PriyankaGautam"
                                                                                                                          //};
                                                                                                                          //string resclient = IAMService.ConsumeKeycloakService(client, "http://10.1.240.16:8080/auth/realms/master/clients-registrations/default", token);//client creation

                //     var credlist = new List<usercred>
                //     { new usercred  {
                //         type = "password",
                //         value = "trans@123"
                //     }};
                //     var userlist = new 
                //{
                //      firstName= "Priyanka",
                //      lastName= "Gautam",
                //      email="priyanka.gautam@test.com",
                //      enabled="true",
                //      username= "PriyankaG",
                //      credentials= credlist                
                //     };



                //     string resuser = IAMService.ConsumeKeycloakService(userlist, "http://10.1.240.16:8080/auth/admin/realms/master/users", token);//user creation
                return 200;
            }
            else
            {
                //failed
                return 400;
            }
        }
    }
}