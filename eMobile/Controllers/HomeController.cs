using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eMobile.Models;
using BusinessLogic;

namespace eMobile.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Queries database for the parameters and returns partial view of the mobile cards
        /// </summary>
        /// <param name="pageNum">number of page</param>
        /// <param name="manufacturer">search for manufacturer</param>
        /// <param name="priceFrom">start price</param>
        /// <param name="priceTo">end price</param>
        /// <returns>returns partial view of mobile cards</returns>
        public IActionResult GetPhonesPartial(Int32 pageNum, 
                                              String name, 
                                              String manufacturer = null, 
                                              Double? priceFrom = null, 
                                              Double? priceTo = null, 
                                              Int32 itemsPerPage = 10)
        {
            try
            {
                var searcher = new SearchHandler();

                var phones = searcher.Search(pageNum, name, manufacturer, priceFrom, priceTo, itemsPerPage);

                var phoneModels = new List<PhoneModel>();

                foreach (var phone in phones.Values)
                {
                    phoneModels.Add(new PhoneModel(phone));
                }

                ViewBag.TotalCount = phones.Count;

                return PartialView("_PhonesPartial", phoneModels);
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult PhoneDetails(Int32 id)
        {
            try
            {
                var searcher = new SearchHandler();

                var model = searcher.GetSingleItem(id);

                return View(new PhoneModel(model));
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
