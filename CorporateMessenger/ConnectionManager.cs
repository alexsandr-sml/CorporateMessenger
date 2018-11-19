using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Net.Sockets;

namespace CorporateMessenger
{
    public class ConnectionManager
    {
        private ConcurrentQueue<Connection> _queue;

        private Timer _timer;

        public ConnectionManager()
        {

        }

        public void Add(TcpClient client)
        {
            if (_queue == null)
                throw new Exception("ConnectionManager _queue=null");

            _queue.Enqueue(new Connection()
            {
                Client = client,
                ConnectionDateTime = DateTime.Now
            });
        }

        public void HandleClient(object obj)
        {
            try
            {
                if (_queue.Count > 0)
                {
                    Connection tmp;
                    while (!_queue.TryDequeue(out tmp))
                    {
                        Thread.Sleep(100);
                    }


                }
            }
            catch (Exception ex)
            {

            }

            _timer.Change(100, -1);
        }

    }
}
