using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestWeek4L.Core.Interfaces;
using TestWeek4L.Core.Model;

namespace TestWeek4L.Core.BusinessLayer
{
    public class OrdineBL : IOrdineBL
    {
        private readonly IOrdineRepository ordineRepo;
        private readonly IClienteRepository clienteRepo;

        public OrdineBL( IOrdineRepository ordineRepo, IClienteRepository clienteRepo)
        {
            this.ordineRepo = ordineRepo;
            this.clienteRepo = clienteRepo;

        }

        public OrdineBL()
        {
            this.clienteRepo = DependencyContainer.Resolve<IClienteRepository>();
        }
        public bool CreateCliente(Cliente newCliente)
        {
            if (newCliente == null)
                return false;
            return clienteRepo.Add(newCliente);
        }

        public bool CreateOrdine(Ordine newOrdine)
        {
            if (newOrdine == null)
                return false;
            return ordineRepo.Add(newOrdine);
        }

        public bool DeleteClienteById(int idCliente)
        {
            if (idCliente <= 0)
                return false;
            Cliente clienteToBeDeleted = this.clienteRepo.GetById(idCliente);
            if (clienteToBeDeleted != null)
                return clienteRepo.Delete(clienteToBeDeleted);

            return false;
        }

        public bool DeleteOrdinebyId(int idOrdine)
        {
            if (idOrdine <= 0)
                return false;
            Ordine ordineToBeDeleted = this.ordineRepo.GetById(idOrdine);
            if (ordineToBeDeleted != null)
                return ordineRepo.Delete(ordineToBeDeleted);

            return false;
        }

        public bool EditCliente(Cliente editedCliente)
        {
            if (editedCliente == null)
                return false;

            return clienteRepo.Update(editedCliente);
        }

        public bool EditOrdine(Ordine editedOrdine)
        {
            if (editedOrdine == null)
                return false;

            return ordineRepo.Update(editedOrdine);
        }

        public Cliente FetchClienteById(int id)
        {
            if (id <= 0)
                return null;

            return clienteRepo.GetById(id);
        }

        public IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null)
        {
            if (filter != null)
                return clienteRepo.Fetch().Where(filter);

            return clienteRepo.Fetch();
        }

        public Ordine FetchOrdineById(int id)
        {
            if (id <= 0)
                return null;

            return ordineRepo.GetById(id);
        }

        public IEnumerable<Ordine> FetchOrdini(Func<Ordine, bool> filter = null)
        {

            if (filter != null)
                return ordineRepo.Fetch().Where(filter);

            return ordineRepo.Fetch();
        }
    }
}
