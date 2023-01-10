using ClientService.Interfaces;
using ClientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ClientService.Models.MangeClientModel;

namespace ClientService.Repositories
{
    public class ManageClientRepository : IManageClient
    {
        public int addClient(AddClient obj)
        {
            return 200;
        }

        public int addDisposition(AddDisposition obj)
        {
            return 200;
        }

        public int modifyClient(ModifyClient obj)
        {
            return 200;
        }

        public int modifyDisposition(ModifyDisposition obj)
        {
            return 200;
        }
    }
}
