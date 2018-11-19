using CorporateMessenger;
using CorporateMessenger.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var _core = new Core();
            _core.Send();

            IService service = new TcpService("127.0.0.1");
            service.Start();

            while (true) ;
        }
    }
}
