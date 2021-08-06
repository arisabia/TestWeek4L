using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestWeek4L.Core.Interfaces;
using TestWeek4L.Core.Model;

namespace TestWeek4L.Core.EF.Repository
{
    public class EFOrdineRepository : IOrdineRepository
    {
        private readonly OrdineContext ctx;
        public EFOrdineRepository() : this(new OrdineContext())
        {

        }
        public EFOrdineRepository(OrdineContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Ordine item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Ordini.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Ordine item)
        {
            if (item == null)
                return false;

            try
            {
                var ordine = ctx.Ordini.Find(item.ID);

                if (ordine != null)
                    ctx.Ordini.Remove(ordine);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Ordine> Fetch()
        {
            try
            {
                return ctx.Ordini.Include(b => b.Cliente).ToList();
            }
            catch (Exception)
            {
                return new List<Ordine>();
            }
        }

        public Ordine GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Ordini.Find(id);
        }

        public bool Update(Ordine item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Ordini.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
