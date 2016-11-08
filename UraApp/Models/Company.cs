using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UraApp.Models
{
    [Table("Company")]
    public class Company : IEntity
    {
        public int Id { get; set; }
       
        [StringLength(200)]
        public string Name { get; set; }
       
        [StringLength(500)]
        public string Description { get; set; }
        
        [StringLength(100)]
        public string Address { get; set; }
      
        [StringLength(10)]
        public string ZipCode { get; set; }
         
        [StringLength(50)]
        public string City { get; set; }
       
        [StringLength(50)]
        public string State { get; set; }
        [StringLength(50)]
        public string EmaildId { get; set; }
      
        [StringLength(50)]
        public string ContactNo { get; set; }
       
        [StringLength(50)]
        public string BusinessHours { get; set; }
        
        [StringLength(100)]
        public string WebsiteLink { get; set; }


        public List<SocialNetwork> SocialNetworks { get; set; }
    }
}
