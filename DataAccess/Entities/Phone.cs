using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Phone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    }
}
