using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TestWeek4L.Core;
using TestWeek4L.Core.BusinessLayer;
using TestWeek4L.Core.EF.Repository;
using TestWeek4L.Core.Interfaces;

namespace TestWeek4L.ClienteWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ClienteAnagrafica : IClienteAnagrafica
    {
        IOrdineBL ordineBL;
        public ClienteAnagrafica()
        {
            DependencyContainer.Register<IOrdineBL, OrdineBL>();
            DependencyContainer.Register<IClienteRepository, EFClienteRepository>();

            this.ordineBL = DependencyContainer.Resolve<IOrdineBL>();

        }
        public bool AddCliente(Cliente newCliente)
        {
            if (newCliente == null)
                return false;

            return this.ordineBL.CreateCliente(newCliente);
        }

        public bool DeleteClienteById(int id)
        {
            if (id > 0)
                return this.ordineBL.DeleteClienteById(id);

            return false;
        }

        public List<Cliente> GetAllClineti()
        {
            var result = ordineBL.FetchClienti().ToList();
            return result;
        }

        public Cliente GetClienteByID(int id)
        {
            if (id <= 0)
                return null;

            var cliente = ordineBL
                .FetchClienti(c => c.ID == id)
                .FirstOrDefault();

            return cliente;
        }

        public bool UpdateCliente(Cliente updatedCliente)
        {
            if (updatedCliente == null)
                return false;
            return this.ordineBL.EditCliente(updatedCliente);
        }
    }
}
