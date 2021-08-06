using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TestWeek4L.Core;

namespace TestWeek4L.ClienteWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IClienteAnagrafica
    {
        [OperationContract]
        List<Cliente> GetAllClineti();

        [OperationContract]
        Cliente GetClienteByID(int id);

        [OperationContract]
        bool AddCliente(Cliente newCliente);

        [OperationContract]
        bool UpdateCliente(Cliente updatedCliente);
        [OperationContract]
        bool DeleteClienteById(int id);

    }

    
}
