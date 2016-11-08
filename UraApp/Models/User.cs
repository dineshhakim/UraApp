using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UraApp.Models
{
    [Table("Users")]
    public class User : IEntity
    {
        public int Id { get; set; }

     
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

         
        [StringLength(50)]
        [Required]
        public string EmailId { get; set; }
       
        [StringLength(100)]
        [Required]

        public string UserName { get; set; }
      
        [StringLength(100)]
        [Required]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "How much is Above")]
        public string Captcha { get; set; }

        public bool Active { get; set; }

        public bool IsAdmin { get; set; }

    }
}
