using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Generic pagination class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pagination<T> where T: class

    {
        public Pagination(List<T> phones, Int32 count)
        {
            this.Values = phones;
            this.Count = count;
        }

        /// <summary>
        /// List of objects
        /// </summary>
        public List<T> Values { get; set; }

        /// <summary>
        /// How many object do we have in total
        /// </summary>
        public Int32 Count { get; set; }
    }
}
