using System;
using System.Collections.Generic;
using System.Text;
using TestWeek4L.Core.Model;

namespace TestWeek4L.Core.Interfaces
{
    public interface IOrdineBL
    {
        #region Ordine

        IEnumerable<Ordine> FetchOrdini(Func<Ordine, bool> filter = null);

        Ordine FetchOrdineById(int id);
        bool CreateOrdine(Ordine newOrdine);
        bool EditOrdine(Ordine editedOrdine);
        bool DeleteOrdinebyId(int idOrdine);
        #endregion

        #region Cliente

        IEnumerable<Cliente> FetchClienti(Func<Cliente, bool> filter = null);
        Cliente FetchClienteById(int id);
        bool CreateCliente(Cliente newCliente);
        bool EditCliente(Cliente editedCliente);
        bool DeleteClienteById(int idCliente);

        #endregion
    }
}
