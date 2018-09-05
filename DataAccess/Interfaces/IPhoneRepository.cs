using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IPhoneRepository
    {
        void Add(Phone phone);

        Phone Get(Int32 id);

        void Remove(Phone phone);

        List<Phone> Find(Expression<Func<Phone, bool>> expression);

        List<Phone> GetPhonesByPage(int pageNumber, 
                                    String name = null, 
                                    String manufacturer = null, 
                                    Double? priceFrom = null, 
                                    Double? priceTo = null, 
                                    int phonesPerPage = 10);
    }
}
