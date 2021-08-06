using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TestWeek4L.Core.Model;

namespace TestWeek4L.Core
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string CodiceCliente { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cognome { get; set; }

        public List<Ordine> Ordini { get; set; }
    }
}
