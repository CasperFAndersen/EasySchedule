using System;
using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public class ScheduleShift : Shift
    {
        #region Properties
        [DataMember]
        public DateTime StartTime { get; set; }

        [DataMember]
        public bool IsForSale { get; set; }

        [DataMember]
        public byte[] RowVersion { get; set; }
        #endregion
    }
}
