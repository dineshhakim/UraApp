using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UraApp.Models
{
    [Table("Portfolio")]
    public class Portfolio : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string PortfolioName { get; set; }
        [Display(Name = "Description")]
        public string PortfolioDescription { get; set; }
        [Display(Name = "Type")]
        public int PortfolioType { get; set; }

        public string Url { get; set; }
        [Display(Name = "Order")]
        public int Odr { get; set; }

        public bool Active { get; set; }

    }
}
