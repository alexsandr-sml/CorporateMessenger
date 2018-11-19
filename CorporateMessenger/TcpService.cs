using CorporateMessenger.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorporateMessenger
{
    public class TcpService : IService
    {
        private ClientManager _client;

        private volatile EServiceState _state;

        public EServiceState State
        {
            get
            {
                return _state;
            }
        }

        private string _adress;

        private IPAddress _ipAdress
        {
            get
            {
                IPAddress _tmpAdress;

                if (!IPAddress.TryParse(_adress, out _tmpAdress))
                    return IPAddress.Parse("127.0.0.1");

                return _tmpAdress;
            }
        }

        public TcpService(string adress)
        {
            _client = new ClientManager();

            _adress = adress;
        }

        public async void Start()
        {
            var listner = new TcpListener(_ipAdress, 7777);
            listner.Start();

            _client.Start();

           _state = EServiceState.Started;
            while (_state == EServiceState.Started)
            {
                if (!listner.Pending())
                {
                    Thread.Sleep(100);
                }

                var client = await listner.AcceptTcpClientAsync();
                _client.Add(client);
            }
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            _state = EServiceState.Stopped;
        }
    }
}
