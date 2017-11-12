using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Game
    {
        [HiddenInput(DisplayValue =false)]
        public int GameId { get; set; }
        [Display(Name="Name")]
        [Required(ErrorMessage ="Please input name of game!")]
        public string Name { get; set; }
        [DataType (DataType.MultilineText)]
        [Display(Name="Description")]
        [Required(ErrorMessage = "Please input description of game!")]
        public string Description { get; set; }
        [Display(Name="Cathegory")]
        [Required(ErrorMessage = "Please input cathegory of game!")]
        public string Category { get; set; }
        [Display(Name="Cost ($)")]
        [Required]
        [Range (0.01,double.MaxValue,ErrorMessage ="Please enter a positive number!")]
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMineType { get; set; }
    }
}
