using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ClientService.Models.MangeClientModel;

namespace ClientService.Interfaces
{
    public interface IManageClient
    {
        public int addClient(AddClient obj);
        public int modifyClient(ModifyClient obj);
        public int addDisposition(AddDisposition obj);
        public int modifyDisposition(ModifyDisposition obj);
    }
}
