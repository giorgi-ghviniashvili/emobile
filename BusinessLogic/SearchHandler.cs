using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using BusinessLogic.Models;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Repositories;

namespace BusinessLogic
{
    public class SearchHandler
    {
        public List<PhoneModel> Search(Int32 pageNum, String name, String manufacturer = null, Double? priceFrom = null, Double? priceTo = null)
        {
            IPhoneRepository phoneRepo = new PhoneRepository();

            var phones = phoneRepo.GetPhonesByPage(pageNum, name, manufacturer, priceFrom, priceTo);

            var phoneModels = new List<PhoneModel>();

            foreach (var phone in phones)
            {
                phoneModels.Add(new PhoneModel(phone));
            }

            return phoneModels;
        }
    }
}
