using CorporateMessenger.Entities;
using CorporateMessenger.Tools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorporateMessenger
{
    public class Core
    {
        ClientManager _client;

        public Core()
        {
            _client = new ClientManager();
        }       

        public void Send()
        {
            Task.Run(() =>
            {
                Thread.Sleep(10 * 1000);

                TcpClient client = new TcpClient("127.0.0.1", 7777);

                BaseMessage message = new BaseMessage();
                message.Header.UserSenderId = 1;
                message.Header.UserReceiverId = 0;
                message.Header.MessageId = 1;

                message.Data = Encoding.Unicode.GetBytes("Привет! Это сообщение отправленное с помощью winsock");

                var dt = DateTime.Now;

                while (true)
                {

                    message.Header.Time = (ushort)(dt - DateTime.Now).TotalMilliseconds;

                    var bytearray = RawSerializerTool<BaseMessage>.RawSerialize(message);

                    client.GetStream().Write(bytearray, 0, bytearray.Length);

                    message = RawSerializerTool<BaseMessage>.RawDeserialize(GetByte(client));
                    message.Header.MessageId++;
                    Thread.Sleep(1000 * 60);
                }
            });
        }

        private byte[] GetByte(TcpClient client)
        {
            var buff = new byte[2048];
            var totalRead = 0;
            do
            {
                var read = client.GetStream().Read(buff, totalRead, buff.Length - totalRead);
                totalRead += read;
            } while (client.GetStream().DataAvailable);

            return buff;
        }
    }
}
