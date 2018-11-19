using CorporateMessenger.Entities;
using CorporateMessenger.Tools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorporateMessenger
{
    public class ClientManager
    {
        private ConcurrentQueue<TcpClient> _queue;

        private Timer _timer;

        private byte[] _buff = new byte[2048];

        public ClientManager()
        {

        }

        public void Start()
        {
            _queue = new ConcurrentQueue<TcpClient>();
            _timer = new Timer(HandleClient, null, 100, -1);
        }

        public void HandleClient(object obj)
        {
            try
            {
                if (_queue.Count > 0)
                {
                    TcpClient tmp;
                    while (!_queue.TryDequeue(out tmp))
                    {
                        Thread.Sleep(100);
                    }

                    if (tmp != null && tmp.Connected)
                    {
                        Array.Clear(_buff, 0, _buff.Length);

                        var _stream = tmp.GetStream();

                        var _byteCount = 0;
                        while(_byteCount < 2048)
                        {
                            _byteCount += _stream.Read(_buff, _byteCount, _buff.Length - _byteCount);
                        }

                        try
                        {
                            var Msg = RawSerializerTool<BaseMessage>.RawDeserialize(_buff);
                        }
                        catch(Exception ex)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            _timer.Change(100, -1);
        }

        public void Add(TcpClient client) => _queue.Enqueue(client);

    }
}
