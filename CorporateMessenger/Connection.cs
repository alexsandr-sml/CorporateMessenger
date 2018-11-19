using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CorporateMessenger
{
    public class Connection
    {
        public int User { get; set; }

        public TcpClient Client { get; set; }

        public DateTime ConnectionDateTime { get; set; }

        public DateTime Disconnection { get; set; }

        public DateTime LastActivityDateTime { get; set; }

        
    }
}
