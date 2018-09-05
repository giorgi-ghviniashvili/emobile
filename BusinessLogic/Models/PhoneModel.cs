using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace BusinessLogic.Models
{
    public class PhoneModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Manufacturer { get; set; }
        public String Size { get; set; }
        public Double Weight { get; set; }
        public Double Price { get; set; }
        public Double Storage { get; set; }
        public String CpuType { get; set; }
        public String OsName { get; set; }
        public Double Ram { get; set; }
        public String ImagePath { get; set; }
        public String Description { get; set; }

        public PhoneModel(Phone phone)
        {
            this.Id = phone.Id;
            this.Name = phone.Name;
            this.Manufacturer = phone.Manufacturer;
            this.Size = phone.Size;
            this.Weight = phone.Weight;
            this.Price = phone.Price;
            this.Storage = phone.Storage;
            this.CpuType = phone.CpuType;
            this.OsName = phone.OsName;
            this.Ram = phone.Ram;
            this.ImagePath = phone.ImagePath;
            this.Description = phone.Description;
        }
    }
}
