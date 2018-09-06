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
        /// <summary>
        /// Searches database for specified parameters
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="name"></param>
        /// <param name="manufacturer"></param>
        /// <param name="priceFrom"></param>
        /// <param name="priceTo"></param>
        /// <returns>List of phones</returns>
        public Pagination<PhoneModel> Search(Int32 pageNum, String name, String manufacturer = null, Double? priceFrom = null, Double? priceTo = null, Int32 itemsPerPage = 10)
        {
            IPhoneRepository phoneRepo = new PhoneRepository();

            var phones = phoneRepo.GetPhonesByPage(pageNum, name, manufacturer, priceFrom, priceTo, itemsPerPage);

            var phoneModels = new List<PhoneModel>();

            foreach (var phone in phones.Values)
            {
                phoneModels.Add(new PhoneModel(phone));
            }

            return new Pagination<PhoneModel>(phoneModels, phones.Count);
        }

        public PhoneModel GetSingleItem(Int32 id)
        {
            IPhoneRepository phoneRepo = new PhoneRepository();

            return new PhoneModel(phoneRepo.Get(id));
        }
    }
}
