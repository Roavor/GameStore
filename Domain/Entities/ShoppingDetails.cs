using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage ="Enter your name!")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Enter your first address!")]
        [Display(Name="First Address")]
        public string Line1 { get; set; }
        [Required(ErrorMessage = "Enter your second address!")]
        [Display(Name = "Second Address")]
        public string Line2 { get; set; }
        [Required(ErrorMessage = "Enter your thirdh address!")]
        [Display(Name = "Thirth Address")]
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Enter city")]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required(ErrorMessage ="Enter country")]
        [Display(Name = "Country")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
