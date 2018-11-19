using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CorporateMessenger.Entities
{
    [StructLayout(LayoutKind.Sequential, Size = 2048)]
    public struct BaseMessage
    {
        public BaseMessageHeader Header;  //32 байта

        public byte[] Data;               //2016 байта

        public override string ToString()
        {
            return $"{Header.MessageId}:{Header.UserSenderId}->{Header.UserReceiverId} :{Header.Time}";
        }
    }
}
