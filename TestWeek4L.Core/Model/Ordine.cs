using System;
using System.Collections.Generic;
using System.Text;

namespace TestWeek4L.Core.Model
{

    public class Ordine
    {
        public int ID { get; set; }
        public DateTime DataOrdine { get; set; }
        public string CodiceOrdine { get; set; }
        public string CodiceProdotto { get; set; }
        public decimal Importo { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

    }
}
