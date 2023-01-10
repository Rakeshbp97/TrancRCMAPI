using ClientService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ClientService.Models.MangeClientModel;

namespace ClientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageClientController : ControllerBase
    {
        private readonly IManageClient _manageclient;

        public ManageClientController(IManageClient manageclient)
        {
            _manageclient = manageclient;
        }

        [HttpGet]
        [Route("test")]
        public string test()
        {
            return "working fine";
        }

        [HttpPost]
        [Route("addClient")]
        public int addClient(AddClient obj)
        {
            if (ModelState.IsValid)
            {
                //success
               return _manageclient.addClient(obj);
            }
            else
            {
                //failed
                return 400;
            }
        }

        [HttpPost]
        [Route("modifyClient")]
        public int modifyClient(ModifyClient obj)
        {
            if (ModelState.IsValid)
            {
                //success
                return _manageclient.modifyClient(obj);
            }
            else
            {
                //failed
                return 400;
            }
        }



        [HttpPost]
        [Route("addDisposition")]
        public int addDisposition(AddDisposition obj)
        {
            if (ModelState.IsValid)
            {
                //success
                return _manageclient.addDisposition(obj);
            }
            else
            {
                //failed
                return 400;
            }
        }

        [HttpPost]
        [Route("modifyDisposition")]
        public int modifyDisposition(ModifyDisposition obj)
        {
            if (ModelState.IsValid)
            {
                //success
                return _manageclient.modifyDisposition(obj);
            }
            else
            {
                //failed
                return 400;
            }
        }

    }
}
