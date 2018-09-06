using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Contexts;

namespace DataAccess.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        public void Add(Phone phone)
        {
            using (EMobileContext context = new EMobileContext())
            {
                context.Phones.Add(phone);
                context.SaveChanges();
            }
        }

        public List<Phone> Find(Expression<Func<Phone, bool>> expression)
        {
            using (EMobileContext context = new EMobileContext())
            {
                var query = context.Phones.Where(expression);
                return query.ToList();
            }
        }

        public Phone Get(int id)
        {
            using (EMobileContext context = new EMobileContext())
            {
                return context.Phones.Find(id);
            }
        }

        public Pagination<Phone> GetPhonesByPage(Int32 pageNumber, 
                                           String name = null, 
                                           String manufacturer = null, 
                                           Double? priceFrom = null, 
                                           Double? priceTo = null, 
                                           Int32 phonesPerPage = 10)
        {
            using (EMobileContext context = new EMobileContext())
            {
                var query = context.Phones.AsQueryable();

                if (!String.IsNullOrEmpty(name) && !String.IsNullOrWhiteSpace(name))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
                }

                if (!String.IsNullOrEmpty(manufacturer) && !String.IsNullOrWhiteSpace(manufacturer))
                {
                    query = query.Where(x => x.Manufacturer.ToLower().Contains(manufacturer.ToLower()));
                }

                if (priceFrom != null)
                {
                    query = query.Where(x => x.Price >= priceFrom);
                }

                if (priceTo != null)
                {
                    query = query.Where(x => x.Price <= priceTo);
                }

                var count = query.Count();

                query = query.OrderBy(x => x.Id)
                   .Skip((pageNumber - 1) * phonesPerPage)
                   .Take(phonesPerPage);

                return new Pagination<Phone>(query.ToList(), count);
            }
        }

        public void Remove(Phone phone)
        {
            using (EMobileContext context = new EMobileContext())
            {
                context.Phones.Remove(phone);
                context.SaveChanges();
            }
        }
    }
}
