namespace CorporateMessenger.Entities
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct BaseMessageHeader
    {
        /// <summary>
        /// Идентификатор сообщения
        /// </summary>
        public uint MessageId { get; set; }               //4 байта

        public ushort MajorVersionProtocol { get; set; }  //2 байта
        public ushort MinorVersionProtocol { get; set; }  //2 байта
        //-----------------------------------------------------------
        /// <summary>
        /// Идентификатор отправителя
        /// </summary>
        public uint UserSenderId { get; set; }            //4 байта
        /// <summary>
        /// Идентификатор получателя
        /// </summary>
        public uint UserReceiverId { get; set; }          //4 байта
        //-----------------------------------------------------------
        public ushort BaseTypeMessageId { get; set; }     //2 байта
        
        /// <summary>
        /// Параметры сообщения
        /// </summary>
        public ushort MessageOptions { get; set; }        //2 байта

        /// <summary>
        /// Время от начала сессии в мс
        /// </summary>
        public ushort Time { get; set; }                  //2 байта

        /// <summary>
        /// Уникальный идентификатор канала
        /// </summary>
        public ushort Token { get; set; }                 //2 байта
        //-----------------------------------------------------------
        /// <summary>
        /// Номер пакета
        /// </summary>
        public ushort PackNumber { get; set; }            //2 байта

        /// <summary>
        /// Общее число пакетов
        /// </summary>
        public ushort PackCount { get; set; }             //2 байта

        /// <summary>
        /// Резерв
        /// </summary>
        public uint Reserve { get; set; }                 //4 байта
        //-----------------------------------------------------------
    }
}
