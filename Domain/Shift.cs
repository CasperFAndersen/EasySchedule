using System.Runtime.Serialization;

namespace Core
{
    [DataContract]
    public abstract class Shift
    {
        #region Properties
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double Hours { get; set; }

        [DataMember]
        public Employee Employee { get; set; }
        #endregion
    }
}
